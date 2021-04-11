using System;
using System.Collections.Generic;
using System.Text;

namespace Test.data.Models
{
    public class LoginVM
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string ProfilePic { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool? IsActive { get; set; }
    }
}
