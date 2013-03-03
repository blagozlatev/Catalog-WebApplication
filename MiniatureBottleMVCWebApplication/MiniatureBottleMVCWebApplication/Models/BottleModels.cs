using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MiniatureBottleMVCWebApplication.Models
{
    public class BottleDrinkDetail
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string AlcoholType { get; set; }

        [StringLength(100)]
        public string Alcohol { get; set; }

        [StringLength(100)]
        public string Content { get; set; }

        [Range(1, 300)]
        public int Age { get; set; }
    }

    public class BottleDetail
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Shell { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Shape { get; set; }

        [StringLength(100)]
        public string Color { get; set; }

        [StringLength(100)]
        public string Material { get; set; }

        [StringLength(255)]
        public string Note { get; set; }
    }

    public class BottleOrigin
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Continent { get; set; }
    }

    public class BottleImage
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BottleImageId { get; set; }        
        
        public byte[] BottleImg { get; set; }
    }

    public class BottleAdd
    {
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
    }

    public class Bottle
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string AlcoholType { get; set; }

        [StringLength(100)]
        public string Alcohol { get; set; }

        [StringLength(100)]
        public string Content { get; set; }

        [Range(1, 300)]
        public int Age { get; set; }

        [StringLength(100)]
        public string Shell { get; set; }

        [Required,StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Shape { get; set; }

        [StringLength(100)]
        public string Color { get; set; }

        [StringLength(100)]
        public string Material { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Continent { get; set; }

        [StringLength(255)]
        public string Note { get; set; }        

        public override string ToString()
        {
            string strReturn = "Age: " + this.Age + "\n" + "Alcohol: " + this.Alcohol + "\n" +
                "Alcohol Type: " + this.AlcoholType + "\n" + "City: " + this.City + "\n" + "Color: " +
                this.Color + "\n" + "Content: " + this.Content + "\n" + "Continent: " + this.Continent + "\n" +
                "Country: " + this.Continent + "\n" + "ID: " + this.Id + "\n" + "Manufacturer: " +
                this.Manufacturer + "\n" + "Material: " + this.Material + "\n" + "Name: " + this.Name + "\n" +
                "Note: " + this.Note + "\n" + "Shape: " + this.Shape + "\n" + "Shell: " + this.Shell + "\n";
            return strReturn;
        }

        public static string Serialize(Bottle b)
        {

            return b.Age + "#" + b.Alcohol + "#" + b.AlcoholType + "#" +
                        b.City + "#" + b.Color + "#" + b.Content + "#" + b.Continent + "#"
                        + b.Country + "#" + b.Id + "#" + b.Manufacturer + "#" + b.Material
                         + "#" + b.Name + "#" + b.Note + "#" + b.Shape + "#" + b.Shell + "\n";
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
            Bottle bottle = new Bottle();
            try
            {
                bottle.Age = int.Parse(split[0]);
                bottle.Alcohol = split[1];
                bottle.AlcoholType = split[2];
                bottle.City = split[3];
                bottle.Color = split[4];
                bottle.Content = split[5];
                bottle.Continent = split[6];
                bottle.Country = split[7];
                bottle.Id = int.Parse(split[8]);
                bottle.Manufacturer = split[9];
                bottle.Material = split[10];
                bottle.Name = split[11];
                bottle.Note = split[12];
                bottle.Shape = split[13];
                bottle.Shell = split[14];
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }
            return bottle;
        }
    }

    public class MiniatureBottleContext : DbContext
    {
        public DbSet<BottleAdd> Bottles { get; set; }
        public DbSet<BottleDetail> BottleDetails { get; set; }
        public DbSet<BottleDrinkDetail> BottleDrinkDetails { get; set; }
        public DbSet<BottleOrigin> BottleOrigins { get; set; }
        public DbSet<BottleImage> BottleImages { get; set; }        
    }
}