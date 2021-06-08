using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kutuphane.Models.Siniflar
{
    public class Exchange
    {

        [Key]

        public int BookID { get; set; }
        public string BookWriter { get; set; }
        public int BookPage { get; set; }
        public string BookName { get; set; }
        public string Location { get; set; }
        public string BookImage { get; set; }
        public string Username { get; set; }
    }
}