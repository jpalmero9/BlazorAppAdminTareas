using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppAdminTareas.Entities
{
    public class TareasContext : DbContext
    {
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        public DbSet<LasTareas> LasTareas { get; set; }

    }
}
