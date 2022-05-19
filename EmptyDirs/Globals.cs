using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyDirs
{
    internal static class Globals
    {
        /// <summary>
        /// 현재 최상위 경로. 어플리케이션 실행 경로를 기본값으로 갖습니다.
        /// </summary>
        public static string CurrentRootPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        /// <summary>
        /// 로그 파일 경로
        /// </summary>
        public static string LogFilePath = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");


    }
}
