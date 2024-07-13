using System;

namespace NestAway.Web.Models
{
    public class Bookmark
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid OfferId { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
