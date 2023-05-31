using Entities.WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.WEB
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WordModel>? Words { get; set; }
    }
}