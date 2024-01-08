using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Süper_Lig_Forma_İstatistikleri.Entities.Entities;

namespace Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Süper_Lig_Forma_İstatistikleri.Entities.Entities.Jersey> Jersey { get; set; } = default!;
        public DbSet<Süper_Lig_Forma_İstatistikleri.Entities.Entities.Match> Match { get; set; } = default!;
    }
}
