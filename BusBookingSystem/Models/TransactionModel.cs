using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BusBookingSystem.Models;

namespace BusBookingSystem.Models
{
    public class TransactionModel
    {
        [Key]
        public int TranscationId { get; set; }
        [Required]
        [StringLength(16)]
        public String CardNumber { get; set; }
        [Required]
        [StringLength(5)]
        public String ExpiryDate { get; set; }
        [Required]
        public int Cvv { get; set; }
        [Required]
        [StringLength(10)]
        public String TransactionType { get; set; }
        public String Id { get; set; }
        [ForeignKey("BusModel")]
        public int? BusId { get; set; }
        public BusModel BusModel { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser AspNetUsers { get; set; }


    }
}