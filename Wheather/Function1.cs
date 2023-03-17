using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wheather.Models;
using Wheather.Services;

namespace Wheather
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //var result;
            //try
            //{
                log.LogInformation("C# HTTP trigger function processed a request.");

                string rawJsonValue = await new StreamReader(req.Body).ReadToEndAsync();
                log.LogInformation($"request : {rawJsonValue}");

            
                RequestModel request = JsonConvert.DeserializeObject<RequestModel>(rawJsonValue);
               var  result = await WheatherService.Getdata(request);
                
            //}
            //catch (Exception ex) 
            //{ 
            //}

            return new OkObjectResult(result);


        }
    }
}
