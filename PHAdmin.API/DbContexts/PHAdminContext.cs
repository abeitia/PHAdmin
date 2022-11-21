using Microsoft.EntityFrameworkCore;
using PHAdmin.API.Entities;

namespace PHAdmin.API.DbContexts
{
    public class PHAdminContext: DbContext
    {
        public DbSet<Apartment> Apartments { get; set; } = null!;

        public PHAdminContext(DbContextOptions<PHAdminContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apartment>()
                .Property(u => u.Name)
                .HasComputedColumnSql("CONVERT([varchar](2),[Floor]) + '-' + [Letter]");

            //modelBuilder.Entity<Apartment>()
            //   .Property(b => b.CreationDate)
            //   .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<Apartment>()
            //  .Property(b => b.UpdateDate)
            //  .HasDefaultValueSql("NULL");

            //modelBuilder.Entity<Apartment>()
            // .Property(b => b.CreatedBy)
            // .HasDefaultValueSql("NULL");

            //modelBuilder.Entity<Apartment>()
            // .Property(b => b.UpdatedBy)
            // .HasDefaultValueSql("NULL");

            modelBuilder.Entity<Apartment>()
               .HasData(
               new Apartment()
               {
                   Id = 1,
                   Floor = 1,
                   Letter = "A"
               },
               new Apartment()
               {
                   Id = 2,
                   Floor = 1,
                   Letter = "B"
               },
               new Apartment()
               {
                   Id = 3,
                   Floor = 1,
                   Letter = "C"
               },
               new Apartment()
               {
                   Id = 4,
                   Floor = 2,
                   Letter = "A"
               });
        }
    }
}
