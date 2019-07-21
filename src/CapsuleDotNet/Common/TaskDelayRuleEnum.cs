namespace CapsuleDotNet.Common{
    public enum TaskDelayRule { TRACK_START, END_DATE, LAST_TASK }

    public static class TaskDelayRuleExtensions
    {
        public static string ToFriendlyString(this TaskDelayRule me)
        {
            switch (me)
            {
                case TaskDelayRule.TRACK_START:
                    return "track_start";
                case TaskDelayRule.LAST_TASK:
                    return "last_task";
                case TaskDelayRule.END_DATE:
                    return "end_date";
                default:
                    return "";
            }
        }
    }
}