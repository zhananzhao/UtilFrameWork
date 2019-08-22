using System;
using System.Collections.Generic;

namespace Util.Domains.Tests.Sample {
    /// <summary>
    /// 员工
    /// </summary>
    public class Employee : AggregateRoot {
        /// <summary>
        /// 初始化员工
        /// </summary>
        public Employee()
            : this( Guid.NewGuid() ) {
        }

        /// <summary>
        /// 初始化员工
        /// </summary>
        /// <param name="id">员工编号</param>
        public Employee( Guid id )
            : base( id ) {
            Customers = new HashSet<Customer>();
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 客户集合
        /// </summary>
        public virtual ICollection<Customer> Customers { get; set; }

        /// <summary>
        /// 获取员工
        /// </summary>
        public static Employee GetEmployee() {
            return new Employee() {
                Name = "李四"
            };
        }

        /// <summary>
        /// 获取员工2
        /// </summary>
        public static Employee GetEmployee2() {
            return new Employee() {
                Name = "王二麻子"
            };
        }

        /// <summary>
        /// 复制一个新员工
        /// </summary>
        public Employee Copy() {
            return new Employee( Id ) { Name = Name };
        }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "Id:" + Id + "," );
            AddDescription( "姓名", Name );
        }
    }
}
