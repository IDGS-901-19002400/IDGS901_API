using IDGS901_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IDGS901_Api.Context
{
    public class AppDbContext : DbContext
    {

        private const string conectionstring = "conexion";

        public AppDbContext(DbContextOptions<AppDbContext> options) 

            : base(options) { }

       

    public DbSet<Alumnos> Alumnos { get; set; }



    }
}
