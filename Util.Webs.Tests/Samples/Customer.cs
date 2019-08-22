namespace Util.Webs.Tests.Samples {
    /// <summary>
    /// 客户
    /// </summary>
    public class Customer {
        /// <summary>
        /// 客户名称,测试公共属性，且首字母大写
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 私有属性，应被忽略
        /// </summary>
        private string A { get; set; }
        /// <summary>
        /// 昵称，用来测试小写
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 函数，测试不能加引号
        /// </summary>
        [Json( false)]
        public string func { get; set; }
        /// <summary>
        /// 测试null
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 测试整型，不添加引号
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 测试布尔型
        /// </summary>
        public bool isShow { get; set; }

        /// <summary>
        /// 创建客户
        /// </summary>
        public static Customer Create() {
            return new Customer() {
                Name = "a",
                A = "1",
                nickname = "b",
                func = "c",
                Value = null,
                Date = Util.Conv.ToDate( "2012-1-1" ).ToString(),
                Age = 1,
                isShow = true
            };
        }
    }
}
