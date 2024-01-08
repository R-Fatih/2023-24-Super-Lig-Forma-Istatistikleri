using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Süper_Lig_Forma_İstatistikleri.Entities.Entities
{
    public class Jersey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Shorts { get; set; }
        public string Socks { get; set; }
        public string ImgPath { get; set; }
        public int TeamId { get; set; }
        public bool IsKeeper { get; set; }
        public Team? Team { get; set; }

    }
}
