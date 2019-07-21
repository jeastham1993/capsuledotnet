using System;
using System.Collections.Generic;

namespace CapsuleDotNet.Models
{
    public class TrackDefinition
    {
        private TrackDefinition(string description, string tag, string captureRule, string direction){
            this.Description = description;
            this.Tag = tag;
            this.CaptureRule = captureRule;
            this.Direction = direction;
        }

        public static TrackDefinition Create(string description, string tag, CaptureRule captureRule, TrackDirection direction){
            return new TrackDefinition(description, tag, nameof(captureRule), nameof(direction));
        }
        public int? Id { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string CaptureRule { get; private set; }
        public string Direction { get; private set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<TaskDefinition> TaskDefinitions { get; set; }
    }
}