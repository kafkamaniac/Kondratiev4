using System;


namespace Kondratiev4
{
    public class Questionaries
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Group { get; set; }

        public Questionaries(
            string fullName,
            string email,
            string phoneNumber,
            string group)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Group = group;
        }
    }
}
