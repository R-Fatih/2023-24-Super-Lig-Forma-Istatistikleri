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
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatch()
        {
            if (_context.Match == null)
            {
                return NotFound();
            }
            return await _context.Match.Include(x=>x.HomeTeam).Include(y=>y.AwayTeam).Include(z=>z.HomeTeamJersey).Include(z => z.AwayTeamJersey).Include(z => z.HomeTeamJerseyGK).Include(w=>w.AwayTeamJerseyGK).Include(z=>z.RefereeJersey).ToListAsync();
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            if (_context.Match == null)
            {
                return NotFound();
            }
            var match = await _context.Match.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }

        // PUT: api/Matches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Matches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            if (_context.Match == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Match'  is null.");
            }
            _context.Match.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatch", new { id = match.Id }, match);
        }

        // DELETE: api/Matches/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Match.FindAsync(id);


            _context.Match.Remove(match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchExists(int id)
        {
            return (_context.Match?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
