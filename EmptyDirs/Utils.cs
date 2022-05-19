using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyDirs
{
    internal enum LogType
    {
        Info,
        Warning,
        Error
    }
    internal static class Utils
    {
        /// <summary>
        /// 로그 파일 설정 초기화
        /// </summary>
        public static void InitilizeLog()
        {
            Trace.Listeners.Clear();
            string logPath = Globals.LogFilePath;
            if (File.Exists(logPath))
            {
                File.Delete(logPath);
            }
            Trace.Listeners.Add(new TextWriterTraceListener(logPath));
            Trace.AutoFlush = true;
        }

        /// <summary>
        /// 로그 스트리밍에 기록
        /// </summary>
        /// <param name="logMessage">로그 메세지</param>
        /// <param name="logType">로그 타입</param>
        public static void WriteToLog(string logMessage, LogType logType)
        {
            Trace.WriteLine($"({DateTime.Now:yyyy-MM-dd HH:mm:ss}) [{logType}] {logMessage}");
        }
    }
}
