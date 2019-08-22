using System;

namespace Util.Domains.Tests.Sample {
    /// <summary>
    /// 树型对象，Guid标识类型
    /// </summary>
    public class GuidTreeObject  : TreeEntityBase<GuidTreeObject> {
        /// <summary>
        /// 初始化树型对象
        /// </summary>
        public GuidTreeObject( Guid id ) 
            : base( id,"",0 ){
        }

        /// <summary>
        /// 初始化树型对象
        /// </summary>
        public GuidTreeObject( Guid id,string path )
            : base( id, path, 0 ) {
        }
    }
}
