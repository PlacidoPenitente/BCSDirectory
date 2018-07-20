using System;
using System.Collections.Generic;
using System.Linq;
using BCSDirectory.Models;
using BCSDirectory.Services;
using BCSDirectory.Models.Enums;

namespace BCSDirectory.Console
{
    class Program
    {
        private static UserRepository userRepository;
        static void Main(string[] args)
        {
            try
            {
                userRepository = new UserRepository();
                User usee = new User()
                {
                    FirstName = "Rodney",
                    MiddleName = "P",
                    LastName = "Buendia",
                    Birthdate = DateTime.Now,
                    Address = "Doon, Lang",
                    CivilStatus = CivilStatus.Single,
                    PhoneNumber = "09123456789",
                    Gender = Gender.Male,
                    UserType = UserType.Editor,
                    Hobbies = new List<Hobby>()
                    {
                        new Hobby() {Name = "Hiking"},
                        new Hobby() {Name = "Music"}
                    }
                };

                userRepository.ApiAdd(usee);

                System.Console.WriteLine("End Insertion... Start Reading...");

                Read();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.GetType());
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                System.Console.WriteLine("end");
            }
            
            System.Console.Read();
        }

        static void Read()
        {
            userRepository = new UserRepository();
            var users = userRepository.ApiGetAll();

            if (users == null || users.Count() == 0)
                System.Console.WriteLine("Null OR Empty");
            else
            {
                foreach (var user in users)
                {
                    System.Console.WriteLine($"Name: {user.LastName}, {user.FirstName} {user.MiddleName}");
                }
            }
        }
    }
}
