﻿using BCSDirectory.Models;

namespace BCSDirectory.Login
{
    public class LoginViewModel : Page
    {
        public User User { get; set; }

        public LoginViewModel()
        {
            Title = "Login";
        }

    }
}
