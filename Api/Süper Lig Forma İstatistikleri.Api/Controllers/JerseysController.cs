using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Süper_Lig_Forma_İstatistikleri.Api.Context;
using Süper_Lig_Forma_İstatistikleri.Entities.Entities;


namespace Süper_Lig_Forma_İstatistikleri.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JerseysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JerseysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Jerseys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jersey>>> GetJersey()
        {
            if (_context.Jersey == null)
            {
                return NotFound();
            }
            return await _context.Jersey.ToListAsync();
        }
		[HttpGet("GetJerseysWithTeam")]
		public async Task<ActionResult<IEnumerable<Jersey>>> GetJerseysWithTeam()
		{
			if (_context.Jersey == null)
			{
				return NotFound();
			}
			return await _context.Jersey.Include(x=>x.Team).ToListAsync();
		}
		[HttpGet("team")]
        public async Task<ActionResult<IEnumerable<Jersey>>> GetJerseyByTeam(int teamid)
        {
            return await _context.Jersey.Where(a => a.TeamId == teamid).Where(a => a.IsKeeper == false).ToListAsync();
        }
        [HttpGet("teamgk")]
        public async Task<ActionResult<IEnumerable<Jersey>>> GetJerseyByTeamGk(int teamid)
        {
            return await _context.Jersey.Where(a => a.TeamId == teamid).Where(a => a.IsKeeper == true).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jersey>> GetJersey(int id)
        {
            var jersey = await _context.Jersey.FindAsync(id);

            return jersey;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutJersey(int id, Jersey jersey)
        {
           
            _context.Entry(jersey).State = EntityState.Modified;

                await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Jerseys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jersey>> PostJersey(Jersey jersey)
        {
            
                _context.Jersey.Add(jersey);
                await _context.SaveChangesAsync();
            
            return Ok();
        }

        // DELETE: api/Jerseys/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteJersey(int id)
        {
           
            var jersey = await _context.Jersey.FindAsync(id);
           
            _context.Jersey.Remove(jersey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
