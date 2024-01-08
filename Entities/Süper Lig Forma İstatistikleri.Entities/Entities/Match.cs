using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Süper_Lig_Forma_İstatistikleri.Entities.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? HomeTeamJerseyId { get; set; }
        public int? HomeTeamJerseyGKId { get; set; }

        public int? RefereeJerseyId { get; set; }
        public int? AwayTeamJerseyId { get; set; }
        public int? AwayTeamJerseyGKId { get; set; }

        public int? HomeMS { get; set; }
        public int? AwayMS { get; set; }
        public int? Maçkolik { get; set; }
        public DateTime? Date { get; set; }
        public int MainId { get; set; }
        public int Week { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? AwayTeam { get; set; }
        public Jersey? RefereeJersey { get; set; }
        public Jersey? HomeTeamJersey { get; set; }
        public Jersey? AwayTeamJersey { get; set; }
        public Jersey? HomeTeamJerseyGK { get; set; }
        public Jersey? AwayTeamJerseyGK { get; set; }
        public int? RefereeId { get; set; }
        public Referee? Referee { get; set; }
    }
}
