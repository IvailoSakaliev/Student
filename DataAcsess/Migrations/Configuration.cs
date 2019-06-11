
namespace DataAcsess.Migrations
{
    using DataAcsess.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAcsess.StudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataAcsess.StudentDBContext context)
        {
           
        }
    }
}
