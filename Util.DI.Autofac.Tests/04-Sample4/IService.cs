namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// 服务
    /// </summary>
    public interface IService : IDependency
    {
        /// <summary>
        /// 获取值
        /// </summary>
        string GetValue();
    }
}
