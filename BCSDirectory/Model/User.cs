using System;
using System.Collections.ObjectModel;

namespace BCSDirectory.Model
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public ObservableCollection<Hobby> Hobbies { get; set; } = new ObservableCollection<Hobby>();
        public CivilStatus CivilStatus { get; set; }
        public UserType UserType { get; set; }
    }
}
