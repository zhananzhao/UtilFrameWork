namespace Util.Domains.Tests.Sample {
    /// <summary>
    /// 部门
    /// </summary>
    public class Department : AggregateRoot<string> {
        /// <summary>
        /// 初始化部门
        /// </summary>
        public Department() 
            : this( null ){
        }

        /// <summary>
        /// 初始化部门
        /// </summary>
        /// <param name="id">部门编号</param>
        public Department( string id )
            : base( id ) {
            Address = new Address( "", "" );
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// 获取部门
        /// </summary>
        public static Department GetDepartment() {
            return new Department( Str.GenerateCodeBy16() ) {
                Name = "测试部门"
            };
        }

        /// <summary>
        /// 复制一个新部门
        /// </summary>
        public Department Copy() {
            return new Department( Id ) { Name = Name };
        }
    }
}
