using System.Security.Claims;

namespace InspectionAPI.Models
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public string? userId { get; set; }
        public Dictionary<string, string>? Claims { get; set; }
    }
}
