namespace CapsuleDotNet.Models{
    public enum CaptureRule { CASEFILE, OPPORTUNITY }

    public static class CaptureRuleExtensions
    {
        public static string ToFriendlyString(this CaptureRule me)
        {
            switch (me)
            {
                case CaptureRule.CASEFILE:
                    return "casefile";
                case CaptureRule.OPPORTUNITY:
                    return "opportunity";
                default:
                    return "";
            }
        }
    }
}