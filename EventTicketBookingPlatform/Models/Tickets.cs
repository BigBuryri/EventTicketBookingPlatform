using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventTicketBookingPlatform.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        public int? EventId { get; set; }
        public int? Userid { get; set; }
        public decimal? TicketPrice { get; set; }
        public string? TicketStatus { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string TicketType  { get; set; }



}
}
