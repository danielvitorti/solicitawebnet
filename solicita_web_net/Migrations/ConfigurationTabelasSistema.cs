using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace solicita_web_net.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;


    internal sealed class ConfigurationTabelasSistema : DbMigrationsConfiguration<solicita_web_net.Models.ModeloDadosSolicita>
    {
        public ConfigurationTabelasSistema()
        {
            AutomaticMigrationsEnabled = true;
        }

    

        protected override void Seed(solicita_web_net.Models.ModeloDadosSolicita context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }

}