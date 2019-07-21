namespace CapsuleDotNet.Models{
    public class Participant
    {
        private Participant(){}

        private Participant(string address, string name, string role){
            this.Address = address; 
            this.Name = name;
            this.Role = role;
        }

        public static Participant Create(string address, string name, ParticipantRole role){
            return new Participant(address, name, role.ToFriendlyString());
        }
        public long? Id { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}