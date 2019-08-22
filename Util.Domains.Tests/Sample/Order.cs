using System;
using System.Collections.Generic;
using System.Linq;

namespace Util.Domains.Tests.Sample {
    /// <summary>
    /// 订单
    /// </summary>
    public class Order : AggregateRoot {
        /// <summary>
        /// 初始化订单
        /// </summary>
        public Order() 
            : this( Guid.NewGuid() ){
        }

        /// <summary>
        /// 初始化订单
        /// </summary>
        /// <param name="id">订单编号</param>
        public Order( Guid id )
            : base( id ) {
            Items = new HashSet<OrderItem>();
        }

        /// <summary>
        /// 订单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 订单项集合
        /// </summary>
        public virtual ICollection<OrderItem> Items { get; set; }

        /// <summary>
        /// 添加订单项
        /// </summary>
        /// <param name="item">订单项</param>
        public void Add( OrderItem item ) {
            item.OrderId = Id;
            Items.Add( item );
        }

        /// <summary>
        /// 添加订单项
        /// </summary>
        /// <param name="items">订单项</param>
        public void Add( IEnumerable<OrderItem> items ) {
            foreach( var item in items ) {
                Add( item );
            }
        }

        /// <summary>
        /// 修改订单项
        /// </summary>
        /// <param name="items">订单项</param>
        public void Update( IEnumerable<OrderItem> items ) {
            foreach ( var item in items ) {
                var dbItem = Items.FirstOrDefault( t => t.Id == item.Id );
                if( dbItem == null )
                    continue;
                dbItem.Merge( item );
            }
        }

        /// <summary>
        /// 移除订单项
        /// </summary>
        /// <param name="item">订单项</param>
        public void Remove( OrderItem item ) {
            Items.Remove( item );
        }

        /// <summary>
        /// 移除订单项
        /// </summary>
        /// <param name="items">订单项</param>
        public void Remove( IEnumerable<OrderItem> items ) {
            IList<OrderItem> orderItems = items.ToList();
            for ( int i = 0; i < orderItems.Count; i++ ) {
                Remove( orderItems[i] );
            }
        }

        /// <summary>
        /// 合并值
        /// </summary>
        /// <param name="order">订单</param>
        public void Merge( Order order ) {
            this.Name = order.Name;
        }
    }
}
