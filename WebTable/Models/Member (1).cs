using System;
using System.Collections.Generic;

#nullable disable

namespace WebTable
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }
        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
    }
}
