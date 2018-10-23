using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace BasicInfo
{
    class DetailsAboutIP
    {


        public async static Task<RootObject> ShowTemp(string adresa)
        {
            
            var http = new HttpClient();
            var url = String.Format("http://ip-api.com/json/" + adresa);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var ser = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)ser.ReadObject(ms);

            return data;
        }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public string @as { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string countryCode { get; set; }
        [DataMember]
        public string isp { get; set; }
        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lon { get; set; }
        [DataMember]
        public string org { get; set; }
        [DataMember]
        public string query { get; set; }
        [DataMember]
        public string region { get; set; }
        [DataMember]
        public string regionName { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string timezone { get; set; }
        [DataMember]
        public string zip { get; set; }
    }
}