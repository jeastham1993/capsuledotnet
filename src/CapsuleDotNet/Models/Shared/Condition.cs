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
            var operatorString = OperatorEnumMapper.Mapping.FirstOrDefault(p => p.Key == operatorEnum).Value;

            if (operatorString == null){
                throw new ArgumentException("Invalid operator");
            }
            
            return new Condition(field, operatorString, value);
        }

        public string Field { get; private set; }

        public string Operator { get; private set; }

        public object Value { get; private set; }
    }
}