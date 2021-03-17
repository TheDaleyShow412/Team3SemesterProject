namespace Team3SemesterProject.Migrations.MIS4200ContextTeam3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Team3SemesterProject.DAL.MIS4200ContextTeam3>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\MIS4200ContextTeam3";
            ContextKey = "Team3SemesterProject.DAL.MIS4200ContextTeam3";
        }

        protected override void Seed(Team3SemesterProject.DAL.MIS4200ContextTeam3 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
