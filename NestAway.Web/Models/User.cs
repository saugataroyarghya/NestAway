using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NestAway.Web.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        [PersonalData]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [PersonalData]
        [Display(Name = "Balance")]
        public Double Balance { get; set; }

        [Display(Name = "Accommodation(s)")]
        public virtual List<Accommodation> Accommodations { get; set; }

        [Display(Name = "Bookmarks")]
        public virtual List<Bookmark> Bookmarks { get; set; }
    }
}
