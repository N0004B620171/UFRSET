using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UFRSET.Models;

namespace UFRSET.Data
{
    public class UFRSETContext : DbContext
    {
        public UFRSETContext (DbContextOptions<UFRSETContext> options)
            : base(options)
        {
        }

        public DbSet<UFRSET.Models.Departement> Departement { get; set; } = default!;
        public DbSet<UFRSET.Models.Filiere> Filiere { get; set; } = default!;
        public DbSet<UFRSET.Models.Service> Service { get; set; } = default!;
        public DbSet<UFRSET.Models.Per> Per { get; set; } = default!;
        public DbSet<UFRSET.Models.Vacataire> Vacataire { get; set; } = default!;
    }
}
