using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Serverbooking.Models
{
    public class BookingInfoesCRUDController : Controller
    {
        private ServerInfoEntities db = new ServerInfoEntities();

        // GET: BookingInfoesCRUD
        public async Task<ActionResult> BookingData()
        {
            var bookingInfo = db.BookingInfo.Include(b => b.InfoServer);
            return View(await bookingInfo.ToListAsync());
        }

        // GET: BookingInfoesCRUD/Details/5
        public async Task<ActionResult> BookingDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInfo bookingInfo = await db.BookingInfo.FindAsync(id);
            if (bookingInfo == null)
            {
                return HttpNotFound();
            }
            return View(bookingInfo);
        }

        // GET: BookingInfoesCRUD/Create
        public ActionResult BookingCreate()
        {
            ViewBag.ServerID = new SelectList(db.InfoServers, "ServerID", "ServerID");
            return View();
        }

        // POST: BookingInfoesCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BookingCreate([Bind(Include = "BookingID,ServerID,UserID,CheckInTime,CheckOutTime")] BookingInfo bookingInfo)
        {
            if (ModelState.IsValid)
            {
                db.BookingInfo.Add(bookingInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("BookingData");
            }

            ViewBag.ServerID = new SelectList(db.InfoServers, "ServerID", "ServerID", bookingInfo.ServerID);
            return View(bookingInfo);
        }

        // GET: BookingInfoesCRUD/Edit/5
        public async Task<ActionResult> BookingEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInfo bookingInfo = await db.BookingInfo.FindAsync(id);
            if (bookingInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServerID = new SelectList(db.InfoServers, "ServerID", "ServerID", bookingInfo.ServerID);
            return View(bookingInfo);
        }

        // POST: BookingInfoesCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BookingEdit([Bind(Include = "BookingID,ServerID,UserID,CheckInTime,CheckOutTime")] BookingInfo bookingInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("BookingData");
            }
            ViewBag.ServerID = new SelectList(db.InfoServers, "ServerID", "ServerID", bookingInfo.ServerID);
            return View(bookingInfo);
        }

        // GET: BookingInfoesCRUD/Delete/5
        public async Task<ActionResult> BookingDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInfo bookingInfo = await db.BookingInfo.FindAsync(id);
            if (bookingInfo == null)
            {
                return HttpNotFound();
            }
            return View(bookingInfo);
        }

        // POST: BookingInfoesCRUD/Delete/5
        [HttpPost, ActionName("BookingDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BookingInfo bookingInfo = await db.BookingInfo.FindAsync(id);
            db.BookingInfo.Remove(bookingInfo);
            await db.SaveChangesAsync();
            return RedirectToAction("BookingData");
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
