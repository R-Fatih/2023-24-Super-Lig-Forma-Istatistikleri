using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Süper_Lig_Forma_İstatistikleri.Entities.Entities;
using Data;
using Newtonsoft.Json.Linq;

namespace Süper_Lig_Forma_İstatistikleri.UI.Controllers
{
    public class JerseysController : Controller
    {


		private readonly IHttpClientFactory _httpClientFactory;

		public JerseysController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7123/api/Jerseys/GetJerseysWithTeam");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<Jersey>>(jsonData);
				return View(values);
			}
			return View();
		}

		// GET: Jerseys/Details/5
		public async Task<IActionResult> Details(int? id)
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7123/api/Jerseys/"+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<Jersey>(jsonData);
				return View(values);
			}
			return View();

        }
        public async Task <List<Team>> GetTeams()
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7123/api/Teams");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<Team>>(jsonData);
                return values;
			}
            return null;
		}


		// GET: Jerseys/Create
		public async Task< IActionResult> Create()
        {
            var teams = await GetTeams();
			ViewData["TeamId"] = new SelectList(teams, "Id", "TeamName");

			return View();
        }

        // POST: Jerseys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Body,Shorts,Socks,ImgPath,TeamId,IsKeeper")] Jersey jersey)
        {


			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(jersey);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7123/api/Jerseys", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(jersey); 
        }

        public async Task<IActionResult> Edit(int? id)
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7123/api/Jerseys/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<Jersey>(jsonData);
				ViewData["TeamId"] = new SelectList(await GetTeams(), "Id", "TeamName", values.TeamId);

				return View(values);
			}
			return View();


		}

		// POST: Jerseys/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Body,Shorts,Socks,ImgPath,TeamId,IsKeeper")] Jersey jersey)
		{
			ViewData["TeamId"] = new SelectList(await GetTeams(), "Id", "TeamName", jersey.TeamId);

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(jersey);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7123/api/Jerseys/"+jersey.Id, stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}


            return View(jersey);
        }

        // GET: Jerseys/Delete/5


        public async Task<IActionResult> Delete(int id)
        {


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7123/api/Jerseys/Delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();


        }



    }
}
