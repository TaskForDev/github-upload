using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace V8Features
{
    public class Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsCreator { get; set; } = false;
        public Author(string name, string email, bool isCreator , string role)
        {
            Name = name;
            Email = email;
            IsCreator = isCreator;
            Role = role;
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
