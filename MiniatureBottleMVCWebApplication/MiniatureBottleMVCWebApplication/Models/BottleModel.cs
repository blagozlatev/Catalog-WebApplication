using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MiniatureBottleMVCWebApplication.Models
{
    public class Bottle
    {
        public Bottle()
        {
            BottleImage = new BottleImage();
        }

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int BottleImageId { get; set; }
        public int BottleDetailId { get; set; }
        public int BottleDrinkDetailId { get; set; }
        public int BottleOriginId { get; set; }

        [ForeignKey("BottleImageId")]
        public virtual BottleImage BottleImage { get; set; }

        [ForeignKey("BottleDetailId")]
        public virtual BottleDetail BottleDetail { get; set; }

        [ForeignKey("BottleDrinkDetailId")]
        public virtual BottleDrinkDetail BottleDrinkDetail { get; set; }

        [ForeignKey("BottleOriginId")]
        public virtual BottleOrigin BottleOrigin { get; set; }

        public override string ToString()
        {
            return "ID: " + this.Id + "\n"
                + "Alcohol Type: " + this.BottleDrinkDetail.AlcoholType + "\n"
                + "Alcohol" + this.BottleDrinkDetail.Alcohol + "\n"
                + "Content" + this.BottleDrinkDetail.Content + "\n"
                + "Age" + this.BottleDrinkDetail.Age + "\n"
                + "Shell" + this.BottleDetail.Shell + "\n"
                + "Name" + this.BottleDetail.Name + "\n"
                + "Shape" + this.BottleDetail.Shape + "\n"
                + "Color" + this.BottleDetail.Color + "\n"
                + "Material" + this.BottleDetail.Material + "\n"
                + "Manufacturer" + this.BottleOrigin.Manufacturer + "\n"
                + "City" + this.BottleOrigin.City + "\n"
                + "Country" + this.BottleOrigin.Country + "\n"
                + "Continent" + this.BottleOrigin.Continent + "\n"
                + "Note" + this.BottleDetail.Note + "\n";
        }

        public static Bottle Deserialize(string serialized)
        {
            string[] split = serialized.Split('#');
            for (int i = 0; i < split.Count(); i++)
            {
                if (string.IsNullOrEmpty(split[i]))
                {
                    split[i] = string.Empty;
                }
            }
            Bottle b = new Bottle();
            try
            {
                b.Id = int.Parse(split[0]);
                b.BottleDrinkDetail.AlcoholType = split[1];
                b.BottleDrinkDetail.Alcohol = split[2];
                b.BottleDrinkDetail.Content = split[3];
                b.BottleDrinkDetail.Age = int.Parse(split[4]);
                b.BottleDetail.Shell = split[5];
                b.BottleDetail.Name = split[6];
                b.BottleDetail.Shape = split[7];
                b.BottleDetail.Color = split[8];
                b.BottleDetail.Material = split[9];
                b.BottleOrigin.Manufacturer = split[10];
                b.BottleOrigin.City = split[11];
                b.BottleOrigin.Country = split[12];
                b.BottleOrigin.Continent = split[13];
                b.BottleDetail.Note = split[14];
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }
            return b;            
        }

        public static string Serialize(Bottle b)
        {            
            return b.Id.ToString().Replace('#', ' ') + "#"
                + b.BottleDrinkDetail.AlcoholType.Replace('#', ' ') + "#"
                + b.BottleDrinkDetail.Alcohol.Replace('#', ' ') + "#"
                + b.BottleDrinkDetail.Content.Replace('#', ' ') + "#"
                + b.BottleDrinkDetail.Age.ToString().Replace('#', ' ') + "#"
                + b.BottleDetail.Shell.Replace('#', ' ') + "#"
                + b.BottleDetail.Name.Replace('#', ' ') + "#"
                + b.BottleDetail.Shape.Replace('#', ' ') + "#"
                + b.BottleDetail.Color.Replace('#', ' ') + "#"
                + b.BottleDetail.Material.Replace('#', ' ') + "#"
                + b.BottleOrigin.Manufacturer.Replace('#', ' ') + "#"
                + b.BottleOrigin.City.Replace('#', ' ') + "#"
                + b.BottleOrigin.Country.Replace('#', ' ') + "#"
                + b.BottleOrigin.Continent.Replace('#', ' ') + "#"
                + b.BottleDetail.Note.Replace('#', ' ') + "#";
        }
    }

    public class MiniatureBottleContext : DbContext
    {
        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<BottleDetail> BottleDetails { get; set; }
        public DbSet<BottleDrinkDetail> BottleDrinkDetails { get; set; }
        public DbSet<BottleOrigin> BottleOrigins { get; set; }
        public DbSet<BottleImage> BottleImages { get; set; }        
    }
}