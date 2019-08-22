using System;
using Util.Domains;

namespace Util.Datas.Ef {
    /// <summary>
    /// 聚合根映射
    /// </summary>
    /// <typeparam name="TEntity">聚合根类型</typeparam>
    public abstract class AggregateMapBase<TEntity> : AggregateMapBase<TEntity, Guid> where TEntity : AggregateRoot<Guid> {
    }
}
