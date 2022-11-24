using ApiAlumnos.Entidades;
using Microsoft.EntityFrameworkCore;
namespace ApiAlumnos
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Clase> Clases { get; set; }

    }
}
