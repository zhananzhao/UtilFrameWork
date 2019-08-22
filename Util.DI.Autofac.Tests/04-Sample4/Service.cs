namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// 服务
    /// </summary>
    public class Service : IService{
        /// <summary>
        /// 初始化服务
        /// </summary>
        public Service( IOperation operation, IOperation2 operation2, IOperation3 operation3, IOperation4 operation4 ) {
            Operation = operation;
            Operation2 = operation2;
            Operation3 = operation3;
            Operation4 = operation4;
        }

        /// <summary>
        /// 操作
        /// </summary>
        public IOperation Operation { get; set; }

        /// <summary>
        /// 操作2
        /// </summary>
        public IOperation2 Operation2 { get; set; }

        /// <summary>
        /// 操作3
        /// </summary>
        public IOperation3 Operation3 { get; set; }

        /// <summary>
        /// 操作4
        /// </summary>
        public IOperation4 Operation4 { get; set; }

        /// <summary>
        /// 获取值
        /// </summary>
        public string GetValue() {
            return string.Empty;
        }
    }
}
