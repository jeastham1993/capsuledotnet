namespace CapsuleDotNet.Models{
    public enum TrackDirection { START_DATE, END_DATE }

    public static class TrackDirectionExtensions
    {
        public static string ToFriendlyString(this TrackDirection me)
        {
            switch (me)
            {
                case TrackDirection.END_DATE:
                    return "end_date";
                case TrackDirection.START_DATE:
                    return "start_date";
                default:
                    return "";
            }
        }
    }
}