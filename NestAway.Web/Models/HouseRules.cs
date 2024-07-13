using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NestAway.Web.Models
{
    public class HouseRules
    {
        [ForeignKey("Accommodation")]
        public Guid Id { get; set; }

        public virtual Accommodation Accommodation { get; set; }

        [Display(Name = "Minimum arrival time")]
        [Required(ErrorMessage = "You must indicate the minimum arrival time")]
        [DataType(DataType.Time)]
        public TimeSpan ArrivalHour { get; set; }

        [Display(Name = "Maximum departure time")]
        [Required(ErrorMessage = "You must indicate the maximum departure time")]
        [DataType(DataType.Time)]
        public TimeSpan DepartureHour { get; set; }

        [Display(Name = "Pets Allowed")]
        public bool PetAllowed { get; set; }

        [Display(Name = "Party Allowed")]
        public bool PartyAllowed { get; set; }

        [Display(Name = "Smoke Allowed")]
        public bool SmokeAllowed { get; set; }

        public override string ToString()
        {
            return "Pets : " + (PetAllowed ? "Yes" : "No") + " -- Party : " + (PartyAllowed ? "Yes" : "No") + " -- Smoking : " + (SmokeAllowed ? "Yes" : "No")
                + " || Arrival Time : " + ArrivalHour.ToString("hh\\hmm") + " -- Departure Time : " + DepartureHour.ToString("hh\\hmm");
        }
    }
}
