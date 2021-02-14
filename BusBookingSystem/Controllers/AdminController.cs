using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusBookingSystem.Models;

namespace BusBookingSystem.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin
        public ActionResult DashBoard()
        {
            var user = context.Users.SingleOrDefault(x => x.Email == "admin@gmail.com");

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult BusDetails()
        {
            return View(context.BusModel.ToList());
        }

        public ActionResult EditBus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusModel Bus = context.BusModel.Find(id);
            if (Bus == null)
            {
                return HttpNotFound();
            }
            return View(Bus);
        }
        [HttpPost]
        public ActionResult EditBus(BusModel dobj)
        {
            if (ModelState.IsValid)
            {
                context.Entry(dobj).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("BusDetails");
            }
            return View(dobj);

        }
        [HttpPost]
        public ActionResult DeleteBus(BusModel dobj)
        {

            BusModel bus = context.BusModel.Find(dobj.BusId);

            context.BusModel.Remove(bus);
            context.SaveChanges();
            return RedirectToAction("DashBoard");

        }
        [HttpGet]
        public ActionResult DeleteBus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusModel bus = context.BusModel.Find(id);

            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);

        }

        public ActionResult AddBus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBus(BusModel dobj)
        {
            if (ModelState.IsValid)
            {
                context.BusModel.Add(dobj);
                context.SaveChanges();

                return RedirectToAction("BusDetails");
            }
            return View(dobj);
        }

        public ActionResult BusDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusModel bus = context.BusModel.Find(id);

            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        public ActionResult PassengerDetails()
        {
            return View(context.Users.ToList());
        }
        public ActionResult BookingDetails()
        {
            return View(context.ReservationModel.ToList());
        }
        public ActionResult TransactionDetails()
        {
            return View(context.TransactionModel.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

    }
}