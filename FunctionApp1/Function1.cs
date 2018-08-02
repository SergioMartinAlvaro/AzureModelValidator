using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Net;


namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {

            try
            {
                
                var data = await req.Content.ReadAsStringAsync();
                var authorization = JsonConvert.DeserializeObject<Person>(data);
                ModelValidator<Person> validator = new ModelValidator<Person>(authorization);
                bool a = validator.IsValidModel();
                return req.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }

        }
    }
}
