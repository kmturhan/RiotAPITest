using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using RiotApiTest.Models;
namespace RiotApiTest.Controllers
{
    public class HomeController : Controller
    {

        string Key = "RGAPI-53c1f8b1-7a73-4f2f-8bc1-d6aa63e61acb";



        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> UserInfo(string Name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://tr1.api.riotgames.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Riot-Token", Key);
                HttpResponseMessage ResponseUI = await client.GetAsync("lol/summoner/v4/summoners/by-name/" + Name);
                if (ResponseUI.IsSuccessStatusCode)
                {
                    var jsonUIData = JsonConvert.DeserializeObject<Root.UserInformation>(ResponseUI.Content.ReadAsStringAsync().Result);
                    
                    //Matches List 
                    //TO DO 
                    //Aralık olarak sadece 100 maç listeleniyor. Toplam maç sayısı değeri servisten dönüyor. Buna göre begin ve end index verebiliyorum ama bu sayılar arasındaki fark max 100 olmalı. Burası basit bir düşün. Böylece tüm maçları alabilirim.
                    HttpResponseMessage ResponseMatchesList = await client.GetAsync("lol/match/v4/matchlists/by-account/" + jsonUIData.accountId);
                    if (ResponseMatchesList.IsSuccessStatusCode)
                    {
                        var jsonUMData = JsonConvert.DeserializeObject<Root.UserMatches.GeneralMatchesInfo>(ResponseMatchesList.Content.ReadAsStringAsync().Result);
                        return View("UserInformation", new Root() { UI = jsonUIData, UM = jsonUMData });
                    }
                    
                }
            }
            return Json("Error GetName");
        }
        public async Task<ActionResult> MatchInfo(int MatchID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://tr1.api.riotgames.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Riot-Token", Key);
                HttpResponseMessage ResponseMatchDetail = await client.GetAsync("/lol/match/v4/matches/" + MatchID);
                if (ResponseMatchDetail.IsSuccessStatusCode)
                {
                    var jsonMatchDetail = JsonConvert.DeserializeObject(ResponseMatchDetail.Content.ReadAsStringAsync().Result);
                    return Content(jsonMatchDetail.ToString(), "application/json");
                }
            }
            return Json("Error MatchInfo",JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> MatchTimeline(int MatchID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://tr1.api.riotgames.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Riot-Token", Key);
                HttpResponseMessage ResponseMatchDetail = await client.GetAsync("/lol/match/v4/timelines/by-match/" + MatchID);
                if (ResponseMatchDetail.IsSuccessStatusCode)
                {
                    var jsonMatchDetail = JsonConvert.DeserializeObject(ResponseMatchDetail.Content.ReadAsStringAsync().Result);
                    return Content(jsonMatchDetail.ToString(), "application/json");
                }
            }
            return Json("Error MatchTimelines", JsonRequestBehavior.AllowGet);
        }
    }
}