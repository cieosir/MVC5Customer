using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Customer.Models;

namespace Customer.Controllers
{
    public class 客戶資料Controller : Controller
    {
        private 客戶資料管理Entities db = new 客戶資料管理Entities();

        // GET: 客戶資料
        public ActionResult Index()
        {
            var data = db.客戶資料
               .OrderByDescending(p => p.Id)
               .Take(3)
               .ToList();
               return View(data);
        }
        public ActionResult Index2()
        {
            var data = db.客戶資料
                .Take(3)
                .Select(p => new 客戶資料類別 {
                    客戶名稱 = p.客戶名稱,
                    統一編號 = p.統一編號,
                    電話 = p.電話,
                    傳真 = p.傳真,
                    地址 = p.地址,
                    Email = p.Email
                });
            return View(data);
        }
        //public ActionResult 新增一筆資料()
        //{
        //    return View();
        //}
        public ActionResult 新增一筆資料(客戶資料類別 data)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            var 客戶資料 = new 客戶資料()
            {
                客戶名稱 = data.客戶名稱,
                統一編號 = data.統一編號,
                電話 = data.電話,
                傳真 = data.傳真,
                地址 = data.地址,
                Email = data.Email
                //客戶名稱 = "花都豐田汽車",
                //統一編號 = "23456789",
                //電話 = "093456789",
                //傳真 = "093456789",
                //地址 = "花蓮市德安鄉100號",
                //Email = "123@gmail.com"

            };
            this.db.客戶資料.Add(客戶資料);
            this.db.SaveChanges();
            return RedirectToAction("Index2");
        }
        //public ActionResult 更新一筆資料(int id)
        //{
        //    var data = db.客戶資料.Find(id);
        //    return View(data);
        //}
        public ActionResult 更新一筆資料(int id ,客戶資料類別 data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            var one = db.客戶資料.Find(id);
            one.客戶名稱 = data.客戶名稱;
            one.統一編號 = data.統一編號;
            one.電話 = data.電話;
            one.傳真 = data.傳真;
            one.地址 = data.地址;
            one.Email = data.Email;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult 刪除一筆資料(int Id)

        {
            var item = db.客戶資料.Find(Id);
            if (item==null)
            {
                return HttpNotFound();
            }
            db.客戶資料.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult Search()
        {
            var data = db.客戶資料
                .Take(3)
                .ToList();
            return Search();

        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.客戶資料.Add(客戶資料);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            db.客戶資料.Remove(客戶資料);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
