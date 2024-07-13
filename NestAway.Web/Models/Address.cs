using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NestAway.Web.Models
{
    public class Address
    {
        [ForeignKey("Accommodation")]
        public Guid Id { get; set; }

        [JsonIgnore]
        public virtual Accommodation Accommodation { get; set; }

        [Required(ErrorMessage = "You must enter your address")]
        [Display(Name = "Street Number")]
        public String StreetAndNumber { get; set; }

        [Display(Name = "Additional Address")]
        public String Complement { get; set; }

        [Required(ErrorMessage = "You must enter the postal code of your accommodation")]
        [Display(Name = "Postal Code")]
        public String PostalCode { get; set; }

        [Required(ErrorMessage = "You must enter the destination city.")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "You must enter the destination country")]
        [Display(Name = "Country")]
        public String Country { get; set; }

        public override String ToString()
        {
            return StreetAndNumber + ", " + Complement + "\n" + PostalCode + " " + City + ", " + Country;
        }

        public String ShortAddress()
        {
            return City + ", " + Country;
        }
    }
}
