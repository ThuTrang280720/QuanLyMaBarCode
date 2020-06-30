using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Đồ_Án_Win.Models;
using Đồ_Án_Win.Controlls;


namespace Đồ_Án_Win.Controlls
{
    public class SPController
    {
        public static int getIDFromDB()
        {
            using (var _context = new QRCodeForPrEntities())
            {
                var id = (from t in _context.SanPhams
                          select t.ID).ToList();

                if (id.Count <= 0)
                {
                    return 1;
                }
                else
                {
                    int i = 1;

                    List<SanPham> listSP = SPController.getListSP();

                    while (listSP.Where(p => p.ID==1).Count() != 0)
                    {
                        i++;
                    }

                    return i;
                }
            }
        }
        public static SanPham GetSPByID(int id)
        {
            using (var _context = new QRCodeForPrEntities())
            {
                var task = (from u in _context.SanPhams.AsEnumerable()
                            where u.ID == id
                            select u)
                            .Select(x => new SanPham
                            {
                                ID = x.ID,
                                MaSanPham = x.MaSanPham,
                                TenSanPham = x.TenSanPham,
                                GiaSanPham = x.GiaSanPham,
                                NgayIn = x.NgayIn,
                                ImgQCode = x.ImgQCode,
                                Img1D= x.Img1D
                            }).ToList();

                if (task.Count == 1)
                {
                    return task[0];
                }
                else
                {
                    return null;
                }
            }
        }
        public static bool AddSanPham(SanPham sanpham)
        {
            
                using (var _context = new QRCodeForPrEntities())
                {
                    _context.SanPhams.Add(sanpham);
                    _context.SaveChanges();
                    return true;
                }
           // load tu database leen 
        }
        public static SanPham getSanPham(string MaSanPham)
        {
            using (var _context = new QRCodeForPrEntities())
            {
                var sp = (from u in _context.SanPhams
                            where u.MaSanPham == MaSanPham
                            select u).ToList();
                if (sp.Count == 1)
                {
                    return sp[0];
                }
                else
                {
                    return null;
                }
            }
        }
        public static List<SanPham> getListSP()
        {
            using (var _context = new QRCodeForPrEntities())
            {
                var sp = (from u in _context.SanPhams.AsEnumerable()
                            select u)
                            .Select(x => new SanPham
                            {
                                ID= x.ID,
                                MaSanPham = x.MaSanPham,
                                TenSanPham = x.TenSanPham,
                                GiaSanPham = x.GiaSanPham,
                                NgayIn = x.NgayIn,
                                ImgQCode = x.ImgQCode,
                                Img1D =x.Img1D

                            }).ToList();
                return sp;
            }
        }

        public static List<SanPham> getListSP(string ID)
        {
            using (var _context = new QRCodeForPrEntities())
            {
                var sp = (from u in _context.SanPhams.AsEnumerable()
                            where u.MaSanPham.Contains(ID)
                            select u)
                            .Select(x => new SanPham
                            {
                                MaSanPham = x.MaSanPham,
                                TenSanPham = x.TenSanPham,
                                GiaSanPham = x.GiaSanPham,
                                NgayIn = x.NgayIn,
                                ImgQCode = x.ImgQCode,
                                Img1D =x.Img1D

                            }).ToList();
                return sp;
            }
        }
        public static bool DeleteSanPham(int ID)
        {
            try
            {
                using (var _context = new QRCodeForPrEntities())
                {
                    SanPham sp = (from t in _context.SanPhams
                                       where t.ID == ID
                                       select t).Single();

                    _context.SanPhams.Remove(sp);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
