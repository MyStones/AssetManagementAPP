using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAsset.Models
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext() : base("name=AssetDbConnectionString")
        {
            Database.SetInitializer<AssetDbContext>(new AssetDbInitializer());
        }
        public DbSet<Asset> Assets { get; set; }
    }
}


