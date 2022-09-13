using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubSystemsProject.DAL;
using ClubSystemsProject.Models;

namespace ClubSystemsProject.Controllers
{
    public class MembershipController : Controller
    {
        private ClubContext db = new ClubContext();

        // GET: Membership
        public ActionResult Index()
        {
            var memberships = db.Memberships.Include(m => m.Member).Include(m => m.MembershipType);
            return View(memberships.ToList());
        }

        // GET: Membership/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // GET: Membership/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Members, "ID", "ID");
            ViewBag.MembershipTypeID = new SelectList(db.MembershipTypes, "MembershipTypeID", "MemType");
            return View();
        }

        // POST: Membership/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MembershipID,MembershipTypeID,MemberID,Balance")] Membership membership)
        {
            if (db.Memberships.Any(x => x.MembershipTypeID == membership.MembershipTypeID && x.MemberID == membership.MemberID))
            {
                ViewBag.Message = "One member cannot have two memberships of the same type";
                return Create();
                
            }

            if (ModelState.IsValid)
            {
                db.Memberships.Add(membership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberID = new SelectList(db.Members, "ID", "LastName", membership.MemberID);
            ViewBag.MembershipTypeID = new SelectList(db.MembershipTypes, "MembershipTypeID", "MembershipTypeID", membership.MembershipTypeID);
            return View(membership);
        }

        // GET: Membership/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "ID", "ID", membership.MemberID);
            ViewBag.MembershipTypeID = new SelectList(db.MembershipTypes, "MembershipTypeID", "MemType", membership.MembershipTypeID);
            return View(membership);
        }

        // POST: Membership/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MembershipID,MembershipTypeID,MemberID,Balance")] Membership membership)
        {
            if (db.Memberships.Count(x => x.MembershipTypeID == membership.MembershipTypeID && x.MemberID == membership.MemberID) > 0)
            {
                ViewBag.Message = "One member cannot have two memberships of the same type";
                return Edit(membership.MembershipID);
            }

            if (ModelState.IsValid)
            {
                db.Entry(membership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Members, "ID", "LastName", membership.MemberID);
            ViewBag.MembershipTypeID = new SelectList(db.MembershipTypes, "MembershipTypeID", "MembershipTypeID", membership.MembershipTypeID);
            return View(membership);
        }

        // GET: Membership/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // POST: Membership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membership membership = db.Memberships.Find(id);
            db.Memberships.Remove(membership);
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
