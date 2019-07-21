using System.Collections.Generic;
using System.Linq;
using CapsuleDotNet.Common;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models
{
    public class Filter
    {
        [JsonProperty("conditions")]
        private List<Condition> _conditions;
        [JsonProperty("orderBy")]
        private List<OrderBy> _orderBy;

        [JsonIgnore]
        public IReadOnlyCollection<Condition> Conditions => _conditions;

        [JsonIgnore]
        public IReadOnlyCollection<OrderBy> OrderBy => _orderBy;

        public void AddCondition(string field, Operator operatorEnum, object value){
            if (_conditions == null){
                _conditions = new List<Condition>(1);
            }

            _conditions.Add(Condition.Create(field, operatorEnum, value));
        }

        public void RemoveCondition(Condition condition){
            if (_conditions != null && _conditions.Any(p => p == condition)){
                _conditions.Remove(condition);
            }
        }

        public void AddOrderBy(string field, Direction direction){
            if (_orderBy == null){
                _orderBy = new List<OrderBy>(1);
            }

            _orderBy.Add(Models.OrderBy.Create(field, direction));
        }

        public void RemoveOrderBy(OrderBy orderBy){
            if (_orderBy != null && _orderBy.Any(p => p == orderBy)){
                _orderBy.Remove(orderBy);
            }
        }
    }
}