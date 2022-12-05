using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAsset.Models
{
    public class AssetDbInitializer : DropCreateDatabaseIfModelChanges<AssetDbContext>
    {
        protected override void Seed(AssetDbContext context)
        {
            var assets = new List<Asset> {
                new Asset{AssetName="Laptop",AssetSku=12345,AssetType="Electronics",Price=3400,Description="HP I5 Processor",CountAsset=34, Vendor="HP", CreatedOn=DateTime.Now },
                 new Asset{AssetName="Mouse",AssetSku=56789,AssetType="Electronics",Price=15400, Description=" Mouse",CountAsset=103, Vendor="Dell", CreatedOn=DateTime.Parse("2022/11/10" )},
                  new Asset{AssetName="Citrix Gateway",AssetSku=34567,AssetType="Software",Price=6400, Description="Citrix Gateway", CountAsset=4, Vendor="lenevo", CreatedOn=DateTime.Parse("2022/10/10" ) },
                   new Asset{AssetName="Pendrive",AssetSku=67489,AssetType="Electronics", Price=7400,Description="Pendrive", CountAsset=74, Vendor="Microsoft",  CreatedOn=DateTime.Parse("2022/09/10" ) },
                    new Asset{AssetName="HardDisk",AssetSku=78920,AssetType="Electronics", Price=52400,Description="HardDisk",CountAsset=24,  Vendor="Apple", CreatedOn=DateTime.Parse("2022/08/10" ) }
            };

            assets.ForEach(g => context.Assets.Add(g));
            context.SaveChanges();

        }
    }
}