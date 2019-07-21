namespace CapsuleDotNet.Common{
    public enum TaskRepeatFrequency { YEARLY, MONTHLY, WEEKLY }

    public static class TaskRepeatFrequencyExtensions
    {
        public static string ToFriendlyString(this TaskRepeatFrequency me)
        {
            switch (me)
            {
                case TaskRepeatFrequency.MONTHLY:
                    return "monthly";
                case TaskRepeatFrequency.WEEKLY:
                    return "weekly";
                case TaskRepeatFrequency.YEARLY:
                    return "yearly";
                default:
                    return "";
            }
        }
    }
}