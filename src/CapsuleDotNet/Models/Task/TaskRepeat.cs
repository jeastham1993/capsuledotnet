using CapsuleDotNet.Common;

namespace CapsuleDotNet.Models{
    public class TaskRepeat{
        private TaskRepeat(string frequency, int interval, string on){
            this.Frequency = frequency;
            this.Interval = interval;
            this.On = on;
        }

        public static TaskRepeat Create(TaskRepeatFrequency frequency, int interval, string on){
            return new TaskRepeat(nameof(frequency), interval, on);
        }

        public string Frequency { get; private set; }
        public int Interval { get; private set; }
        public string On { get; private set; }
        
        internal void Update(TaskRepeatFrequency frequency, int interval, string on){
            this.Frequency = nameof(frequency);
            this.Interval = interval;
            this.On = on;
        }
    }
}