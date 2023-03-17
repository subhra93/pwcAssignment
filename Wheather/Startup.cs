using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheather.Services;

[assembly: FunctionsStartup(typeof(Wheather.Startup))]
namespace Wheather
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //throw new NotImplementedException();
            builder.Services.AddSingleton<WheatherService>();
        }
    }
}
