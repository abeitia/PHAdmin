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
        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<Debt> Debts { get; set; } = null!;

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
               },
               new Apartment(4, "A")
               {
                   Id = 14,
                   Floor = 4,
                   Letter = "A"
               },
               new Apartment(4, "B")
               {
                   Id = 15,
                   Floor = 4,
                   Letter = "B"
               },
               new Apartment(4, "C")
               {
                   Id = 16,
                   Floor = 4,
                   Letter = "C"
               },
               new Apartment(4, "D")
               {
                   Id = 17,
                   Floor = 4,
                   Letter = "D"
               },
               new Apartment(4, "E")
               {
                   Id = 18,
                   Floor = 4,
                   Letter = "E"
               },
               new Apartment(5, "A")
               {
                   Id = 19,
                   Floor = 5,
                   Letter = "A"
               },
               new Apartment(5, "B")
               {
                   Id = 20,
                   Floor = 5,
                   Letter = "B"
               },
               new Apartment(5, "C")
               {
                   Id = 21,
                   Floor = 5,
                   Letter = "C"
               },
               new Apartment(5, "D")
               {
                   Id = 22,
                   Floor = 5,
                   Letter = "D"
               },
               new Apartment(5, "E")
               {
                   Id = 23,
                   Floor = 5,
                   Letter = "E"
               },
               new Apartment(6, "A")
               {
                   Id = 24,
                   Floor = 6,
                   Letter = "A"
               },
               new Apartment(6, "B")
               {
                   Id = 25,
                   Floor = 6,
                   Letter = "B"
               },
               new Apartment(6, "C")
               {
                   Id = 26,
                   Floor = 6,
                   Letter = "C"
               },
               new Apartment(6, "D")
               {
                   Id = 27,
                   Floor = 6,
                   Letter = "D"
               },
               new Apartment(28, "E")
               {
                   Id = 28,
                   Floor = 6,
                   Letter = "E"
               },
               new Apartment(7, "A")
               {
                   Id = 29,
                   Floor = 7,
                   Letter = "A"
               },
               new Apartment(7, "B")
               {
                   Id = 30,
                   Floor = 7,
                   Letter = "B"
               },
               new Apartment(7, "C")
               {
                   Id = 31,
                   Floor = 7,
                   Letter = "C"
               },
               new Apartment(7, "D")
               {
                   Id = 32,
                   Floor = 7,
                   Letter = "D"
               },
               new Apartment(33, "E")
               {
                   Id = 33,
                   Floor = 7,
                   Letter = "E"
               },
               new Apartment(8, "A")
               {
                   Id = 34,
                   Floor = 8,
                   Letter = "A"
               },
               new Apartment(8, "B")
               {
                   Id = 35,
                   Floor = 8,
                   Letter = "B"
               },
               new Apartment(8, "C")
               {
                   Id = 36,
                   Floor = 8,
                   Letter = "C"
               },
               new Apartment(8, "D")
               {
                   Id = 37,
                   Floor = 8,
                   Letter = "D"
               },
               new Apartment(8, "E")
               {
                   Id = 38,
                   Floor = 8,
                   Letter = "E"
               },
               new Apartment(9, "A")
               {
                   Id = 39,
                   Floor = 9,
                   Letter = "A"
               },
               new Apartment(9, "B")
               {
                   Id = 40,
                   Floor = 9,
                   Letter = "B"
               },
               new Apartment(9, "C")
               {
                   Id = 41,
                   Floor = 9,
                   Letter = "C"
               },
               new Apartment(9, "D")
               {
                   Id = 42,
                   Floor = 9,
                   Letter = "D"
               },
               new Apartment(9, "E")
               {
                   Id = 43,
                   Floor = 9,
                   Letter = "E"
               },
               new Apartment(10, "A")
               {
                   Id = 44,
                   Floor = 10,
                   Letter = "A"
               },
               new Apartment(10, "B")
               {
                   Id = 45,
                   Floor = 10,
                   Letter = "B"
               },
               new Apartment(10, "C")
               {
                   Id = 46,
                   Floor = 10,
                   Letter = "C"
               },
               new Apartment(10, "D")
               {
                   Id = 47,
                   Floor = 10,
                   Letter = "D"
               },
               new Apartment(10, "E")
               {
                   Id = 48,
                   Floor = 10,
                   Letter = "E"
               },
               new Apartment(11, "A")
               {
                   Id = 49,
                   Floor = 11,
                   Letter = "A"
               },
               new Apartment(11, "B")
               {
                   Id = 50,
                   Floor = 11,
                   Letter = "B"
               },
               new Apartment(11, "C")
               {
                   Id = 51,
                   Floor = 11,
                   Letter = "C"
               },
               new Apartment(11, "D")
               {
                   Id = 52,
                   Floor = 11,
                   Letter = "D"
               },
               new Apartment(11, "E")
               {
                   Id = 53,
                   Floor = 11,
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
                 new ExpenseType("Artículos de limpieza")
                 {
                     Id = 1,
                     ExpenseName = "Artículos de limpieza"
                 },
                 new ExpenseType("Caja de Seguro Social")
                 {
                     Id = 2,
                     ExpenseName = "Caja de Seguro Social"
                 },
                 new ExpenseType("Caja menuda")
                  {
                      Id = 3,
                      ExpenseName = "Caja menuda"
                  },
                 new ExpenseType("Cargos bancarios")
                  {
                      Id = 4,
                      ExpenseName = "Cargos bancarios"
                  },
                 new ExpenseType("Cerrajería")
                   {
                       Id = 5,
                       ExpenseName = "Cerrajería"
                   },
                 new ExpenseType("Conserje")
                    {
                        Id = 6,
                        ExpenseName = "Conserje"
                    },
                 new ExpenseType("Devolución de reserva")
                      {
                          Id = 7,
                          ExpenseName = "Devolución de reserva"
                      },
                 new ExpenseType("Fotocopias")
                        {
                            Id = 8,
                            ExpenseName = "Fotocopias"
                        },
                 new ExpenseType("Fumigación")
                         {
                             Id = 9,
                             ExpenseName = "Fumigación"
                         },
                 new ExpenseType("Gastos legales")
                         {
                             Id = 10,
                             ExpenseName = "Gastos legales"
                         },
                 new ExpenseType("Mantenimiento de A/A.")
                          {
                              Id = 11,
                              ExpenseName = "Mantenimiento de A/A."
                          },
                 new ExpenseType("Mantenimiento de ascensores")
                             {
                                 Id = 12,
                                 ExpenseName = "Mantenimiento de ascensores"
                             },
                 new ExpenseType("Mantenimiento de bomba de agua")
                             {
                                 Id = 13,
                                 ExpenseName = "Mantenimiento de bomba de agua"
                             },
                 new ExpenseType("Mantenimiento de planta eléctrica")
                             {
                                 Id = 14,
                                 ExpenseName = "Mantenimiento de planta eléctrica"
                             },
                 new ExpenseType("Mantenimiento de puertas mecánicas")
                              {
                                  Id = 15,
                                  ExpenseName = "Mantenimiento de puertas mecánicas"
                              },
                 new ExpenseType("Portería")
                               {
                                   Id = 16,
                                   ExpenseName = "Portería"
                               },
                 new ExpenseType("Reembolso")
                               {
                                   Id = 17,
                                   ExpenseName = "Reembolso"
                               },
                 new ExpenseType("Servicio de administración")
                                {
                                    Id = 18,
                                    ExpenseName = "Servicio de administración"
                                },
                 new ExpenseType("Servicio de agua")
                                 {
                                     Id = 19,
                                     ExpenseName = "Servicio de agua"
                                 },
                 new ExpenseType("Servicio de electricidad")
                                  {
                                      Id = 20,
                                      ExpenseName = "Servicio de electricidad"
                                  },
                 new ExpenseType("Servicio de gas")
                                  {
                                      Id = 21,
                                      ExpenseName = "Servicio de gas"
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
