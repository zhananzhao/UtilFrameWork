using Util.Domains;

namespace Util.ApplicationServices.Tests.Samples {
    /// <summary>
    /// 树型实体
    /// </summary>
    public class TreeEntity : TreeEntityBase<TreeEntity, int, int?> {
        /// <summary>
        /// 初始化字典
        /// </summary>
        public TreeEntity()
            : this( 0, "", 0 ) {
        }

        /// <summary>
        /// 初始化字典
        /// </summary>
        /// <param name="id">字典标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        public TreeEntity( int id, string path, int level )
            : base( id, path, level ) {
        }

        /// <summary>
        /// 创建测试实体
        /// </summary>
        public static TreeEntity Create() {
            return new TreeEntity( 1, "1,", 1 ) { SortId = 1,Version = new byte[]{1}};
        }
    }
}
