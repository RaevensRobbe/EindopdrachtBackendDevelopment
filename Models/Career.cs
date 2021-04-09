using System;
using System.ComponentModel.DataAnnotations;

namespace Eindopdracht.Models
{
    public class Career
    {
        public int CareerId { get; set; }
        public int Wins { get; set; }
        public int Poles { get; set; }
        public int FastestLaps { get; set; }
        public int DriverChampionships { get; set; }
    }
}
