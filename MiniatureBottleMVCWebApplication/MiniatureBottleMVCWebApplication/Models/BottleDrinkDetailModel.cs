using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniatureBottleMVCWebApplication.Models
{
    public class BottleDrinkDetail
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
}