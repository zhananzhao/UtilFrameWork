namespace Util.Domains {
    /// <summary>
    /// 聚合根
    /// </summary>
    public interface IAggregateRoot : IEntity {
        
    }

    /// <summary>
    /// 聚合根
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
    public interface IAggregateRoot<out TKey> : IEntity<TKey>, IAggregateRoot {
    }
}
