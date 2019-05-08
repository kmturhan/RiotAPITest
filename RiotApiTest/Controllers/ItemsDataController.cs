using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiotApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace RiotApiTest.Controllers
{
    public class ItemsDataController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ItemList()
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.GetEncoding("UTF-8");
            var json = wc.DownloadString("http://ddragon.leagueoflegends.com/cdn/9.9.1/data/tr_TR/item.json");
 
            foreach (var item in JObject.Parse(json).SelectToken("data").Children())
            {
                Items data = JsonConvert.DeserializeObject<Items>(item.First.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json) };
        }
    }
}
