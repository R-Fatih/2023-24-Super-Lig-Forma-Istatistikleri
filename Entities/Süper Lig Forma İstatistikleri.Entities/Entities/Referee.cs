namespace Süper_Lig_Forma_İstatistikleri.Entities.Entities
{
    public class Referee
    {
        public int RefereeId { get; set; }
        public string RefereeName { get; set; }
        public bool IsFifa { get; set; }
        public string ImgUrl { get; set; }
        public List<Match> Match { get; set; }
    }
}
