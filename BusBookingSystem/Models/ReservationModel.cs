using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusBookingSystem.Models
{
    public class ReservationModel
    {
        [Key]
        public int ReserveId { get; set; }
        public String Id { get; set; }
        [ForeignKey("BusModel")]
        public int? BusId { get; set; }
        [Required]
        public int NoOfSeats { get; set; }

        public int TotalAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfTravel { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBooking { get; set; }
        [Required]
        public String BoardingPoint { get; set; }
        [Required]
        public String DestinationPoint { get; set; }
        [Required]
        public String BusType { get; set; }

        public String SeatNumber { get; set; }
        [Required]
        public String SeatType { get; set; }
        public BusModel BusModel { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser AspNetUsers { get; set; }

    }
}