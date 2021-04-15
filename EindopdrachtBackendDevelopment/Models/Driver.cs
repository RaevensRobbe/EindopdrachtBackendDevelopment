using System;
using System.ComponentModel.DataAnnotations;

namespace Eindopdracht.Models
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
    }
}
