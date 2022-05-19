# EmptyDirs

이 응용프로그램은 빈 폴더 검색에 사용됩니다.


## Installation & Usage

+ 이 Github 페이지의 Release에서 최근 버전을 다운로드 할 수 있습니다.
+ 별도의 설치를 필요로 하지 않으며, 필요한 곳에 압축파일을 풀어 `EmptyDirs.exe` 파일을 실행하면 됩니다.
+ <button>최상위 경로 선택</button> 버튼으로 경로를 지정하고, <button>검색/갱신</button> 버튼을 누르면 됩니다. 초기 경로는 `%USERPROFILE%`로 설정되어 있으며 최상위 폴더는 지정할 수 없습니다.
+ 선택 경로의 행을 더블 클릭하면 윈도우 탐색기에서 경로를 열 수 있습니다.
+ `상태`
  + 파일을 포함하지 않고, 서브디렉토리가 존재하지 않는 경우 `빈 폴더`로 표시됩니다.
  + 파일을 포함하지 않고, 서브디렉토리가 모두 `빈 폴더` 또는 `빈 폴더 포함`인 경우 `빈 폴더 포함`으로 표시됩니다.
+ `디렉토리 속성`
  + 일반 디렉토리인 경우 `Directory`로 표시됩니다.
  + 이 외의 속성을 가진 경우 [.NET 6 System.Drawing.SystemColor.GrayText](https://docs.microsoft.com/ko-kr/dotnet/api/system.drawing.systemcolors.graytext?view=net-6.0) 색상으로 표시되며, 해당 속성에 대해서는 [.NET System.IO.FileAttributes 열거형](https://docs.microsoft.com/ko-kr/dotnet/api/system.io.fileattributes?view=net-6.0)을 참조하십시오.


## System Requirements

+ Windows 10.0.177630.0 이상 on Any CPU
+ .NET Core 6.0 이상
  + 콘솔에서 `dotnet --list-runtimes` 명령을 통해 해당 시스템에 설치된 .NET 런타임을 확인할 수 있습니다.
  + .NET 런타임 설치: [링크](https://dotnet.microsoft.com/en-us/download/dotnet)

## Project Info

### Version

+ Version 1.0.220519

### Dev & Test Environment

+ C# / .NET Core 6.0
+ Microsoft Visual Studio 2022 Community Edition
+ Microsoft Windows 10 Pro 21H2 19044.1706 (x64)


## License

+ MIT License
