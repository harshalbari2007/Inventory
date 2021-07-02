 
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Entity;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string connString)
            : base(connString)
        {
            Database.SetInitializer<DatabaseContext>(null);
        }
        public DatabaseContext()
            : base("Name=dbconn")
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Product"); 
        }
    }
}
