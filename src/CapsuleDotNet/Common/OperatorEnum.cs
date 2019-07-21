namespace CapsuleDotNet.Common
{
    public enum Operator
    {
        IS,
        ISNOT,
        STARTSWITH,
        ENDSWITH,
        CONTAINS,
        ISGREATERTHAN,
        ISLESSTHAN,
        ISAFTER,
        ISBEFORE,
        ISOLDERTHAN,
        ISWITHINLAST,
        ISWITHINNEXT
    }

    public static class OperatorExtensions
    {
        public static string ToFriendlyString(this Operator me)
        {
            switch (me)
            {
                case Operator.CONTAINS:
                    return "contains";
                case Operator.ENDSWITH:
                    return "ends with";
                case Operator.IS:
                    return "is";
                case Operator.ISAFTER:
                    return "is after";
                case Operator.ISBEFORE:
                    return "is before";
                case Operator.ISGREATERTHAN:
                    return "is greater than";
                case Operator.ISLESSTHAN:
                    return "is less than";
                case Operator.ISNOT:
                    return "is not";
                case Operator.ISOLDERTHAN:
                    return "is older than";
                case Operator.ISWITHINLAST:
                    return "is within last";
                case Operator.ISWITHINNEXT:
                    return "is within next";
                case Operator.STARTSWITH:
                    return "starts with";
                default:
                    return "";
            }
        }
    }
}