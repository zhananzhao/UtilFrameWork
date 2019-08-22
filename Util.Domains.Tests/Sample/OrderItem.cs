using System;

namespace Util.Domains.Tests.Sample {
    /// <summary>
    /// 订单项目
    /// </summary>
    public class OrderItem : EntityBase{
        /// <summary>
        /// 初始化订单项目
        /// </summary>
        public OrderItem() 
            : base( Guid.NewGuid() ){
        }

        /// <summary>
        /// 初始化订单项目
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="orderItemId">订单项编号</param>
        public OrderItem( Guid orderId, Guid orderItemId )
            : base( orderItemId ) {
            OrderId = orderId;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public Guid OrderId { get; internal set; }

        /// <summary>
        /// 合并值
        /// </summary>
        /// <param name="item">订单项</param>
        public void Merge( OrderItem item ) {
            this.Name = item.Name;
        }
    }
}
