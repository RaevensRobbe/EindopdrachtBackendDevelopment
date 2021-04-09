using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eindopdracht.Models
{
    public class Sponsor
    {
        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
        public List<TeamSponsors> TeamSponsors { get; set; }
    } 
}
