using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_api
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            RestClientAPI _api = new RestClientAPI("Person");
            //Get

            
            result = _api.Get("Contact", "SELECT Contact WHERE id > 0");
            result = _api.Get("Contact", "1");
            result = _api.Get("Person", "1");
            //result = _api.Get("Person", "SELECT Person WHERE org_id=2");
            //result = _api.Get("Team", "1");

            _api.Get("UserRequest","1");


            //_api.Create("UserRequest");
        }
    }
}
