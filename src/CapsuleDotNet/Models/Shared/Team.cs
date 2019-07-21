using System;

namespace CapsuleDotNet.Models{
    public class Team{
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}