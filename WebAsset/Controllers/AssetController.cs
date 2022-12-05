using WebAsset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAsset.Controllers
{
    public class AssetController : Controller
    {
        DataAccess Da = new DataAccess();
        private AssetDbContext db = new AssetDbContext();

        //public ActionResult Frontui()
        //{
        //    ViewBag.Title = "Asset Ninja";

        //    return View();
        //}
        public ActionResult Index()
        {
            ViewBag.Title = "Asset Ninja";

            return View();
        }

        public ActionResult GetAsset(string SortOrder)
        {
            ViewBag.AssetName = string.IsNullOrEmpty(SortOrder) ? "AssetName_desc" : "";
            ViewBag.AssetType = SortOrder == "AssetType" ? "AssetType_desc" : "AssetType";


            var emp = from s in db.Assets
                      select s;

            switch (SortOrder)
            {
                case "AssetName_desc":
                    emp = emp.OrderByDescending(s => s.AssetName);
                    break;
                case "AssetType":
                    emp = emp.OrderBy(s => s.AssetType);
                    break;
                case "AssetType_desc":
                    emp = emp.OrderByDescending(s => s.AssetType);
                    break;
                default:
                    emp = emp.OrderBy(s => s.AssetName);
                    break;
            }


            List<Asset> Ast = Da.GetAllAssets();
            return View(emp.ToList());


        }

        [HttpGet]
        public ActionResult AddAsset()
        {
          
                Asset Ast = new Asset();
                return View(Ast);
        

        }


        [HttpPost]
        public ActionResult AddAsset(Asset Ast)
        {
            if (ModelState.IsValid)
            {

                int iresult = Da.AddAsset(Ast);
                TempData["SuccessMessage"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View();


        }

        public ActionResult EditAssets(string SortOrder)
        {
            ViewBag.AssetName = string.IsNullOrEmpty(SortOrder) ? "AssetName_desc" : "";
            ViewBag.AssetSku = SortOrder == "AssetSku" ? "AssetSku_desc" : "AssetSku";


            var emp = from s in db.Assets
                      select s;

            switch (SortOrder)
            {
                case "AssetName_desc":
                    emp = emp.OrderByDescending(s => s.AssetName);
                    break;
                case "AssetSku":
                    emp = emp.OrderBy(s => s.AssetSku);
                    break;
                case "AssetSku_desc":
                    emp = emp.OrderByDescending(s => s.AssetSku);
                    break;
                default:
                    emp = emp.OrderBy(s => s.AssetName);
                    break;
            }
            List<Asset> Ast = Da.GetAllAssets();
            return View(emp.ToList());

        }


        [HttpGet]
        public ActionResult EditAsset(int id)
        {
            Asset iresult = Da.ChangeStudent(id);
            return View(iresult);

        }

        [HttpPost]
        public ActionResult EditAsset(Asset Ast)
        {
            if (ModelState.IsValid)
            {
                Da.UpdateAsset(Ast);
                TempData["SuccessMessage"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        

        [HttpGet]
        public ActionResult DeleteAsset(int id)
        {
            Asset iresult = Da.ChangeDeleteAsset(id);
            return View(iresult);

        }

        [HttpPost, ActionName("DeleteAsset")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAssetss(int id)
        {
            Da.DeleteAssets(id);
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAssets(string SortOrder)
        {

            ViewBag.AssetName = string.IsNullOrEmpty(SortOrder) ? "AssetName_desc" : "";
            ViewBag.AssetType = SortOrder == "AssetType" ? "AssetType_desc" : "AssetType";


            var emp = from s in db.Assets
                      select s;

            switch (SortOrder)
            {
                case "AssetName_desc":
                    emp = emp.OrderByDescending(s => s.AssetName);
                    break;
                case "AssetType":
                    emp = emp.OrderBy(s => s.AssetType);
                    break;
                case "AssetType_desc":
                    emp = emp.OrderByDescending(s => s.AssetType);
                    break;
                default:
                    emp = emp.OrderBy(s => s.AssetName);
                    break;
            }
            List<Asset> Ast = Da.GetAllAssets();
            return View(emp.ToList());

        }

        //[HttpGet]
        //public ActionResult DeleteAsset(int id)
        //{
        //    Asset A1 = Da.ChangeStudent(id);
        //    return View(A1);

        //}


        //[HttpPost]
        //public ActionResult DeleteAsset(Asset Ast)
        //{
        //    Da.DeleteAssets(Ast);
        //    TempData["SuccessMessage"] = "Saved Successfully";
        //    return RedirectToAction("GetAsset");
        //}

        //public ActionResult DeleteAssets()
        //{
        //    List<Asset> Ast = Da.GetAllAssets();
        //    return View(Ast);

        //}







    }

}