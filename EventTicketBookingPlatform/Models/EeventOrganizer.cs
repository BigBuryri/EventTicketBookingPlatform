using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventTicketBookingPlatform.Models
{
    public class EeventOrganizer
    {
        [Key]
        public int OrganizerId { get; set; }
        public string? NameOrganization { get; set; }
        public string? ContactInformation { get; set; }

        
    }
}
