namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// 上下文
    /// </summary>
    public class Context {
        /// <summary>
        /// 初始化上下文
        /// </summary>
        public Context() {
            Value = Util.Str.GenerateCodeBy16();
        }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
