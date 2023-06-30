using System;
using System.Collections.Generic;
using System.Text;

namespace LoginApp.Pages
{
    public class RegUserTable
    {
        internal static string Text;

        public Guid UserId { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
    }
}
