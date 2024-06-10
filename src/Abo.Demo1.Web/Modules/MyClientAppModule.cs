using Abo.Demo1.Books;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Abo.Demo1.Web.Modules
{
    [DependsOn(
     typeof(AbpHttpClientModule), //用来创建客户端代理
     typeof(Demo1ApplicationContractsModule) //包含应用服务接口
     )]
    public class MyClientAppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //创建动态客户端代理
            context.Services.AddHttpClientProxies(
                typeof(Demo1ApplicationContractsModule).Assembly,
                remoteServiceConfigurationName: "Demo1"
            );
        }
    }
}
