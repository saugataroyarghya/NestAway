using System;
using System.Collections.Generic;

namespace NestAway.Web.Models
{
    public enum AmenityTypes
    {
        SingleBed,
        DoubleBed,
        TV,
        Closet,
        Bathtub,
        Shower,
        WashingMachine,
        Oven,
        Freezer,
        CoffeeMaker
    }

    public class Amenity
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public AmenityTypes AmenityType { get; set; }

        public override string ToString()
        {
            return Enum.GetName(typeof(AmenityTypes), this.AmenityType);
        }
    }

    public static class AmenityTools
    {
        public static List<string> AmenitiesForRoom(string roomType)
        {
            return roomType switch
            {
                "Bedroom" => new List<string> { "SingleBed", "DoubleBed", "TV", "Closet" },
                "Bathroom" => new List<string> { "Bathtub", "Shower", "WashingMachine" },
                "Kitchen" => new List<string> { "Oven", "Freezer", "CoffeeMaker" },
                _ => null,
            };
        }
    }
}
