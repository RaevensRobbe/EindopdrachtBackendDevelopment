using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EindopdrachtBackendDevelopment.Models;

namespace EindopdrachtBackendDevelopment.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RaceNumber { get; set; }
        public string Nationality { get; set; }


        
        public int CareerId { get; set; }
        public Career Career { get; set; } 


        public int TeamId { get; set; }
    }
}
