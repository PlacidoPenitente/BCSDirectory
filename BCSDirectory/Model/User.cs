using System;
using System.Collections.Generic;

namespace BCSDirectory.Model
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public Information<DateTime> Birthdate { get; set; }
        public Information<string> Address { get; set; }
        public Information<List<string>> HobbiesAndInterest { get; set; }
        public Information<CivilStatus> CivilStatus { get; set; }
        public Information<UserType> UserType { get; set; }
    }
}
