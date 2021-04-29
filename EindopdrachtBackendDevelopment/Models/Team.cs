using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EindopdrachtBackendDevelopment.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Location { get; set; }
        public List<TeamSponsors> TeamSponsors { get; set; }
        public List<Driver> Drivers { get; set; }
    }
}
