using System.Collections.Generic;
using System.Web.Http;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Client;
using System.Fabric;
using System.Linq;
using SFSpeedTest.Common;
using System.Threading.Tasks;


namespace SFSpeedTest.API.Controllers
{
    public class ValuesController : ApiController
    {
        private IService _rentalService = ServiceProxy.Create<IService>(new System.Uri(FabricRuntime.GetActivationContext().ApplicationName + "/Service"), new ServicePartitionKey(1), TargetReplicaSelector.Default);

        // GET api/values 
        public async Task<string> Get()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            var lastItem = await _rentalService.GetLastItem();
            sw.Stop();
            var sb = new System.Text.StringBuilder();
            foreach(var i in lastItem)
            {
                sb.AppendLine($"{i.FirstName} {i.LastName}");
            }
            return $"Got {sb.ToString()} in {sw.Elapsed.TotalMilliseconds} milliseconds";
        }

        // GET api/values/5 
        public async Task<string> Get(int id)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            for(int i = 0; i<id; i++)
            {
                var model = new MyModel
                {
                    Id = 1,
                    FirstName = "John",
                    MiddleName = "L",
                    LastName = "Doe",
                    Age = 20
                };
                await _rentalService.AddItem(model);
            }
            return $"Added {id} items in {sw.Elapsed.Seconds} seconds.";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
