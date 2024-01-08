using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Süper_Lig_Forma_İstatistikleri.Entities.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace Süper_Lig_Forma_İstatistikleri.UI.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

      

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7123/api/Matches");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Match>>(jsonData);
                return View(values);
            }
            return View();
        }
        private async Task<List<SelectListItem>> GetTeams()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7123/api/Teams");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Team>>(jsonData);
            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.TeamName,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            return brandValues;
        }


        // GET: Matches/Details/5
        [System.Web.Mvc.AcceptVerbs(System.Web.Mvc.HttpVerbs.Get)]
        public async Task<List<SelectListItem>> GetKitsByTeam(int id,string type)
        {
            //Your Code For Getting Physicans Goes Here
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7123/api/Jerseys/{type}?teamid=" + id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Jersey>>(jsonData);
            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " "+ x.Body+" "+" "+x.Shorts+" "+x.Socks,
                                                    Value = x.Id.ToString(),

                                                }).ToList();

            return brandValues;
        }


        // GET: Matches/Create
        public async Task<IActionResult > Create()
        {
            List<SelectListItem> teams = await GetTeams();
            ViewBag.teams = teams;
            ViewBag.referees = await GetKitsByTeam(21, "team");
           // ViewBag.kits = teams;

            return View();
        }

        public async Task<Match> Maçkolik(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7123/api/Mackoliks/get?adres={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Match>(jsonData);

                

                return values;
            }

            // ViewBag.kits = teams;

            return null;
        }
        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HomeTeamId,AwayTeamId,HomeTeamJerseyId,HomeTeamJerseyGKId,RefereeJerseyId,AwayTeamJerseyId,AwayTeamJerseyGKId,HomeMS,AwayMS,Date,MainId,Week,RefereeId,Maçkolik")] Match match)
        {
            var matchtemp = await Maçkolik(match.Maçkolik);
            match.Date = matchtemp.Date;
            match.HomeMS = matchtemp.HomeMS;
            match.AwayMS= matchtemp.AwayMS;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(match);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7123/api/Matches", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(match);


        }

        //// GET: Matches/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{


        //    return View(match);
        //}

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,HomeTeamId,AwayTeamId,HomeTeamJerseyId,HomeTeamJerseyGKId,RefereeJerseyId,AwayTeamJerseyId,AwayTeamJerseyGKId,HomeMS,AwayMS,Date,MainId,Week,RefereeId")] Match match)
        //{



        //}

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7123/api/Matches/Delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();


        }

    }
}
