using System;
using System.Collections.Generic;
using Util.Domains;

namespace Util.Datas.Ef {
    /// <summary>
    /// 实体更改分组
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class ChangeGrouping<TEntity> : ChangeGrouping<TEntity, Guid> where TEntity : EntityBase<Guid> {
        /// <summary>
        /// 初始化实体更改分组
        /// </summary>
        /// <param name="entities">实体集合，一般由表示层传入</param>
        /// <param name="dbEntities">数据库中对应的实体集合</param>
        public ChangeGrouping( IEnumerable<TEntity> entities, IEnumerable<TEntity> dbEntities )
            : base( entities, dbEntities ) {
        }
    }
}
