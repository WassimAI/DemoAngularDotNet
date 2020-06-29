using System;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.API.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength=3, ErrorMessage="Your password should be at least 3 characters and at most 8 characters")]
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PersonalInfo { get; set; }
        public string ImageUrl { get; set; }
        public DateTime LastLogin { get; set; }
    }
}