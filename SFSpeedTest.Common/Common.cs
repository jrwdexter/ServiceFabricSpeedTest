using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSpeedTest.Common
{
    public class MyModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public interface IService : Microsoft.ServiceFabric.Services.Remoting.IService
    {
        Task<bool> AddItem(MyModel myModel);
        Task<IEnumerable<MyModel>> GetLastItem();
    }
}
