using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventTicketBookingPlatform.Models
{
    public class Eevent
    {
        [Key]
        public int EventId { get; set; }
        public string? EventTitle { get; set; }
        public DateTime? EventDate { get; set; }
        public string? EventLocation { get; set; }
        public string? EventDescription { get; set; }

        
    }
}
