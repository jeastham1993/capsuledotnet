using System;

namespace CapsuleDotNet.Models{
    public class Milestone
    {
        private Milestone(string name, int probability){
            this.Name = name;
            this.Probability = probability;
        }

        public static Milestone Create(string name, int probability){
            if (string.IsNullOrEmpty(name)){
                throw new ArgumentException("Name cannot be null or empty");
            }

            if (probability > 100){
                probability = 100;
            }

            return new Milestone(name, probability);
        }
        public long Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Complete { get; set; }

        public int Probability { get; set; }

        public int DaysUntilStale { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}