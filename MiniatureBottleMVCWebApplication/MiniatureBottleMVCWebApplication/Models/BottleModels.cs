using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniatureBottleMVCWebApplication.Models
{
    public class Bottle
    {
        [Required]
        public int ID { get; set; }

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
    }

    public class MiniatureBottleContext : DbContext
    {
        public DbSet<Bottle> Bottles { get; set; }
    }
}