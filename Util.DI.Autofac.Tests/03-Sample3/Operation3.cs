namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// 操作3
    /// </summary>
    public class Operation3 : IOperation3{
        /// <summary>
        /// 初始化操作3
        /// </summary>
        /// <param name="context">上下文</param>
        public Operation3( Context context ) {
            Context = context;
        }

        /// <summary>
        /// 上下文
        /// </summary>
        private Context Context { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        /// <returns></returns>
        public string Value() {
            return Context.Value;
        }
    }
}
