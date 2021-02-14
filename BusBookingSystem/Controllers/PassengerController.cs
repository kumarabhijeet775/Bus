using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using BusBookingSystem.Models;
using Microsoft.AspNet.Identity;

namespace BusBookingSystem.Controllers
{
    [Authorize]
    public class PassengerController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        public static String board ="";
        public static String destination = "";
        public static ReservationModel rs;
        public static BusModel bs;
        // GET: Passenger
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            ApplicationUser user = context.Users.SingleOrDefault(x => x.Id == UserId);
            if (user != null)
            {
                return View(user);
            }
            return HttpNotFound();
        }

        public ActionResult Bus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bus(BusModel obj)
        {
            board = (String)obj.BoardingPoint;
            destination = (String)obj.DestinationPoint;
            return RedirectToAction("BusResult");
        }
        public ActionResult BusResult()
        {
            IEnumerable<BusModel> b = context.BusModel.Where(x => x.BoardingPoint == board && x.DestinationPoint == destination);
            return View(b);
        }
        public ActionResult Next(int? id)
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
            bs = bus;
            return RedirectToAction("Reservation");
        }
        public ActionResult Reservation()
        {
            ReservationModel reserve = new ReservationModel
            {
                Id= User.Identity.GetUserId(),
                BusId = bs.BusId,
                BoardingPoint = bs.BoardingPoint,
                DestinationPoint = bs.DestinationPoint,
                BusType = bs.BusType
            };
           
            return View(reserve);
        }
        [HttpPost]
        public ActionResult Reservation( ReservationModel dobj)
        {
            dobj.DateOfBooking = DateTime.Now;
            dobj.TotalAmount=(int)dobj.NoOfSeats*(int)bs.Fare;
            rs = dobj;
            return RedirectToAction("Transaction");
        }

        public ActionResult Transaction()
        {
            ViewBag.Name = User.Identity.GetUserName();
            ViewBag.Amount = (int)rs.TotalAmount;
            ViewBag.From = rs.BoardingPoint;
            ViewBag.To = rs.DestinationPoint;
            TransactionModel transact = new TransactionModel
            {
                TranscationId = 1,
                Id = User.Identity.GetUserId(),
                BusId=bs.BusId
            };
            return View(transact);
        }
        [HttpPost]
        public ActionResult Transaction(TransactionModel dob)
        {
            context.ReservationModel.Add(rs);
            context.TransactionModel.Add(dob);
            context.SaveChanges();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("abhijeetk.hexaware@gmail.com");
                mail.To.Add(User.Identity.GetUserName());
                mail.Subject = "Booking";
                mail.Body = "Your Booking Has Been Successful";
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new System.Net.NetworkCredential("abhijeetk.hexaware@gmail.com", "Hexaware123@456$%^");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

            }
            catch
            {
                return RedirectToAction("Index");//After Booking
            }
            return RedirectToAction("Successful");

        }
        public ActionResult Successful()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult ReservationHistory()
        {
            var UserId = User.Identity.GetUserId();
            IEnumerable<ReservationModel> history = context.ReservationModel.Where(x => x.Id == UserId);
            if (history != null)
            {
                return View(history);
            }
            return RedirectToAction("NotFound");
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

    }
}