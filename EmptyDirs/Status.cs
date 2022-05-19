using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyDirs
{
    /// <summary>
    /// 디렉토리의 상태
    /// </summary>
    internal enum Status
    {
        /// <summary>
        /// 디렉토리의 상태를 알수 없거나 접근이 불가능
        /// </summary>
        Unknown,
        /// <summary>
        /// 파일도 없고, 서브 디렉토리도 없음
        /// </summary>
        Empty,
        /// <summary>
        /// 파일이 없고, 서브 디렉토리가 있으나 모두 비어 있음
        /// </summary>
        ContainsEmpty,
        /// <summary>
        /// 파일이 있거나, 서브 디렉토리 중 하나 이상이 비어 있지 않음
        /// </summary>
        NotEmpty
    }
}
