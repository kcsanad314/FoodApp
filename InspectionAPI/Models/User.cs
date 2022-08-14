using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace InspectionAPI.Models
{
    public enum UserRole
    {
        Customer,
        Owner,
        Courier
    }

    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole UserRole { get; set; }

        public Restaurant? Restaurant { get; set; }
    }
}
