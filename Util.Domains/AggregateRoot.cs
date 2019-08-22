using System;

namespace Util.Domains {
    /// <summary>
    /// 聚合根
    /// </summary>
    public abstract class AggregateRoot : AggregateRoot<Guid> {
        /// <summary>
        /// 初始化聚合根
        /// </summary>
        /// <param name="id">标识</param>
        protected AggregateRoot( Guid id )
            : base( id ){
        }
    }
}
