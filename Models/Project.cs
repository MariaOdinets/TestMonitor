using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestMonitor.Models
{
    public class Project
    {
        [JsonPropertyName("symbol_id")] 
        public int symbol_id { get; set; }

        [JsonPropertyName("name")] 
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("type")] 
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("description")] 
        public string Description { get; set; } = string.Empty;

        public override string ToString()
        {
            return
                $"{nameof(symbol_id)}: {symbol_id}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(Type)}: {Type}";
        }
    }
}