using System;
using System.ComponentModel.DataAnnotations;

namespace EindopdrachtBackendDevelopment.Models
{
    public class TeamSponsors
    {
        public int TeamId { get; set; }
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}