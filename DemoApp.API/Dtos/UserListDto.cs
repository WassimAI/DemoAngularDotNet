using System;

namespace DemoApp.API.Dtos
{
    public class UserListDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime LastLogin { get; set; }
    }
}