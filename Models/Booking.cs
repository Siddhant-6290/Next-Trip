using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMS.Models
{
    public enum BookingStatus
    {
        Confirmed,
        Cancelled
    }

    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User Customer { get; set; }

        [Required]
        public int TourPackageId { get; set; }

        [ForeignKey("TourPackageId")]
        public TourPackage TourPackage { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public decimal AmountPaid { get; set; }

        public DateTime? ConfirmedOn { get; set; }

        // New fields
        public BookingStatus Status { get; set; } = BookingStatus.Confirmed;

        public decimal? RefundAmount { get; set; }
    }
}
