using Autofac;
using Framework.Logger;
using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac.Core;

namespace Framework.IoC
{
    public static class LocalServiceLocator
    {
        private static ContainerBuilder builder = new ContainerBuilder();
        private static IContainer container;

        /// <summary>
        /// 通过接口和接口实现注册对象
        /// </summary>
        /// <typeparam name="IT">接口</typeparam>
        /// <typeparam name="CT">接口实现</typeparam>
        /// <param name="lifeTime">生命周期</param>
        public static void Register<IT, CT>(EnumLifeTime lifeTime)
        {
            builder.RegisterType<CT>().As<IT>().SingleInstance();
            
            LoggerService.GetInstance().LogIoCStartEventToDb(typeof(CT).Name + "注册完成！");
        }

        /// <summary>
        /// 通过Modules注册对象
        /// </summary>
        /// <param name="assemblies"></param>
        public static void RegisterModules(params Assembly[] assemblies)
        {
            builder.RegisterAssemblyModules(assemblies);
        }

        /// <summary>
        /// 通过Lambda来注册对象,可以对服务添加AOP
        /// <para>exp:
        /// Register&lt;IMyService,MyService&gt;(() =&gt;{
        /// var item = new MyService();
        /// return item;
        /// });</para>
        /// </summary>
        /// <typeparam name="IT">接口</typeparam>
        /// <typeparam name="CT">接口实现</typeparam>
        /// <param name="lifeTime">生命周期</param>
        /// <param name="func">lambda表达式</param>
        /// <returns></returns>
        public static void Register<IT,CT>(EnumLifeTime lifeTime,Func<CT> func)
        {
            builder.Register(cc =>
            {
                return func();
            }).As<IT>().SingleInstance();
            LoggerService.GetInstance().LogIoCStartEventToDb(typeof(CT).Name + "注册完成！");
        }
        public static void SetContainer()
        {
            container = builder.Build();
        }

        public static T GetService<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// 按照最相近的构造函数来构造对象（通过构造函数的参数的参数名）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T GetService<T>(Dictionary<string,object> args)
        {
            var paramlist = new List<NamedParameter>();
            foreach(var i in args)
            {
                paramlist.Add(new NamedParameter(i.Key, i.Value));
            }
            return container.Resolve<T>(paramlist);
        }
        /// <summary>
        /// 按照最相近的构造函数来构造对象（通过构造函数的参数的类型）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T GetService<T>(Dictionary<Type,object> args)
        {
            var paramlist = new List<TypedParameter>();
            foreach(var i in args)
            {
                paramlist.Add(new TypedParameter(i.Key, i.Value));
            }
            return container.Resolve<T>(paramlist);
        }
    }
}
