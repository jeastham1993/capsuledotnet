namespace CapsuleDotNet.Models{
    public enum DaysAfterRule { TRACK_START, LAST_TASK }

    public static class DaysAfterRuleExtensions
    {
        public static string ToFriendlyString(this DaysAfterRule me)
        {
            switch (me)
            {
                case DaysAfterRule.LAST_TASK:
                    return "last_track";
                case DaysAfterRule.TRACK_START:
                    return "track_start";
                default:
                    return "";
            }
        }
    }
}