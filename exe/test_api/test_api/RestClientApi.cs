
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;


namespace test_api
{
    public class RestClientAPI
    {
        private string _ClassName { get; set; }

        public RestClientAPI(string ClassName)
        {
            this._ClassName = ClassName;
        }

        public RestClientAPI()
        {
        }

        public string Get(string className,string key)
        {
            string _ret = "";
                                
            wsQuery json_query = new wsQuery();
            json_query.operation = "core/get";
            json_query.@class = className;
            json_query.key = key;

            var json_data = Newtonsoft.Json.JsonConvert.SerializeObject(json_query);
            _ret = this.CallWebService("get",className,json_data);

            return _ret;    
        }

        public string Create(string ClassName)
        {
            string _ret = "";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("http://cmdb/itop2/webservices/rest.php?version=1.3");
            client.Authenticator = new HttpBasicAuthenticator("admin", "itop");
            var request = new RestRequest(Method.POST);
            string auth_user = "admin";
            request.AddParameter("auth_user", auth_user);
            string auth_pwd = "itop";
            request.AddParameter("auth_pwd", auth_pwd);

            Caller_id c = new Caller_id();
            c.name = "monet";
            c.first_name = "claude";

            Fields f = new Fields();
            f.org_id = "SELECT Organization WHERE name = \"Demo\"";
            f.title = "Houston, got a problem!";
            f.description = "The fridge is empty";
            f.caller_id = c;

            wsQuery json_query = new wsQuery();
            json_query.operation = "core/create";
            json_query.comment = " test api";
            json_query.@class = ClassName;
            json_query.output_fields = "id, friendlyname";
            json_query.fields = f;


            var json_data = Newtonsoft.Json.JsonConvert.SerializeObject(json_query);
            request.AddParameter("json_data", json_data);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _ret = response.Content;
            }
            else
            {
                //todo
                _ret = response.Content;
            }


            wsResponse Response = JsonConvert.DeserializeObject<wsResponse>(_ret);

            return _ret;
        }

        public string List_operations()
        {
            string _ret = "";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("http://cmdb/itop2/webservices/rest.php?version=1.3");
            client.Authenticator = new HttpBasicAuthenticator("admin", "itop");
            var request = new RestRequest(Method.POST);
            string auth_user = "admin";
            request.AddParameter("auth_user", auth_user);
            string auth_pwd = "itop";
            request.AddParameter("auth_pwd", auth_pwd);
            wsQuery json_query = new wsQuery();
            json_query.operation = "list_operations";
            var json_data = Newtonsoft.Json.JsonConvert.SerializeObject(json_query);
            request.AddParameter("json_data", json_data);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _ret = response.Content;
            }
            else
            {
                //todo
                _ret = response.Content;
            }


            wsResponse Response = JsonConvert.DeserializeObject<wsResponse>(_ret);

            return _ret;
        }

        private string CallWebService(string operation, string className, string json_data)
        {
            string _ret = "";

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("http://cmdb/itop2/webservices/rest.php?version=1.3");
            client.Authenticator = new HttpBasicAuthenticator("admin", "itop");
            var request = new RestRequest(Method.POST);
            string auth_user = "admin";
            request.AddParameter("auth_user", auth_user);
            string auth_pwd = "itop";
            request.AddParameter("auth_pwd", auth_pwd);

            request.AddParameter("json_data", json_data);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _ret = response.Content;
            }
            else
            {
                //todo
                _ret = response.Content;
            }


            //JObject j = new JObject(_ret);
            
            

            dynamic a = JsonConvert.DeserializeObject<dynamic>(_ret);

            parseJsonResponse(_ret);

            wsResponse Response = JsonConvert.DeserializeObject<wsResponse>(_ret);

            return _ret;
            

        }

        private void parseJsonResponse(string data)
        {
            IDictionary<string, JToken> Jsondata = JObject.Parse(data);
            foreach (KeyValuePair<string, JToken> element in Jsondata)
            {
                string innerKey = element.Key;
                if (element.Value is JArray)
                {
                    // Process JArray
                }
                else if (element.Value is JObject)
                {
                    // Process JObject
                    if (innerKey == "objects")
                    { 
                        string data2 = element.Value.ToString();
                        parseJsonResponse(data2);
                    }
                }
            }

        }
    }
}
