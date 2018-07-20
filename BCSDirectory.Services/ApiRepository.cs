using BCSDirectory.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BCSDirectory.Services
{
    public class ApiRepository<T> 
        : IApiRepository<T> where T : class
    {
        private const string ApiUrl = "https://bcsdirectoryapi.gear.host/api";
        public virtual void ApiAdd(T value)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                string jsonString = serializer.Serialize(value);

                var request = (HttpWebRequest)WebRequest.Create($"{ApiUrl}/{typeof(T).Name}");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = jsonString.Length;

                using (var stream = new StreamWriter(request.GetRequestStream()))
                {
                    stream.Write(jsonString);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var stream = new StreamReader(httpResponse.GetResponseStream()))
                {
                    stream.ReadToEnd();
                }
            }
            catch
            {
                throw;
            }
        }
        
        public virtual T ApiFind(int? id)
        {
            try
            {
                using (var client = new WebClient())
                {
                    return JsonConvert.DeserializeObject<T>(client.DownloadString($"{ApiUrl}/{typeof(T).Name}/{id}"));
                }
            }
            catch
            {
                throw;
            }
        }
        
        public virtual IEnumerable<T> ApiGetAll()
        {
            try
            {
                using (var client = new WebClient())
                {
                    return JsonConvert.DeserializeObject<List<T>>(client.DownloadString($"{ApiUrl}/{typeof(T).Name}"));
                }
            }
            catch
            {
                throw;
            }
        }

        public virtual void ApiUpdate(int? id, T value)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                string jsonString = serializer.Serialize(value);

                var request = (HttpWebRequest)WebRequest.Create($"{ApiUrl}/{typeof(T).Name}/{id}");
                request.Method = "PUT";
                request.ContentType = "application/json";
                request.ContentLength = jsonString.Length;

                using (var stream = new StreamWriter(request.GetRequestStream()))
                {
                    stream.Write(jsonString);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var stream = new StreamReader(httpResponse.GetResponseStream()))
                {
                    stream.ReadToEnd();
                }
            }
            catch
            {
                throw;
            }
        }

        public void ApiDelete(int? id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:1379/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    using (var response = client.DeleteAsync($"{ApiUrl}/{typeof(T)}/{id}").Result)
                    {

                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
