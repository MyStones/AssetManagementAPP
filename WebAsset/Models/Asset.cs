using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAsset.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [Required(ErrorMessage = "Fill the Name space")]
        [Display(Name = "Asset Name:")]
        [StringLength(30, ErrorMessage = "Name not to be exceed")]
        public string AssetName { get; set; }

        public string AssetType { get; set; }

        [Required(ErrorMessage = "Enter the Serial Number")]
        public int AssetSku { get; set; }

        [Required(ErrorMessage = "Enter the right price")]
        //[Range(1,1000000)]
        public int Price { get; set; }

        [Required(ErrorMessage = "Enter the number of assets")]
        //[Range(1, 10000)]
        public int CountAsset { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Enter the vendor name")]
        public string Vendor { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }

        //[DataType(DataType.Date)]
        public DateTime? UpdatedOn { get; set; }
    }

}