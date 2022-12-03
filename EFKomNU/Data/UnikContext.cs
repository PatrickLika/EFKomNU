using EFKomNU.Model;
using Microsoft.EntityFrameworkCore;

namespace EFKomNU.Data
{
    public class UnikContext : DbContext
    {
        public UnikContext(DbContextOptions<UnikContext> options) : base(options)
        {

        }
        public DbSet<Kompetence> KompetenceEntities { get; set; }
        public DbSet<Medarbejder> MedarbejderEntities { get; set; }

    }
}
