using Microsoft.EntityFrameworkCore;
using PHAdmin.API.Entities;
using Bogus;
using Bogus.Extensions.Canada;

namespace PHAdmin.API.DbContexts
{
    public class PHAdminContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<ExpenseType> ExpenseTypes { get; set; } = null!;
        public DbSet<PaymentType> PaymentTypes { get; set; } = null!;
        public DbSet<Holiday> Holidays { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Payment> Payments { get; set; } = null!;

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
               new Apartment(1,"A")
               {
                   Id = 1,
                   Floor = 1,
                   Letter = "A"
               },
               new Apartment(1, "B")
               {
                   Id = 2,
                   Floor = 1,
                   Letter = "B"
               },
               new Apartment(1, "C")
               {
                   Id = 3,
                   Floor = 1,
                   Letter = "C"
               },
               new Apartment(2, "A")
               {
                   Id = 4,
                   Floor = 2,
                   Letter = "A"
               },
               new Apartment(2, "B")
               {
                   Id = 5,
                   Floor = 2,
                   Letter = "B"
               },
               new Apartment(2, "C")
               {
                   Id = 6,
                   Floor = 2,
                   Letter = "C"
               },
               new Apartment(2, "D")
               {
                   Id = 7,
                   Floor = 2,
                   Letter = "D"
               },
               new Apartment(2, "E")
               {
                   Id = 8,
                   Floor = 2,
                   Letter = "E"
               },
               new Apartment(3, "A")
               {
                   Id = 9,
                   Floor = 3,
                   Letter = "A"
               },
               new Apartment(3, "B")
               {
                   Id = 10,
                   Floor = 3,
                   Letter = "B"
               },
               new Apartment(3, "C")
               {
                   Id =11,
                   Floor = 3,
                   Letter = "C"
               },
               new Apartment(3, "D")
               {
                   Id = 12,
                   Floor = 3,
                   Letter = "D"
               },
               new Apartment(3, "E")
               {
                   Id = 13,
                   Floor = 3,
                   Letter = "E"
               }
               );

            modelBuilder.Entity<Role>()
                .HasData(
                 new Role("Administrador")
                 {
                     Id = 1,
                     RoleName = "Administrador"
                 },
                 new Role("Copropietario")
                 {
                     Id = 2,
                     RoleName = "Copropietario"
                 }
                );

            modelBuilder.Entity<ExpenseType>()
                .HasData(
                 new ExpenseType("Agua")
                 {
                     Id = 1,
                     ExpenseName = "Agua"
                 },
                 new ExpenseType("Luz")
                 {
                     Id = 2,
                     ExpenseName = "Luz"
                 }
                );

            modelBuilder.Entity<PaymentType>()
                .HasData(
                 new PaymentType("Cuota Ordinaria")
                 {
                     Id = 1,
                     PaymentName = "Cuota Ordinaria"
                 },
                 new PaymentType("Cuota Extraordinaria")
                 {
                     Id = 2,
                     PaymentName = "Cuota Extraordinaria"
                 },
                 new PaymentType("Reserva de área común")
                 {
                     Id = 3,
                     PaymentName = "Reserva de área común"
                 }
                );

            modelBuilder.Entity<Holiday>()
               .HasData(
                new Holiday(new DateTime(2023, 1, 1))
                {
                    Id = 1,
                    DateValue = new DateTime(2023, 1, 1),
                    Description="Año Nuevo"

                },
                new Holiday(new DateTime(2023, 1, 9))
                {
                    Id = 2,
                    DateValue = new DateTime(2023, 1, 9),
                    Description="Día de los Martíres"
                }
               );

            var ids = 1;
            var stock = new Faker<User>("es_MX")
                .CustomInstantiator(f =>
                new User(f.Person.FullName))
                .RuleFor(m => m.Id, f => ids++)
                .RuleFor(m => m.Name, f => f.Person.FullName)
                .RuleFor(m => m.Identification, f => f.Person.Sin())
                .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(m => m.Password, f => "1234")
                .RuleFor(m => m.RoleId, f => 2)
                .RuleFor(m => m.Email, f => f.Person.Email);

            modelBuilder
               .Entity<User>()
               .HasData(stock.GenerateBetween(53, 53));
        }
    }
}
