using CapsuleDotNet.Common;

namespace CapsuleDotNet.Models{
    public class OrderBy
    {
        private OrderBy (string direction, string field){
            this.Field = field;
            this.Direction = direction;
        }

        public static OrderBy Create(string field, Direction direction){
            return new OrderBy(nameof(direction), field);
        }
        public string Direction { get; set; }

        public string Field { get; set; }
    }
}