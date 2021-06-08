using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kutuphane.Models.Siniflar
{
    public class Kitaplar
    {
        [Key]
        public int BookID { get; set; }
        public string Category { get; set; }
        public string Writer { get; set; }
        public string BookName { get; set; }
        public string Summary { get; set; }
        public string Price { get; set; }
        public string PageNumber { get; set; }
        public string BookImage { get; set; }
        public int Producttype { get; set; }
       
    }
}