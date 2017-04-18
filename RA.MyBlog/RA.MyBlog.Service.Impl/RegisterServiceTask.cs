using Autofac;
using Framework.IoC;
using MyBlog.Service.Interface;

namespace MyBlog.Service.Impl
{
    public class RegisterServiceTask : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyBlogService>().As<IMyBlogService>().SingleInstance();
        }
    }
}
