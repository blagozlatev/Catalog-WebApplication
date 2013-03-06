using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniatureBottleMVCWebApplication.Models
{
    public class BottleImage
    {
        public BottleImage()
        {
            BottleImg = new byte[] { 0 };
        }

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BottleImageId { get; set; }

        public byte[] BottleImg { get; set; }
    }
}