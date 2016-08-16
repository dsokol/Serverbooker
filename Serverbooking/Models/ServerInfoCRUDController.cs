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
    public class ServerInfoCRUDController : Controller
    {
        private ServerInfoEntities db = new ServerInfoEntities();

        // GET: CRUD
        public async Task<ActionResult> ServerData()
        {
            return View(await db.InfoServers.ToListAsync());
        }

        // GET: CRUD/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoServer infoServer = await db.InfoServers.FindAsync(id);
            if (infoServer == null)
            {
                return HttpNotFound();
            }
            return View(infoServer);
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ServerID,Status,ServerName,Environment,ActiveBookingID")] InfoServer infoServer)
        {
            if (ModelState.IsValid)
            {
                db.InfoServers.Add(infoServer);
                await db.SaveChangesAsync();
                return RedirectToAction("ServerData");
            }

            return View(infoServer);
        }

        // GET: CRUD/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoServer infoServer = await db.InfoServers.FindAsync(id);
            if (infoServer == null)
            {
                return HttpNotFound();
            }
            return View(infoServer);
        }

        // POST: CRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ServerID,Status,ServerName,Environment,ActiveBookingID")] InfoServer infoServer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infoServer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("ServerData");
            }
            return View(infoServer);
        }

        // GET: CRUD/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoServer infoServer = await db.InfoServers.FindAsync(id);
            if (infoServer == null)
            {
                return HttpNotFound();
            }
            return View(infoServer);
        }

        // POST: CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InfoServer infoServer = await db.InfoServers.FindAsync(id);
            db.InfoServers.Remove(infoServer);
            await db.SaveChangesAsync();
            return RedirectToAction("ServerData");
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
