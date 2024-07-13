using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NestAway.Web.Models
{
    public class Accommodation
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [Display(Name = "UserID")]
        [JsonIgnore]
        public virtual User User { get; set; }

        [Display(Name = "Offres")]
        [JsonIgnore]
        public virtual List<Offer> Offers { get; set; }

        [Display(Name = "Address")]
        public virtual Address Address { get; set; }

        [Display(Name = "Rules and Regulations")]
        public virtual HouseRules HouseRules { get; set; }

        [Display(Name = "Photo(s)")]
        public virtual List<Picture> Pictures { get; set; }

        [Display(Name = "Room(s)")]
        public virtual List<Room> Rooms { get; set; }

        [Required(ErrorMessage = "You must enter a name for your accommodation")]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "You must select the type of accommodation")]
        [Display(Name = "Type")]
        [RegularExpression("Apartment|House|Room in an apartment|Room in a house",
            ErrorMessage = "Please select a valid accommodation type")]
        public String Type { get; set; }

        [Required(ErrorMessage = "You must indicate the maximum number of travelers")]
        [Display(Name = "Maximum Travelers")]
        public int MaxTraveler { get; set; }

        [Required(ErrorMessage = "You must enter the description of your accommodation")]
        public String Description { get; set; }
    }
}
