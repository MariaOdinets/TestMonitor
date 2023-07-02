using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TestMonitor.Models
{
    public record User
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}