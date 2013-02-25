namespace MiniatureBottleMVCWebApplication.Migrations
{
    using MiniatureBottleMVCWebApplication.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniatureBottleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MiniatureBottleContext context)
        {
            Bottle b1 = new Bottle
                            {
                                Age = 12,
                                Alcohol = "da",
                                AlcoholType = "da",
                                City = "Da",
                                Color = "Black",
                                Content = "Whiskey",
                                Continent = "Europe",
                                Country = "Bulgaria",
                                Id = 13,
                                Manufacturer = "da",
                                Material = "da",
                                Name = "da",
                                Note = "da",
                                Shape = "dada",
                                Shell = "case"
                            };

            Bottle b2 = new Bottle
                     {
                         Age = 12,
                         Alcohol = "da",
                         AlcoholType = "da",
                         City = "Da",
                         Color = "Black",
                         Content = "Whiskey",
                         Continent = "Europe",
                         Country = "Bulgaria",
                         Id = 142,
                         Manufacturer = "da",
                         Material = "da",
                         Name = "da",
                         Note = "da",
                         Shape = "dada",
                         Shell = "case"
                     };
            context.Bottles.AddOrUpdate(b1, b2);

            context.BottleImages.AddOrUpdate(
                new BottleImage
                {
                    BottleImageId = 1,
                    Bottle = b1
                },
                new BottleImage
                {
                    BottleImageId = 2,
                    Bottle = b2
                });
        }
    }
}
