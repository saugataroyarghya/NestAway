using System;
using System.ComponentModel.DataAnnotations;

namespace NestAway.Web.Models
{
    public class Booking
    {
        public Guid Id { get; set; }

        public Guid OfferId { get; set; }

        [Display(Name = "Offer")]
        public virtual Offer Offer { get; set; }

        public string UserId { get; set; }

        [Display(Name = "UserID")]
        public virtual User User { get; set; }

        [Display(Name = "Reservation Date")]
        [DataType(DataType.DateTime)]
        public DateTime BookingDateTime { get; set; }

        [Display(Name = "Date of Arrival")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Time of Arrival")]
        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        [Display(Name = "Date of Departure")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Time of Departure")]
        [DataType(DataType.Time)]
        public TimeSpan DepartureTime { get; set; }

        [Display(Name = "Number of Traveler(s)")]
        public int NbPerson { get; set; }

        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }

        public Booking()
        {
            this.BookingDateTime = DateTime.Now;
        }
    }
}
