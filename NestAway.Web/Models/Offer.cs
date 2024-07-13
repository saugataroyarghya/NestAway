using System;
using System.ComponentModel.DataAnnotations;

namespace NestAway.Web.Models
{
    public class Offer
    {
        public Guid Id { get; set; }

        //private User user;

        public Guid AccommodationId { get; set; }
        [Display(Name = "Accommodation")]
        public virtual Accommodation Accommodation { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.DateTime)]
        public DateTime AddingDateTime { get; set; }

        [Display(Name = "Start Availability")]
        [DataType(DataType.Date)]
        public DateTime StartAvailability { get; set; }

        [Display(Name = "End Availability")]
        [DataType(DataType.Date)]
        public DateTime EndAvailability { get; set; }

        [Display(Name = "Price per night")]
        public double PricePerNight { get; set; }

        [Display(Name = "Cleaning Fee")]
        public double CleaningFee { get; set; }

        public Offer()
        {
            this.AddingDateTime = DateTime.Now;
        }
    }
}
