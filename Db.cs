using Microsoft.EntityFrameworkCore;
using PrviBlazorServerApp.Data;
using PrviBlazorServerApp.Data.Models;

namespace PrviBlazorServerApp
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> opcije) : base(opcije)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(p => p.Id);

            modelBuilder.Entity<Person>().HasData
                (
                    new Person[]
                    {
                        new Person{ Id = -1, Name ="Pera", Surname="Peric"},
                        new Person{ Id = -2, Name ="Neko", Surname="Nekic"},
                        new Person{ Id = -3, Name ="Trecko", Surname="Treckovic"},
                        new Person{ Id = -4, Name ="Nemam", Surname="Ideje"},
                        new Person{ Id = -5, Name ="Asd", Surname="Qwe"},
                    }
                );
        }
    }
}