using System;
using System.Collections.Generic;

namespace CapsuleDotNet.Common{
    internal static class OperatorEnumMapper{
        internal static Dictionary<Operator, string> _mappings;

        internal static Dictionary<Operator, string> Mapping{
            get{
                if (_mappings == null){
                    _mappings = new Dictionary<Operator, string>(Enum.GetNames(typeof(Operator)).Length);
                    _mappings.Add(Operator.IS, "is");
                    _mappings.Add(Operator.ISNOT, "is not");
                    _mappings.Add(Operator.STARTSWITH, "starts with");
                    _mappings.Add(Operator.ENDSWITH, "ends with");
                    _mappings.Add(Operator.CONTAINS, "contains");
                    _mappings.Add(Operator.ISGREATERTHAN, "is greater than");
                    _mappings.Add(Operator.ISLESSTHAN, "is less than");
                    _mappings.Add(Operator.ISAFTER, "is after");
                    _mappings.Add(Operator.ISBEFORE, "is before");
                    _mappings.Add(Operator.ISOLDERTHAN, "is older than");
                    _mappings.Add(Operator.ISWITHINLAST, "is within last");
                    _mappings.Add(Operator.ISWITHINNEXT, "is within next");
                }

                return _mappings;
            }
        }
    }
}