using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1
{
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surame { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("enabled")]
        public int Enabled { get; set; }

        public Person(string _name, string _surname, int _age, string _role, int _enabled)
        {
            Name = _name;
            Surame = _surname;
            Age = _age;
            Role = _role;
            Enabled = _enabled;
        }
    }
}
