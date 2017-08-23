using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Board_game_sleeves.Models;

namespace Board_game_sleeves.Areas.Admin.Controllers
{
    public class CardTypesController : Controller
    {
        private bgs db = new bgs();

        // GET: Admin/CardTypes
        public ActionResult Index()
        {
            return View(db.CardTypes.ToList());
        }

        // GET: Admin/CardTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardType cardType = db.CardTypes.Find(id);
            if (cardType == null)
            {
                return HttpNotFound();
            }
            return View(cardType);
        }

        // GET: Admin/CardTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CardTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardTypeId,xSize,ySize,Name")] CardType cardType)
        {
            if (ModelState.IsValid)
            {
                db.CardTypes.Add(cardType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cardType);
        }

        // GET: Admin/CardTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardType cardType = db.CardTypes.Find(id);
            if (cardType == null)
            {
                return HttpNotFound();
            }
            return View(cardType);
        }

        // POST: Admin/CardTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardTypeId,xSize,ySize,Name")] CardType cardType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardType);
        }

        // GET: Admin/CardTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardType cardType = db.CardTypes.Find(id);
            if (cardType == null)
            {
                return HttpNotFound();
            }
            return View(cardType);
        }

        // POST: Admin/CardTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardType cardType = db.CardTypes.Find(id);
            db.CardTypes.Remove(cardType);
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
        [HttpGet]
        public JsonResult getCardTypes()
        {
            var cardTypes = from card in db.CardTypes
                            select new
                            {
                                name = card.Name,
                                x = card.xSize,
                                y = card.ySize
                            };

            return Json(cardTypes, JsonRequestBehavior.AllowGet);
        }
    }
}
