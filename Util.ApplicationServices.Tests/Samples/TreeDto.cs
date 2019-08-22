using System.Collections.Generic;

namespace Util.ApplicationServices.Tests.Samples {
    public class TreeDto : DtoBase {
        public string Path { get; set; }
        public int Level { get; set; }
        public int? ParentId { get; set; }
        public int? SortId { get; set; }
        public byte[] Version { get; set; }

        /// <summary>
        /// 创建空集合
        /// </summary>
        public static List<TreeDto> CreateEmptyList() {
            return new List<TreeDto>();
        }
    }
}
