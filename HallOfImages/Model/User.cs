using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HallOfImages.Model
{
    public class User
    {
        // Properties:

        public string Name { get; private set; }
        public bool IsAdmin { get; private set; }

        // Constructor:

        public User(string name, bool isAdmin)
        {
            this.Name = name;
            this.IsAdmin = isAdmin;
        }
    }
}