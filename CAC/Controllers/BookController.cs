using CAC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAC.Controllers
{
    public class BookController : Controller
    {
        Books db = new Books();
        

        public ActionResult ListBook(string Search)
        {
            
            if(Search != null)
            {
                var book = db.Saches.Where(x => x.Tieude.Contains(Search) || x.Noidung.Contains(Search));
                return View(book);
            }
            else
            {
                 var book = db.Saches.ToList();
                return View(book);
            }
            
            
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("CreateBook")]
        public ActionResult CreateBook(Sach f)
        {
            //db.Saches.AddOrUpdate(f);
            Sach cc = new Sach();
            cc.Tieude = f.Tieude;
            cc.Hinh = f.Hinh;
            cc.Noidung = f.Noidung;
            cc.Gia = f.Gia;
            cc.Tacgia = f.Tacgia;
            cc.Theloai = f.Theloai;
            db.Saches.Add(cc);
            db.SaveChanges();
            return RedirectToAction("ListBook");
        }
        
        public ActionResult EditBook(int id)
        {
            var find = db.Saches.SingleOrDefault(x =>x.ID == id);
            return View(find);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("EditBook")]
        public ActionResult EditBook(Sach f, int id)
        {
            var find = db.Saches.SingleOrDefault(x => x.ID == id);


            find.Tieude = f.Tieude;
            find.Hinh = f.Hinh;
            find.Noidung = f.Noidung;
            find.Gia = f.Gia;
            find.Tacgia = f.Tacgia;
            find.Theloai = f.Theloai;
            db.Saches.AddOrUpdate(find);
            db.SaveChanges();
            return RedirectToAction("ListBook");
        }

        public ActionResult DeleteBook(int id)
        {
            var find = db.Saches.SingleOrDefault(x => x.ID == id);
            db.Saches.Remove(find);
            db.SaveChanges();
            return RedirectToAction("ListBook");
        }

        public ActionResult DetailsBook(int id)
        {
            var find = db.Saches.SingleOrDefault(x => x.ID == id);
            return View(find);
        }




    }
}