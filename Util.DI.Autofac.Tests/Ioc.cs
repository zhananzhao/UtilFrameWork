using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Autofac;
using Autofac.Core;

namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// Autofac依赖注入
    /// </summary>
    public static class Ioc {
        private const string AssemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^NSubstitute|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Telerik|^Iesi|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";
        
        /// <summary>
        /// 初始化容器
        /// </summary>
        static Ioc() {
           // Container.Init(null, new Module1(), new Module2(), new Module3(), new Module4() );

        }
        public static void RegisterTypes(IEnumerable<Assembly> assemblies, ContainerBuilder builder)
        {
            var typeBase = typeof(IDependency);
            builder.RegisterAssemblyTypes(FilterSystemAssembly(assemblies))
                .Where(t => typeBase.IsAssignableFrom(t) && t != typeBase && !t.IsAbstract)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
        private static Assembly[] FilterSystemAssembly(IEnumerable<Assembly> assemblies)
        {
            return assemblies
                .Where(assembly => !Regex.IsMatch(assembly.FullName, AssemblySkipLoadingPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled))
                .ToArray();
        }
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public static T Create<T>() {
            return Container.Create<T>();
        }

        /// <summary>
        /// 为测试环境注册依赖
        /// </summary>
        /// <param name="modules">依赖配置</param>
        public static void RegisterTest(params IModule[] modules)
        {
            var path = Sys.GetPhysicalPath(AppDomain.CurrentDomain.BaseDirectory);
            var assemblies = Reflection.GetAssemblies(path);
            Container.Init(builder => RegisterTypes(assemblies, builder), modules);
        }
    }
}
