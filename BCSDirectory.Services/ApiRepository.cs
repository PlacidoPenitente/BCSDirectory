using BCSDirectory.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace BCSDirectory.Services
{
    public class ApiRepository<T>
        : IApiRepository<T> where T : class
    {
        private const string ApiUrl = "https://bcsdirectoryapi.gear.host/api";
        public void ApiAdd(T value)
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

        public T ApiFind(int id)
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

        public IEnumerable<T> ApiGetAll()
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

        public void ApiUpdate(int id, T value)
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
    }
}
