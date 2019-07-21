namespace CapsuleDotNet.Models{
    public class ActivityType
    {
        private ActivityType(){}

        private ActivityType(string name){
            this.Name = name;

            this.UpdateLastContacted = true;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public ActivityTypeIcon Icon { get; set; }

        public bool UpdateLastContacted { get; set; }
    }
}