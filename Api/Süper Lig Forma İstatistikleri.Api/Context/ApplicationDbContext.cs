


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Süper_Lig_Forma_İstatistikleri.Entities.Entities;


namespace Süper_Lig_Forma_İstatistikleri.Api.Context
{
    public class ApplicationDbContext : DbContext
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-FFF.Server-a0197bcd-57fe-4b88-ba79-bcc4917ea27c;Trusted_Connection=True;MultipleActiveResultSets=true");
		}
		public DbSet<Team> Team { get; set; } = default!;
        public DbSet<Jersey> Jersey { get; set; } = default!;
        public DbSet<Match> Match { get; set; } = default!;
        public DbSet<Referee> Referee { get; set; } = default!;
    }
}