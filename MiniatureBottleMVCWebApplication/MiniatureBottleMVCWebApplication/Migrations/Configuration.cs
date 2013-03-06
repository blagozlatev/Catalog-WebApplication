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
                                   BottleDetail = new BottleDetail()
                                                      {
                                                          Material = "da",
                                                          Name = "da",
                                                          Color = "Black",
                                                          Note = "da",
                                                          Shape = "dada",
                                                          Shell = "case",
                                                          Id = 2
                                                      },
                                   BottleImage = new BottleImage()
                                                     {
                                                         BottleImageId = 2
                                                     },
                                   BottleOrigin = new BottleOrigin()
                                                      {
                                                          City = "Da",
                                                          Continent = "Europe",
                                                          Country = "Bulgaria",
                                                          Manufacturer = "da",
                                                          Id = 2
                                                      },
                                   BottleDrinkDetail = new BottleDrinkDetail()
                                                           {
                                                               Age = 12,
                                                               Alcohol = "da",
                                                               AlcoholType = "da",
                                                               Content = "Whiskey",
                                                               Id = 2
                                                           },
                                   Id = 4
                               };

            Bottle b2 = new Bottle
                               {
                                   BottleDetail = new BottleDetail()
                                                      {
                                                          Material = "da",
                                                          Color = "Black",
                                                          Name = "da",
                                                          Note = "da",
                                                          Shape = "dada",
                                                          Shell = "case",
                                                          Id = 1
                                                      },
                                   BottleImage = new BottleImage()
                                                     {
                                                         BottleImageId = 1
                                                     },
                                   BottleOrigin = new BottleOrigin()
                                                      {
                                                          City = "Da",
                                                          Continent = "Europe",
                                                          Country = "Bulgaria",
                                                          Manufacturer = "da",
                                                          Id = 1
                                                      },
                                   BottleDrinkDetail = new BottleDrinkDetail()
                                                           {
                                                               Age = 12,
                                                               Alcohol = "da",
                                                               AlcoholType = "da",
                                                               Content = "Whiskey",
                                                               Id = 1
                                                           },
                                   Id = 1
                               };

            context.Bottles.AddOrUpdate(b1, b2);
            context.BottleImages.AddOrUpdate(b1.BottleImage, b2.BottleImage);
            context.BottleDrinkDetails.AddOrUpdate(b1.BottleDrinkDetail, b2.BottleDrinkDetail);
            context.BottleDetails.AddOrUpdate(b1.BottleDetail, b2.BottleDetail);
            context.BottleOrigins.AddOrUpdate(b1.BottleOrigin, b2.BottleOrigin);
        }
    }
}
