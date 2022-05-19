import os
from enum import Enum


class Status(Enum):
    """디렉토리 상태를 표현하는 열거형"""

    UNKOWN = 0
    """디렉토리 상태를 알 수 없거나 접근이 불가능함"""
    EMPTY = 1
    """파일도 없고, 서브 디렉토리도 없음"""
    CONTAINS_EMPTY = 2
    """파일이 없고, 서브 디렉토리가 있으나 모두 비어 있음"""
    NOT_EMPTY = 3
    """파일이 있거나, 서브 디렉토리 중 하나가 비어 있지 않음"""


class DirStatus:
    """디렉토리의 목록 및 상태를 나타내는 클래스"""

    def __init__(self, toppath: str):
        """최상위 경로로부터 클래스 생성

        Args:
            toppath (str): 검색을 시작할 최상위 경로
        """

        self.__all_dirs: list[str] = []
        self.__dir_status: dict[str, Status] = {}
        self.__top_path = toppath

    @property
    def all_dirs(self) -> list[str]:
        """모든 디렉토리의 목록"""
        return self.__all_dirs

    @property
    def dir_status(self) -> dict[str, Status]:
        """디렉토리의 상태를 저장하는 딕셔너리"""
        return self.__dir_status

    def get_status(self):
        """현재 인스턴스에 대해 서브 디렉토리의 목록과 상태를 반환"""
        self.__all_dirs, self.__dir_status = DirStatus.__get_dirstatus(self.__top_path)

    @staticmethod
    def __get_dirstatus(toppath: str) -> tuple[list[str], dict[str, Status]]:
        """서브 디렉토리의 목록과 상태를 반환

        현재 실행 권한에서 오류 없이 접근 가능한 디렉토리만 검색합니다. 하위 디렉토리의 경로가 많으면 검색이 오래 걸릴 수 있습니다.

        Args:
            toppath (str): 검색을 시작할 최상위 경로

        Returns:
            tuple[list[str], dict[str, Status]]: 튜플. 리스트는 가용한 디렉토리의 목록. 딕셔너리는 디렉토리명(절대경로)과 상태를 가지는 열거형의 키-값 쌍
        """

        alldirs: list[str] = []  # down-top order
        dirstatus: dict[str, Status] = {}
        for (dirpath, dirnames, filenames) in os.walk(toppath, topdown=False, followlinks=False):
            dirstatus[dirpath] = Status.UNKOWN  # 기본값

            if filenames:  # 파일이 존재함
                dirstatus[dirpath] = Status.NOT_EMPTY
            else:  # 파일이 존재하지 않음
                if dirnames:  # 서브 디렉토리가 있음
                    try:
                        chk = all(
                            dirstatus[os.path.join(dirpath, dirname)] == Status.EMPTY
                            or dirstatus[os.path.join(dirpath, dirname)] == Status.CONTAINS_EMPTY
                            for dirname in dirnames
                        )  # 모든 서브 디렉토리가 비어 있는지 체크
                    except KeyError:  # 서브 디렉토리가 존재하나 접근하지 못하는 경우 예외 처리
                        continue  # Status.UNKOWN으로 유지하고 계속 진행
                    if chk:  # 모든 서브 디렉토리가 비어 있을 경우
                        dirstatus[dirpath] = Status.CONTAINS_EMPTY
                    else:  # 서브 디렉토리 중 하나가 비어 있지 않거나 접근이 불가능할 경우
                        dirstatus[dirpath] = Status.NOT_EMPTY
                else:  #  서브 디렉토리가 없음
                    dirstatus[dirpath] = Status.EMPTY

            alldirs.append(dirpath)

        alldirs.reverse()  # top-down order
        return (alldirs, dirstatus)


if __name__ == "__main__":
    toppath: str = r"C:/Users"
    ds = DirStatus(toppath)
    ds.get_status()
    for dirpath in ds.all_dirs:
        stat: Status = ds.dir_status[dirpath]
        if stat == Status.EMPTY or stat == Status.CONTAINS_EMPTY:
            print(f"[{ds.dir_status[dirpath].name}] {dirpath}")
