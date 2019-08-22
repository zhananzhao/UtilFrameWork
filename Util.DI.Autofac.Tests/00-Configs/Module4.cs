using Autofac;

namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// 依赖注入配置4
    /// </summary>
    public class Module4 : ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="builder">容器生成器</param>
        protected override void Load( ContainerBuilder builder ) {
            base.Load( builder );
            builder.RegisterType<Service>().As<IService>();
        }
    }
}
