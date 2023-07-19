using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PruebaFinanzauto.Entidades;

namespace PruebaFinanzauto
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

        }

        public DbSet<Estudiantes> Estudiantes { get; set; }

        public DbSet<Profesores> Profesores { get; set;}

        public DbSet<Cursos> Cursos { get; set; }

    }
}
