﻿using System.Collections.Generic;

namespace BCSDirectory.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
