using Microsoft.AspNet.Identity;
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
    public class ProfilesController : Controller
    {
        private MIS4200ContextTeam3 db = new MIS4200ContextTeam3();

        // GET: Profiles
        public ActionResult Index(string searchString)
        {
            var profilecnt = db.profile.OrderByDescending(p => p.leaderboard.Count).ThenBy(p => p.lastName);
            if (!String.IsNullOrEmpty(searchString))

            {
                profilecnt = db.profile.Where(p => p.lastName.Contains(searchString) || p.firstName.Contains(searchString)).OrderByDescending(p => p.leaderboard.Count).ThenBy(p => p.lastName);
            }
            return View(profilecnt.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "profileID,lastName,firstName,office,position,hireDate")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                //profile.profileID = Guid.NewGuid();
                Guid profileID;
                Guid.TryParse(User.Identity.GetUserId(), out profileID);
                profile.profileID = profileID;
                try
                {
                    db.profile.Add(profile);
                    db.SaveChanges();
                }
                catch
                {
                    return View("DuplicateUsers");
                }
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            Guid profileID;
            Guid.TryParse(User.Identity.GetUserId(), out profileID);
            if (id == profileID)
            {
                return View(profile);
            }
            else
            {
                return View ("CantEdit");
            }
    
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "profileID,lastName,firstName,office,position,hireDate")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Profile profile = db.profile.Find(id);
            db.profile.Remove(profile);
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
