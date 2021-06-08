using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Kutuphane.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Kitaplar> Kitaplars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
    }
}