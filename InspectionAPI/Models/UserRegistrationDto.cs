using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace InspectionAPI.Models
{
    public class UserRegistrationDto
    { 

        //[Required(ErrorMessage = "Kötelező a(z) {0} mezőt kitölteni!")]
        [MaxLength(255, ErrorMessage = "A(z) {0} maximum {1} karakter lehet.")]
        [Display(Name = "Felhasználó név", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Kötelező a(z) {0} mezőt kitölteni!")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Kötelező a(z) {0} mezőt kitölteni!")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Jelszó megerősítése", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Kötelező a(z) {0} mezőt kitölteni!")]
        [MaxLength(255, ErrorMessage = "A(z) {0} maximum {1} karakter lehet.")]
        [Display(Name = "Keresztnév", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? FirstName { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Kötelező a(z) {0} mezőt kitölteni!")]
        [MaxLength(255, ErrorMessage = "A(z) {0} maximum {1} karakter lehet.")]
        [Display(Name = "Vezetéknév", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(255, ErrorMessage = "A(z) {0} maximum {1} karakter lehet.")]
        [Display(Name = "Város", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? City { get; set; }
        [MaxLength(255, ErrorMessage = "A(z) {0} maximum {1} karakter lehet.")]
        [Display(Name = "Utca", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? Street { get; set; }
        [MaxLength(32, ErrorMessage = "A(z) {0} maximum {1} karakter lehet.")]
        [Display(Name = "Házszám", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? HouseNumber { get; set; }
        [MaxLength(32, ErrorMessage = "A(z) {0} maximum {1} karakter lehet.")]
        [Display(Name = "Emelet", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? Floor { get; set; }
        [MaxLength(32, ErrorMessage = "A(z) {0} maximum {1} karakter lehet.")]
        [Display(Name = "Ajtószám", AutoGenerateFilter = false, AutoGenerateField = false, Order = 0)]
        public string? DoorNumber { get; set; }
        public Restaurant? Restaurant { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole UserRole { get; set; }
    }
}
