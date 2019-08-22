namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// 操作
    /// </summary>
    public class Operation2 : IOperation2{
        /// <summary>
        /// 初始化操作
        /// </summary>
        /// <param name="operation">操作</param>
        public Operation2( IOperation operation ) {
            Operation = operation;
        }

        /// <summary>
        /// 操作
        /// </summary>
        private IOperation Operation { get; set; }

        /// <summary>
        /// 获取值
        /// </summary>
        public int GetNumber() {
            return Operation.GetNumber();
        }
    }
}
