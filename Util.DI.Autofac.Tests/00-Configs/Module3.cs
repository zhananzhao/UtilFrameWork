using Autofac;

namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// 依赖注入配置3
    /// </summary>
    public class Module3 : ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="builder">容器生成器</param>
        protected override void Load( ContainerBuilder builder ) {
            base.Load( builder );
            builder.RegisterInstance( new Context() );// -----该方法也可
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterType<Operation3>().As<IOperation3>();
            builder.RegisterType<Operation4>().As<IOperation4>();
        }
    }
}
