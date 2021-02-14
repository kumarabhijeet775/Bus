using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusBookingSystem.Models
{
    public class BusModel
    {
        [Key]
        public int BusId { get; set; }
        [Required]
        [StringLength(50)]
        public String BusRegistrionNo { get; set; }
        [Required]
        [StringLength(50)]
        public String BusName { get; set; }
        [Required]
        [StringLength(50)]
        public String BoardingPoint { get; set; }
        [Required]
        [StringLength(50)]
        public String DestinationPoint { get; set; }
        [Required]
        public int Fare { get; set; }
        [Required]
        public int NoOfSeats { get; set; }
        [Required]

        public int NoSleeperSeats { get; set; }
        [Required]

        public int NoSittingSeats { get; set; }
        [Required]
        [StringLength(5)]
        public String BusType { get; set; }
    }
}