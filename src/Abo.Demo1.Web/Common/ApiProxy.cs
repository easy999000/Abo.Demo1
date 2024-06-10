
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Abo.Demo1.Web.Common
{
    public class ApiProxy
    {
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;
        private HttpClient HttpClient = new HttpClient();

        public ApiProxy(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public string GetApiProxyJs()
        {
            var romoteServices = GetRemoteServices();

            var res = "";
            var tasks = new List<Task<string>>();

            foreach (var item in romoteServices)
            {
                var task = BuildProxyJs(item);
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            foreach (var item in tasks)
            {
                res += "\r\n";
                res += item.Result;
            }

            return res;

        }
        private List<(string name, string url)> GetRemoteServices()
        {
            var res = new List<(string name, string uri)>();
            var remotes = Configuration.GetSection("RemoteServices");
            if (remotes == null)
            {
                return res;
            }

            var childs = remotes.GetChildren();

            foreach (var item in childs)
            {
                var Key = item.Key;
                var BaseUrl = item.GetSection("BaseUrl")?.Value;
                if (!string.IsNullOrWhiteSpace(BaseUrl))
                {
                    res.Add((Key, BaseUrl));
                }

            }

            return res;
        }

        private async Task<string> BuildProxyJs((string name, string url) service)
        {
            var res = "";

            var serviceJs = await GetRemoteServiceJs(service.url);
            res = MakeProxyJs(serviceJs, service.url);
            return res;
        }

        private string MakeProxyJs(string serviceJs, string serviceHost)
        {
            if (string.IsNullOrWhiteSpace(serviceJs))
            {
                return "";
            }
            string pattern = @"[^\w_$]abp.appPath[^\w_$]";

#if DEBUG
            var matchs = System.Text.RegularExpressions.Regex.Matches(serviceJs, pattern);
#endif

            var replaceUrl = serviceHost.Trim();
            if (!replaceUrl.EndsWith('/'))
            {
                replaceUrl += '/';
            }
            replaceUrl = $"'{replaceUrl}'";


            var resJs = System.Text.RegularExpressions.Regex.Replace(serviceJs, pattern, replaceUrl);

            return resJs;
        }

        private async Task<string> GetRemoteServiceJs(string url)
        {
            string jsUrl = Path.Combine(url, "Abp/ServiceProxyScript");

            return await HttpClient.GetStringAsync(jsUrl);

        }

    }
}
