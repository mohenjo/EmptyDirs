using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyDirs
{
    internal class DirectoryStatus
    {
        /// <summary>
        /// 클래스 인스턴스를 생성
        /// </summary>
        /// <param name="rootPath">최상위 경로</param>
        public DirectoryStatus(string rootPath)
        {
            RootPath = rootPath;
        }

        /// <summary>
        /// 검색을 시작할 최상위 경로
        /// </summary>
        public string RootPath { get; } = null!;

        /// <summary>
        /// 모든 디렉토리 목록
        /// </summary>
        public List<string> AllDirectories { get; private set; } = new();

        /// <summary>
        /// 디렉토리의 상태
        /// </summary>
        public Dictionary<string, Status> Statuses { get; private set; } = new();

        public void GetDirtoryStatus()
        {
            Random rand = new(); // async-awit 대신 간단한 방식으로 ui 프로세스 멈춤 방지

            #region 디렉토리 목록 구성 (Top-Down)
            Stack<string> dirs = new();

            dirs.Push(RootPath);
            AllDirectories.Add(Path.GetFullPath(RootPath));

            while (dirs.Count > 0)
            {
                if (rand.Next(20) == 0) { Application.DoEvents(); }

                string currentDir = dirs.Pop();
                string[] subDirs;

                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (Exception e)
                {
                    string logMessage = $"{currentDir}의 하위 디렉토리를 읽어올 수 없으므로, 디렉토리 목록에서 제외합니다: {e.GetType()}";
                    Utils.WriteToLog(logMessage, LogType.Info);
                    continue;
                }

                foreach (string dir in subDirs)
                {
                    dirs.Push(dir);
                    AllDirectories.Add(Path.GetFullPath(dir));
                }
            }
            #endregion

            #region 디렉토리 상태 구성
            // Down-Top 순서로 구성
            foreach (string dir in Enumerable.Reverse(AllDirectories))
            {
                if (rand.Next(20) == 0) { Application.DoEvents(); }

                Statuses[dir] = Status.Unknown; // 기본값

                string[] files;
                string[] subdirectories;

                // 파일이 존재하는지 검색
                try
                {
                    files = Directory.GetFiles(dir);
                }
                // 접근이 불가능할 경우
                catch
                {
                    continue;
                }
                // 파일이 존재할 경우
                if (files.Length > 0)
                {
                    Statuses[dir] = Status.NotEmpty;
                    continue;
                }

                // 이하 파일이 존재하지 않을 경우 + 
                // 서브 디렉토리가 존재하는지 검색
                try
                {
                    subdirectories = Directory.GetDirectories(dir);
                }
                // 접근이 불가능할 경우
                catch
                {
                    continue;
                }
                // 서브 디렉토리가 존재할 경우
                if (subdirectories.Length > 0)
                {
                    // 서브 디렉토리 상태 조회
                    bool check;
                    try
                    {
                        check = subdirectories.All(sd => Statuses[sd] == Status.Empty || Statuses[sd] == Status.ContainsEmpty);
                    }
                    // 상태 조회 접근이 불가능할 경우
                    catch
                    {
                        continue;
                    }

                    // 서브 디렉토리가 모두 비어 있을 경우
                    if (check)
                    {
                        Statuses[dir] = Status.ContainsEmpty;
                    }
                    // 서브 디렉토리 중 하나 이상이 비어있지 않거나 접근이 불가능한 경우
                    else
                    {
                        Statuses[dir] = Status.NotEmpty;
                    }
                }
                // 서브 디렉토리가 존재하지 않을 경우
                else
                {
                    Statuses[dir] = Status.Empty;
                }
            } 
            #endregion
        }
    }
}
