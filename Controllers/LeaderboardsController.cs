using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team3SemesterProject.DAL;
using Team3SemesterProject.Models;

namespace Team3SemesterProject.Controllers
{
    public class LeaderboardsController : Controller
    {
        private MIS4200ContextTeam3 db = new MIS4200ContextTeam3();

        // GET: Leaderboards
        public ActionResult Index()
        {
            var leaderboard = db.leaderboard.Include(l => l.coreValue).Include(l => l.profile);
            return View(leaderboard.ToList());
        }

        // GET: Leaderboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leaderboard leaderboard = db.leaderboard.Find(id);
            if (leaderboard == null)
            {
                return HttpNotFound();
            }
            return View(leaderboard);
        }

        // GET: Leaderboards/Create
        public ActionResult Create()
        {
            ViewBag.coreValueID = new SelectList(db.coreValue, "coreValueID", "coreValueName");
            ViewBag.profileID = new SelectList(db.profile, "profileID", "fullName");
            return View();
        }

        // POST: Leaderboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "leaderboardID,coreValueID,profileID,description")] Leaderboard leaderboard)
        {
            if (ModelState.IsValid)
            {
                db.leaderboard.Add(leaderboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coreValueID = new SelectList(db.coreValue, "coreValueID", "coreValueName", leaderboard.coreValueID);
            ViewBag.productID = new SelectList(db.profile, "profileID", "fullName", leaderboard.profileID);
            return View(leaderboard);
        }

        // GET: Leaderboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leaderboard leaderboard = db.leaderboard.Find(id);
            if (leaderboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.coreValueID = new SelectList(db.coreValue, "coreValueID", "coreValueName", leaderboard.coreValueID);
            ViewBag.profileID = new SelectList(db.profile, "profileID", "fullName", leaderboard.profileID);
            return View(leaderboard);
        }

        // POST: Leaderboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "leaderboardID,profileID,coreValueID,description")] Leaderboard leaderboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaderboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coreValueID = new SelectList(db.coreValue, "coreValueID", "coreValueName", leaderboard.coreValueID);
            ViewBag.profileID = new SelectList(db.profile, "profileID", "fullName", leaderboard.profileID);
            return View(leaderboard);
        }

        // GET: Leaderboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leaderboard leaderboard = db.leaderboard.Find(id);
            if (leaderboard == null)
            {
                return HttpNotFound();
            }
            return View(leaderboard);
        }

        // POST: Leaderboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leaderboard leaderboard = db.leaderboard.Find(id);
            db.leaderboard.Remove(leaderboard);
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
