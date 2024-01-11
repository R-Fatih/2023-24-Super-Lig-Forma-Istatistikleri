namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
	public class WearedKitsModelWithWDL
	{
		public string TeamName { get; set; }
		public string Body { get; set; }
		public int KitCount { get; set; }
		public int Wins { get; set; }
		public int Draws { get; set; }
		public int Loses { get; set; }
		public decimal WinPercantage { get; set; }
		public decimal LosePercantage { get; set; }
	}
}
