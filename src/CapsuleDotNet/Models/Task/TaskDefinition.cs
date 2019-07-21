using System;

namespace CapsuleDotNet.Models
{
    public class TaskDefinition
    {
        private TaskDefinition(string description, string daysAfterRule, int daysAfter, int displayOrder){
            this.Description = description;
            this.DaysAfterRule = daysAfterRule;
            this.DaysAfter = daysAfter;
            this.DisplayOrder = displayOrder;
        }

        public static TaskDefinition Create(string description, DaysAfterRule daysAfterRule, int daysAfter, int displayOrder){
            return new TaskDefinition(description, nameof(daysAfterRule), daysAfter, displayOrder);
        }
        public long Id { get; set; }
        public string Description { get; set; }
        public string DaysAfterRule { get; private set; }
        public int DaysAfter { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}