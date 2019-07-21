namespace CapsuleDotNet.Common{
    public enum Direction{
        ASCENDING,
        DESCENDING
    }

    public static class DirectionExtensions
    {
        public static string ToFriendlyString(this Direction me)
        {
            switch (me)
            {
                case Direction.ASCENDING:
                    return "ascending";
                case Direction.DESCENDING:
                    return "descending";
                default:
                    return "";
            }
        }
    }
}