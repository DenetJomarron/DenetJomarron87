namespace ConexionDb.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConexionDb.PDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(ConexionDb.PDBContext context)
        {
            //var person = new List<Person>
            //{
            //    new Person {Id = 0, Name = "Carson",  LastName  = "Alexander",
            //        Age = 30, Phone = "305-902-3665", IdDealer= null,
            //        Sexo = "Male",Dealer = null},
            //   //new Person {Id = 0, Name = "Denet",   LastName = "Jomarron",
            //   //     Age = 65, Phone = "305-905-3256", IdDealer= null,
            //   //     Sexo = "Female",Dealer = null},
            //   //new Person {Id = 0, Name = "Erick",   LastName = "Rodriguez",
            //   //     Age = 20, Phone = "786-653-3333", IdDealer= null,
            //   //     Sexo = "Male",Dealer = null }
            //};
            //person.ForEach(per => context.People.AddOrUpdate(p => p.LastName, per));
            //context.SaveChanges();
        }
    }
}
