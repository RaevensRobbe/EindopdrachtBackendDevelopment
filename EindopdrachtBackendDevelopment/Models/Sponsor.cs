using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EindopdrachtBackendDevelopment.Models
{
    public class Sponsor
    {
        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
        
        /*
        public int TeamId { get; set; }
        public Team Team { get; set; }
        */

        [JsonIgnore]
        public List<TeamSponsors> TeamSponsors { get; set; }
    } 
}
