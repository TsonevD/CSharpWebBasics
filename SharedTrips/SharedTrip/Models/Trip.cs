using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SharedTrip.Data;

namespace SharedTrip.Models
{
    using static DataConstants;
    public class Trip
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string StartPoint { get; set; }
        [Required]
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        [MaxLength(SeatsMaxValue)]
        public int Seats { get; set; }
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<UserTrip> UserTrips { get; set; }
    }
}