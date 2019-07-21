using System;

namespace CapsuleDotNet.Models
{
    public class Track
    {
        private Track(string description, string direction, DateTime? trackDateOn){
            this.Description = description;
            this.Direction = direction;
            this.TrackDateOn = trackDateOn;
        }

        public static Track Create(string description, TrackDirection direction, DateTime? trackDateOn){
            return new Track(description, nameof(direction), trackDateOn);
        }
        public long? Id { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public DateTime? TrackDateOn { get; set; }

        //TODO: Add defintion, case and opportunity properties
    }
}