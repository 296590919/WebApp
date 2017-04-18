using Autofac;
using Cooperation.Service.Impl.api;
using Cooperation.Service.Impl.Login;
using Cooperation.Service.Interface.api;
using Cooperation.Service.Interface.Login;
using Framework.IoC;

namespace Cooperation.Service.Impl
{
    public class RegisterServiceTask : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PassportService>().As<IPassportService>().SingleInstance();
            builder.RegisterType<ApiService>().As<IApiService>().SingleInstance();
        }
    }
}
