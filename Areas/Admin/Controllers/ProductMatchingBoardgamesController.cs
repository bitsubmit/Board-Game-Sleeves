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
    public class ProductMatchingBoardgamesController : Controller
    {
        private bgs db = new bgs();

        // GET: Admin/ProductMatchingBoardgames
        public ActionResult Index()
        {
            var productMatchingBoardgames = db.ProductMatchingBoardgames.Include(p => p.BoardGame).Include(p => p.Product);
            return View(productMatchingBoardgames.ToList());
        }

        // GET: Admin/ProductMatchingBoardgames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMatchingBoardgame productMatchingBoardgame = db.ProductMatchingBoardgames.Find(id);
            if (productMatchingBoardgame == null)
            {
                return HttpNotFound();
            }
            return View(productMatchingBoardgame);
        }

        // GET: Admin/ProductMatchingBoardgames/Create
        public ActionResult Create()
        {
            ViewBag.BoardGameId = new SelectList(db.BoardGames, "BoardGameId", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        // POST: Admin/ProductMatchingBoardgames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductMatchingBoardgameId,BoardGameId,ProductId")] ProductMatchingBoardgame productMatchingBoardgame)
        {
            if (ModelState.IsValid)
            {
                db.ProductMatchingBoardgames.Add(productMatchingBoardgame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BoardGameId = new SelectList(db.BoardGames, "BoardGameId", "Name", productMatchingBoardgame.BoardGameId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", productMatchingBoardgame.ProductId);
            return View(productMatchingBoardgame);
        }

        // GET: Admin/ProductMatchingBoardgames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMatchingBoardgame productMatchingBoardgame = db.ProductMatchingBoardgames.Find(id);
            if (productMatchingBoardgame == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoardGameId = new SelectList(db.BoardGames, "BoardGameId", "Name", productMatchingBoardgame.BoardGameId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", productMatchingBoardgame.ProductId);
            return View(productMatchingBoardgame);
        }

        // POST: Admin/ProductMatchingBoardgames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductMatchingBoardgameId,BoardGameId,ProductId")] ProductMatchingBoardgame productMatchingBoardgame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productMatchingBoardgame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BoardGameId = new SelectList(db.BoardGames, "BoardGameId", "Name", productMatchingBoardgame.BoardGameId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", productMatchingBoardgame.ProductId);
            return View(productMatchingBoardgame);
        }

        // GET: Admin/ProductMatchingBoardgames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMatchingBoardgame productMatchingBoardgame = db.ProductMatchingBoardgames.Find(id);
            if (productMatchingBoardgame == null)
            {
                return HttpNotFound();
            }
            return View(productMatchingBoardgame);
        }

        // POST: Admin/ProductMatchingBoardgames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductMatchingBoardgame productMatchingBoardgame = db.ProductMatchingBoardgames.Find(id);
            db.ProductMatchingBoardgames.Remove(productMatchingBoardgame);
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
