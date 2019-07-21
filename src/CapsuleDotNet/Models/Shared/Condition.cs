using System;
using System.Linq;
using CapsuleDotNet.Common;

namespace CapsuleDotNet.Models{
    public class Condition
    {
        private Condition(string field, string opertorString, object value){
            this.Field = field;
            this.Operator = opertorString;
            this.Value = value;
        }

        public static Condition Create(string field, Operator operatorEnum, object value){
            return new Condition(field, operatorEnum.ToFriendlyString(), value);
        }

        public string Field { get; private set; }

        public string Operator { get; private set; }

        public object Value { get; private set; }
    }
}