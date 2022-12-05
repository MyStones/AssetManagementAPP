using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace WebAsset.Models
{
    public class DataAccess
    {
        //DataAccess Da = new DataAccess();
        List<Asset> stdList = new List<Asset>();
        //List<grade> grdList = new List<grade>();
        public List<Asset> GetAllAssets()
        {
            /* Asset Ast = new Asset();*/ /*{ AssetName = "AccessCard", AssetSku = 78912, AssetType = "Electronics", Description = "Swipe in for attendance", CreatedOn = DateTime.Now };*/
            using (var ctx = new AssetDbContext())
            {
                //ctx.Assets.Add(Ast);
                ctx.SaveChanges();
                stdList = ctx.Assets.ToList();

            }
            return stdList;
        }



        public int AddAsset(Asset astId)
        {
            int retValue = 0;
            if (astId != null)
            {

                using (var ctx = new AssetDbContext())
                {
                    ctx.Assets.Add(astId);
                    astId.CreatedOn = DateTime.Now;

                    retValue = ctx.SaveChanges();

                }


            }
            return retValue;

        }

        public Asset ChangeStudent(int astId)
        {
            Asset ast = new Asset();

            using (var ctx = new AssetDbContext())
            {
                ast = ctx.Assets.Where(s => s.AssetId == astId).Single();

            }

            return ast;

        }

        public Asset ChangeDeleteAsset(int astId)
        {
            Asset asst = new Asset();

            using (var ctx = new AssetDbContext())
            {
                asst = ctx.Assets.Where(a => a.AssetId == astId).Single();

            }

            return asst;

        }

        public int AddAddressById(int AssId/*, StudentAddress stdAdr*/)
        {

            int Added = 0;
            if (AssId > 0 /*&& stdAdr != null*/)
            {
                try
                {


                    using (var ctx = new AssetDbContext())
                    {
                        Asset s1 = ctx.Assets.Where(s => s.AssetId == AssId).Single();
                        if (s1 != null)
                        {
                            //stdAdr.StudentAddressId = stdId;
                            ctx.Assets.Add(s1);
                            Added = ctx.SaveChanges();
                        }
                    }
                }

                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return Added;
        }


        public int UpdateAsset(Asset s1)
        {
            int retValue = 0;

            using (var ctx = new AssetDbContext())
            {
                Asset std = ctx.Assets.Where(s => s.AssetSku == s1.AssetSku).Single();
                if (std != null)
                {

                    std.AssetName = s1.AssetName;
                    std.AssetType = s1.AssetType;
                    std.AssetSku = s1.AssetSku;
                    std.Price = s1.Price;
                    std.CountAsset = s1.CountAsset;
                    std.Description = s1.Description;
                    std.Vendor = s1.Vendor;
                    std.CreatedOn = s1.CreatedOn;

                    std.UpdatedOn = DateTime.Now;



                    ctx.Entry(std).State = System.Data.Entity.EntityState.Modified;

                    retValue = ctx.SaveChanges();
                }
            }

            return retValue;
        }

        public int DeleteAssets(int s1)
        {
            int retValue = 0;

            using (var ctx = new AssetDbContext())
            {
                Asset std = ctx.Assets.Find(s1);

                ctx.Entry(std).State = System.Data.Entity.EntityState.Deleted;

                retValue = ctx.SaveChanges();
            }


            return retValue;
        }

        //public void DeleteAssets(Asset Ast)
        //{



        //    try
        //    {
        //        using (var ctx = new AssetDbContext())
        //        {
        //            ctx.Assets.Attach(Ast);
        //            ctx.Entry(Ast).State = System.Data.Entity.EntityState.Deleted;
        //            ctx.SaveChanges();
        //        }
        //    }


        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        //public int DeleteAsset(int Ast)
        //{
        //    int i = 0;

        //    using (var ctx = new AssetDbContext())
        //    {
        //        Asset s1 = ctx.Assets.Find(Ast);
        //        if (s1 != null)
        //        {

        //            ctx.Entry(s1).State = System.Data.Entity.EntityState.Deleted;
        //            i = ctx.SaveChanges();
        //        }
        //    }
        //    return i;
        //}






    }
}

//public class StudentidandStudentName
//{
//    public int StudentId { get; set; }
//    public string StudentName { get; set; }
//}


//    public List<StudentidandStudentName> GetAllStudentidandStudentName()
//    {
//        List<StudentidandStudentName> std = new List<StudentidandStudentName>();
//        try
//        {
//            using (var ctx = new SchoolDbContext())
//            {
//                std = ctx.Students.Select(s => new StudentidandStudentName
//                {
//                    StudentId = s.studentid,
//                    StudentName = s.studentname


//                }).ToList();
//            }
//        }
//        catch (Exception ex)
//        {
//            throw ex;
//        }
//        return std;
//    }

//    public List<student> GetAllStudentsByGrade(int grdid)
//    {
//        using (var ctx = new SchoolDbContext())
//        {
//            stdList = ctx.Students.Where(s => s.GradeId == grdid).ToList();
//            //stdList = ctx.Students.Where(s => s.GradeId == grdid).OrderBy(s => s.studentname).ToList();
//            //stdList = ctx.Students.OrderBy(s => s.GradeId).ThenBy(s => s.studentname).ToList();

//        }
//        return stdList;
//    }


//public int ChangeStudent(int stdId/*string std*/)
//{
//    int i = 0;
//    using (var ctx = new AssetDbContext())
//    {
//        Asset s1 = ctx.Assets.Where(s => s.AssetId == stdId).Single();
//        if (s1 != null)
//        {
//            //s1.AssetName = std;
//            ctx.Entry(s1).State = System.Data.Entity.EntityState.Modified;
//            i = ctx.SaveChanges();
//        }
//    }
//    return i;
//}


//public void UpdateAssets(Asset s1)
//{
//    int retValue = 0;
//    try
//    {
//        using (var ctx = new AssetDbContext())
//        {
//            Asset std = ctx.Assets.Where(s => s.AssetId == s1.AssetId).Single();
//            if (std != null)
//            {

//                std.AssetName = s1.AssetName;
//                std.AssetSku = s1.AssetSku;
//                std.AssetType = s1.AssetType;
//                std.CreatedOn = s1.CreatedOn;
//                std.Description = s1.Description;



//                ctx.Entry(std).State = System.Data.Entity.EntityState.Deleted;

//                retValue = ctx.SaveChanges();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}
