using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventTicketBookingPlatform.Models
{
    public class Users
    {
        [Key]

        public int Userid { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }


    }
}
