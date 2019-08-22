namespace Util.Domains.Tests.Sample {
    /// <summary>
    /// 空客户
    /// </summary>
    public class NullCustomer : Customer {
        /// <summary>
        /// 空对象
        /// </summary>
        public override bool IsNull() {
            return true;
        }
    }
}
