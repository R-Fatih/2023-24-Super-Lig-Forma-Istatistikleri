using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Süper_Lig_Forma_İstatistikleri.Api.Context;
using Süper_Lig_Forma_İstatistikleri.Api.Model;

namespace Süper_Lig_Forma_İstatistikleri.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaticsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public StaticsController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("GetMostWearedKits")]
		public async Task<IActionResult> GetMostWearedKits()
		{
		var values=_context.Database.SqlQueryRaw<WearedKitsModel>("SELECT   TeamName,Body,Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyId  FROM match    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyId FROM match ) AS combined_matches  inner join Jersey on Jersey.Id=combined_matches.HomeTeamJerseyId inner join Team on Team.Id=combined_matches.HomeTeamId   group by TeamName,Body order by KitCount desc").ToList();
			return Ok(values);
		}
		[HttpGet("GetMostWearedKitsCombines")]
		public async Task<IActionResult> GetMostWearedKitsCombines()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModel>("SELECT   TeamName,Body+' '+Shorts+' '+Socks as 'Body',Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyId  FROM match    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyId FROM match ) AS combined_matches  inner join Jersey on Jersey.Id=combined_matches.HomeTeamJerseyId inner join Team on Team.Id=combined_matches.HomeTeamId   group by TeamName,Body+' '+Shorts+' '+Socks order by KitCount desc").ToList();
			return Ok(values);
		}
		[HttpGet("GetMostWearedKitsGK")]
		public async Task<IActionResult> GetMostWearedKitsGK()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModelGK>("SELECT   TeamName,Name,Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyGKId  FROM match    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyGKId FROM match ) AS combined_matches  inner join Jersey on Jersey.Id=combined_matches.HomeTeamJerseyGKId inner join Team on Team.Id=combined_matches.HomeTeamId   group by TeamName,Name order by KitCount desc").ToList();
			return Ok(values);
		}
		[HttpGet("GetMostWearedKitsInHome")]
		public async Task<IActionResult> GetMostWearedKitsInHome()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModel>("SELECT   TeamName,Body,Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyId  FROM match   ) AS combined_matches  inner join Jersey on Jersey.Id=combined_matches.HomeTeamJerseyId inner join Team on Team.Id=combined_matches.HomeTeamId   group by TeamName,Body order by KitCount desc").ToList();
			return Ok(values);
		}
		[HttpGet("GetMostWearedKitsInAway")]
		public async Task<IActionResult> GetMostWearedKitsInAway()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModel>("SELECT   TeamName,Body,Count(*) as 'KitCount' FROM (   SELECT AwayTeamId,AwayTeamJerseyId  FROM match   ) AS combined_matches  inner join Jersey on Jersey.Id=combined_matches.AwayTeamJerseyId inner join Team on Team.Id=combined_matches.AwayTeamId   group by TeamName,Body order by KitCount desc").ToList();
			return Ok(values);
		}
		[HttpGet("GetMostWearedKitsInHomeGK")]
		public async Task<IActionResult> GetMostWearedKitsInHomeGK()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModelGK>("SELECT   TeamName,Name,Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyGKId  FROM match   ) AS combined_matches  inner join Jersey on Jersey.Id=combined_matches.HomeTeamJerseyGKId inner join Team on Team.Id=combined_matches.HomeTeamId   group by TeamName,Name order by KitCount desc").ToList();
			return Ok(values);
		}
		[HttpGet("GetMostWearedKitsInAwayGK")]
		public async Task<IActionResult> GetMostWearedKitsInAwayGK()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModelGK>("SELECT   TeamName,Name,Count(*) as 'KitCount' FROM (   SELECT AwayTeamId,AwayTeamJerseyGKId  FROM match   ) AS combined_matches  inner join Jersey on Jersey.Id=combined_matches.AwayTeamJerseyGKId inner join Team on Team.Id=combined_matches.AwayTeamId   group by TeamName,Name order by KitCount desc").ToList();
			return Ok(values);
		}
		[HttpGet("GetMostWearedKitsReferee")]
		public async Task<IActionResult> GetMostWearedKitsReferee()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModelReferee>("select Body,Count(*) as  'KitCount' from Match inner join Jersey on Match.RefereeJerseyId=Jersey.Id group by Body order by KitCount desc").ToList();
			return Ok(values);
		}
		[HttpGet("GetMostWearedKitsRefereeCombines")]
		public async Task<IActionResult> GetMostWearedKitsRefereeCombines()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModelReferee>("select Body+' '+Shorts+' '+Socks as 'Body',Count(*) as  'KitCount' from Match inner join Jersey on Match.RefereeJerseyId=Jersey.Id group by Body+' '+Shorts+' '+Socks order by KitCount desc").ToList();
			return Ok(values);
		}
		[HttpGet("GetUnwearedKits")]
		public async Task<IActionResult> GetUnwearedKits()
		{
			var values = _context.Database.SqlQueryRaw<UnwearedKitsModel>("select TeamId,Body,TeamName from jersey inner join Team on Team.Id=TeamId where  IsKeeper=0 and TeamId!=21 except (select HomeTeamId,Body,TeamName from Match inner join Team on Team.Id=Match.HomeTeamId inner join Jersey On Match.HomeTeamJerseyId=Jersey.Id union all select AwayTeamId,Body,TeamName from Match inner join Team on Team.Id=Match.AwayTeamId inner join Jersey on Match.AwayTeamJerseyId=Jersey.Id) ").ToList();
			return Ok(values);
		}
		[HttpGet("GetKitBodyType")]
		public async Task<IActionResult> GetKitBodyType()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModelReferee>("SELECT   Body,Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyId  FROM match    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyId FROM match ) AS combined_matches  inner join Jersey on Jersey.Id=combined_matches.HomeTeamJerseyId inner join Team on Team.Id=combined_matches.HomeTeamId   group by Body order by KitCount desc ").ToList();
			return Ok(values);
		}
		[HttpGet("GetKitBodyTypeGK")]
		public async Task<IActionResult> GetKitBodyTypeGK()
		{
			var values = _context.Database.SqlQueryRaw<WearedKitsModelReferee>("SELECT   Body,Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyGKId  FROM match    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyGKId FROM match ) AS combined_matches  inner join Jersey on Jersey.Id=combined_matches.HomeTeamJerseyGKId inner join Team on Team.Id=combined_matches.HomeTeamId   group by Body order by KitCount desc ").ToList();
			return Ok(values);
		}
	}
}
