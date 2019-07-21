using System;
using System.Text.RegularExpressions;

namespace CapsuleDotNet.Models{
    public class Category
    {
        private Category(){}

        private Category(string name, string colour){
            this.Name = name;
            this.Colour = colour;
        }

        public static Category Create(string name, string colour){
            if (string.IsNullOrEmpty(name)){
                throw new ArgumentException("Name cannot be null or empty");
            }

            if (string.IsNullOrEmpty(colour) == false){
                var hexRegex = new Regex(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");

                if (hexRegex.Match(colour).Success == false){
                    throw new ArgumentException($"Colour {colour} is an invalid hex colour code");
                }
            }

            return new Category(name, colour);
        }
        public long Id { get; private set; }

        public string Name { get; set; }

        public string Colour { get; set; }
    }
}