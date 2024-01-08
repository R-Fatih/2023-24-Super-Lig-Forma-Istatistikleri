using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Süper_Lig_Forma_İstatistikleri.Entities.Entities;
using System.Data;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Süper_Lig_Forma_İstatistikleri.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class MackoliksController : ControllerBase
    {
        // GET: api/<MackoliksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("get")]
        public async Task<ActionResult<Match>> scrape(string adres)
        {
            List<string> list = new List<string>
            {
                "//*[@id=\"match-details\"]/div/div[1]/div/div[1]/div[2]",
                    "//*[@id=\"dvScoreText\"]",
                    "//*[@id=\"match-details\"]/div/div[1]/div/div[2]/div[1]/div[1]/a",
                    "//*[@id=\"match-details\"]/div/div[1]/div/div[2]/div[3]/div[1]/a"
            };

            Match match = new Match();
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load($"https://arsiv.mackolik.com/Mac/{adres}/");
            var date = document.DocumentNode.SelectNodes(list[0]);
            var skor = document.DocumentNode.SelectNodes(list[1]);



            match.Date = Convert.ToDateTime(date[0].InnerText.Replace("Tarih : ", ""), new CultureInfo("tr"));
            //try
            //{


            //	match.HomeScore = Convert.ToInt32(skor[0].InnerText.Split('-')[0]);
            //	match.AwayScore = Convert.ToInt32(skor[0].InnerText.Split('-')[1]);
            //}
            //catch (Exception)
            //{

            //}
            match.HomeMS = Convert.ToInt32(skor[0].InnerText.ToString().Split('-')[0].ToString());
            match.AwayMS = Convert.ToInt32(skor[0].InnerText.ToString().Split('-')[1].ToString());

            return match;
            //for (int i = 0; i < takımlar.Count; i++)
            //{
            //    dataGridView1.Rows.Add(i+1,takımlar[i], puanlar[i]);
            //}
        }

        // GET api/<MackoliksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MackoliksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MackoliksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MackoliksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
