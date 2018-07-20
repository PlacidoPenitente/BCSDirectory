using System;
using System.Linq;
using BCSDirectory.Services;

namespace BCSDirectory.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
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
            UserRepository userRepository = new UserRepository();
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
