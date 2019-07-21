namespace CapsuleDotNet.Common
{
    public enum DurationBasis { FIXED, HOUR, DAY, WEEK, MONTH, QUARTER, YEAR }

    public static class DurationBasisExtensions
    {
        public static string ToFriendlyString(this DurationBasis me)
        {
            switch (me)
            {
                case DurationBasis.FIXED:
                    return "fixed";
                case DurationBasis.DAY:
                    return "day";
                case DurationBasis.HOUR:
                    return "hour";
                case DurationBasis.MONTH:
                    return "month";
                case DurationBasis.QUARTER:
                    return "quarter";
                case DurationBasis.WEEK:
                    return "week";
                case DurationBasis.YEAR:
                    return "year";
                default:
                    return "";
            }
        }
    }
}