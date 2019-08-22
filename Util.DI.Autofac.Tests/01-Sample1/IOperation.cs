namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// 操作
    /// </summary>
    public interface IOperation : IDependency
    {
        /// <summary>
        /// 获取值
        /// </summary>
        int GetNumber();
    }
}
