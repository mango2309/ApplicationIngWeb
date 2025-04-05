using ApplicationIngWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApplicationIngWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
