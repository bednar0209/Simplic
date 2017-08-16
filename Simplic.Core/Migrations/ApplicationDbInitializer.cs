using Simplic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.Core.Migrations
{
    public class ApplicationDbInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbInitializer()
        {
            AutomaticMigrationsEnabled = true;
            // not allowed migration, if data loss is possible
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
            if(context.Persons.Count() == 0)
            {
                context.Persons.Add(new Person
                {
                    FirstName = "aaaaaaa",
                    LastName = "aaaaaaa",
                    Age = 23,
                    Address = "aaaaa gjhg 66aa",
                    Sex = "Male"
                });
            }
        }
    }
}
