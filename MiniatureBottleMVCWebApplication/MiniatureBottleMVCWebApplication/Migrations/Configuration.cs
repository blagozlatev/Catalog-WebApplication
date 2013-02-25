namespace MiniatureBottleMVCWebApplication.Migrations
{
    using MiniatureBottleMVCWebApplication.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniatureBottleMVCWebApplication.Models.MiniatureBottleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MiniatureBottleMVCWebApplication.Models.MiniatureBottleContext context)
        {
            context.Bottles.AddOrUpdate(i => i.Name,
                    new Bottle
                    {
                        Age=12,
                        Alcohol="da",
                        AlcoholType="da",
                        City="Da",
                        Color="Black",
                        Content="Whiskey",
                        Continent="Europe",
                        Country="Bulgaria",
                        ID=13,
                        Manufacturer="da",
                        Material="da",
                        Name="da",
                        Note="da",
                        Shape="dada",
                        Shell="case"
                    },

                     new Bottle
                     {
                         Age = 12,
                         Alcohol = "da",
                         AlcoholType = "da",
                         City = "Da",
                         Color = "Black",
                         Content = "Whiskey",
                         Continent = "Europe",
                         Country = "Bulgaria",
                         ID = 142,
                         Manufacturer = "da",
                         Material = "da",
                         Name = "da",
                         Note = "da",
                         Shape = "dada",
                         Shell = "case"
                     });

            context.BottleImages.AddOrUpdate(
                new BottleImage
                {
                    BottleImageId = 13
                },
                new BottleImage
                {
                    BottleImageId = 142
                });
        }
    }
}
