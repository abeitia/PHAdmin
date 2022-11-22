using Microsoft.EntityFrameworkCore;
using PHAdmin.API.Entities;

namespace PHAdmin.API.DbContexts
{
    public class PHAdminContext : DbContext
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
               },
               new Apartment()
               {
                   Id = 5,
                   Floor = 2,
                   Letter = "B"
               },
               new Apartment()
               {
                   Id = 6,
                   Floor = 2,
                   Letter = "C"
               },
               new Apartment()
               {
                   Id = 7,
                   Floor = 2,
                   Letter = "D"
               },
               new Apartment()
               {
                   Id = 8,
                   Floor = 2,
                   Letter = "E"
               },
               new Apartment()
               {
                   Id = 9,
                   Floor = 3,
                   Letter = "A"
               },
               new Apartment()
               {
                   Id = 10,
                   Floor = 3,
                   Letter = "B"
               },
               new Apartment()
               {
                   Id =11,
                   Floor = 3,
                   Letter = "C"
               },
               new Apartment()
               {
                   Id = 12,
                   Floor = 3,
                   Letter = "D"
               },
               new Apartment()
               {
                   Id = 13,
                   Floor = 3,
                   Letter = "E"
               }
               );

            modelBuilder.Entity<Role>()
                .HasData(
                 new Role()
                 {
                     Id = 1,
                     RoleName = "Administrador"
                 },
                 new Role()
                 {
                     Id = 2,
                     RoleName = "Copropietario"
                 }
                );
        }
    }
}
