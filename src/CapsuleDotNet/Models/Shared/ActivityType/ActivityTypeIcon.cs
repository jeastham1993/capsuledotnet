namespace CapsuleDotNet.Models{
    public class ActivityTypeIcon
    {
        private ActivityTypeIcon(){}

        private ActivityTypeIcon(string displayName){
            this.DisplayName = displayName;
        }

        public static ActivityTypeIcon Create(string displayName){
            return new ActivityTypeIcon(displayName);
        }

        public int Order { get; set; }

        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string IconName { get; set; }
        
        public bool IsSystem { get; set; }
    }
}