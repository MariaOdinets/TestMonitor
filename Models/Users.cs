using TestMonitor.Models.Enums;

namespace TestMonitor.Models
{
    public record User
    {
        public UserType UserType { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}