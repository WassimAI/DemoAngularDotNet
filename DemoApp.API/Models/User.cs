using System;
using System.Collections.Generic;

namespace DemoApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PersonalInfo { get; set; }
        public string ImageUrl { get; set; }
        public DateTime LastLogin { get; set; }
    }
}