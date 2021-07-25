using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebTable
{
    public partial class Member
    {
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "The name must be shorter than 30 characters.")]
        public string Name { get; set; }

        [StringLength(30, ErrorMessage = "The sername must be shorter than 30 characters.")]
        public string Sername { get; set; }

        [StringLength(30, ErrorMessage = "The middle-name must be shorter than 30 characters.")]
        public string MiddleName { get; set; }

        [StringLength(15, ErrorMessage = "The nickname must be shorter than 15 characters.")]
        public string Nickname { get; set; }

        [EmailAddress(ErrorMessage = "Incorrect email adress")]
        [StringLength(50, ErrorMessage = "The email adress must be shorter than 50 characters.")]
        public string Email { get; set; }

        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastActivityDate { get; set; }

    }
}
