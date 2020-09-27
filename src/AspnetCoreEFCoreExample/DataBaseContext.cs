using AspnetCoreEFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreEFCoreExample
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Element> Element { get; set; }
        public DbSet<ElementMember> ElementMember { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
            //options.ContextType.

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
