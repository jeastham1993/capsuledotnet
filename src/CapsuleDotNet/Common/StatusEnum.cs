namespace CapsuleDotNet.Common{
    public enum Status { OPEN, COMPLETED, PENDING }

    public static class StatusExtensions
    {
        public static string ToFriendlyString(this Status me)
        {
            switch (me)
            {
                case Status.COMPLETED:
                    return "completed";
                case Status.OPEN:
                    return "open";
                case Status.PENDING:
                    return "pending";
                default:
                    return "";
            }
        }
    }
}