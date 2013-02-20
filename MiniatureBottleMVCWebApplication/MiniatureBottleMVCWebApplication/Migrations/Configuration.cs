namespace MiniatureBottleMVCWebApplication.Migrations
{
    using MiniatureBottleMVCWebApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
                        ID=12,
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
                         ID = 122,
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
                    ID = 12
                },
                new BottleImage
                {
                    ID = 122
                });
        }
    }
}
