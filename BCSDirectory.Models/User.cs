using BCSDirectory.Models.Enums;
using System;
using System.Collections.Generic;

namespace BCSDirectory.Models
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
        public DateTime Birthdate { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public List<Hobby> Hobbies { get; set; } = new List<Hobby>();
        public CivilStatus CivilStatus { get; set; }
        public UserType UserType { get; set; } = UserType.Viewer;
    }
}
