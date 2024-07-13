using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NestAway.Web.Models
{
    public enum RoomTypes
    {
        Bedroom,
        Bathroom,
        Kitchen
    }

    public class Room
    {
        public Guid Id { get; set; }

        public Guid AccommodationId { get; set; }

        public RoomTypes RoomType { get; set; }

        [Display(Name = "Amenity(s)")]
        public virtual List<Amenity> Amenities { get; set; }

        public string AmenitiesStr()
        {
            return String.Join(", ", Amenities);
        }
    }
}
