using System;
using Microsoft.AspNetCore.Identity;

namespace TP3_EcoWatch.Models
{
    public class AppUser : IdentityUser
    {
        public string Region { get; set; } = "";
        public bool IsAdmin { get; set; }
        public bool IsAuthority { get; set; }
        public string Speciality { get; set; } = "";
    }
}
