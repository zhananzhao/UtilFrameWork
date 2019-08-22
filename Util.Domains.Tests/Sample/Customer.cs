using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Util.Domains.Tests.Sample {
    /// <summary>
    /// 客户
    /// </summary>
    public class Customer : AggregateRoot<int> {
        /// <summary>
        /// 初始化客户
        /// </summary>
        public Customer() 
            : this( 0 ){
        }

        /// <summary>
        /// 初始化客户
        /// </summary>
        /// <param name="customerId">客户编号</param>
        public Customer( int customerId )
            : base( customerId ) {
        }

        /// <summary>
        /// 空客户
        /// </summary>
        public static Customer Null {
            get { return new NullCustomer(); }
        }

        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// 员工编号,重点：必须是可空类型，否则不能使用HasOptional映射
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( TestDomainResource ), ErrorMessageResourceName = "CustomerNameIsEmpty" )]
        public string Name { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        [Required( ErrorMessage = "英文名不能为空" )]
        public string EnglishName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( TestDomainResource ), ErrorMessageResourceName = "AgeIsEmpty" )]
        public int? Age { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public int Tel { get; set; }

        /// <summary>
        /// double数值
        /// </summary>
        public double Db { get; set; }

        /// <summary>
        /// 可空double数值
        /// </summary>
        public double? NullableDb { get; set; }

        /// <summary>
        /// decimal数值
        /// </summary>
        public decimal Dec { get; set; }

        /// <summary>
        /// 可空decimal数值
        /// </summary>
        public decimal? NullableDec { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 可空出生年月
        /// </summary>
        public DateTime? NullableBirthday { get; set; }

        /// <summary>
        /// 输出对象状态
        /// </summary>
        public override string ToString() {
            Str result = new Str();
            result.AddLine( "Id : {0}", Id );
            result.AddLine( "Name : {0}", Name );
            return result.ToString();
        }

        /// <summary>
        /// 获取客户实例
        /// </summary>
        public static Customer GetCustomer() {
            return new Customer(1) {
                Name = "张三",
                EnglishName = "Zs",
                Age = 10,
                Tel = 1,
                Db = 1.1,
                NullableDb = 1.1,
                Dec = 1.1M,
                NullableDec = 1.1M,
                Birthday = DateTime.Parse( "2000-5-2 10:10:10" ),
                NullableBirthday = DateTime.Parse( "2000-5-2 10:10:10" ),
            };
        }

        /// <summary>
        /// 获取客户A
        /// </summary>
        public static Customer GetCustomerA() {
            var customer = GetCustomer();
            customer.Name = "A";
            customer.EnglishName = "A";
            customer.Age = 10;
            customer.Tel = 1;
            customer.Db = 1.1;
            customer.NullableDb = 1.1;
            customer.Dec = 1.1M;
            customer.NullableDec = 1.1M;
            customer.Birthday = Date1;
            customer.NullableBirthday = Date1;
            return customer;
        }

        /// <summary>
        /// 日期1
        /// </summary>
        public static DateTime Date1 {
            get { return Conv.ToDate( "2000-6-1 10:10:10" ); }
        }

        /// <summary>
        /// 获取客户B
        /// </summary>
        public static Customer GetCustomerB() {
            var customer = GetCustomer();
            customer.Name = "B";
            customer.EnglishName = "B";
            customer.Age = 20;
            customer.Tel = 3;
            customer.Db = 10.1;
            customer.NullableDb = 10.1;
            customer.Dec = 10.1M;
            customer.NullableDec = 10.1M;
            customer.Birthday = Date2;
            customer.NullableBirthday = Date2;
            return customer;
        }

        /// <summary>
        /// 日期2
        /// </summary>
        public static DateTime Date2 {
            get { return Conv.ToDate( "2005-1-1 10:10:10" ); }
        }

        /// <summary>
        /// 获取客户C
        /// </summary>
        public static Customer GetCustomerC() {
            var customer = GetCustomer();
            customer.Name = "C";
            customer.EnglishName = "C";
            customer.Age = 30;
            customer.Tel = 2;
            customer.Db = 21.1;
            customer.NullableDb = 21.1;
            customer.Dec = 21.1M;
            customer.NullableDec = 21.1M;
            customer.Birthday = Date3;
            customer.NullableBirthday = Date3;
            return customer;
        }

        /// <summary>
        /// 日期3
        /// </summary>
        public static DateTime Date3 {
            get { return Conv.ToDate( "2010-3-1 10:10:10" ); }
        }

        /// <summary>
        /// 获取客户集合
        /// </summary>
        public static List<Customer> GetCustomers() {
            return new List<Customer>() {
                GetCustomerA(),
                GetCustomerB(),
                GetCustomerC()
            };
        }
    }
}
