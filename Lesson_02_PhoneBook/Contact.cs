using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_02_PhoneBook
{
    public class Contact
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Contact() :this("", "", "") { }
        public Contact(string f, string p, string e)
        {
            FullName = f;
            PhoneNumber = p;
            EmailAddress = e;
        }

        public override string ToString()
        {
            return $"{FullName}\n{PhoneNumber}\n{EmailAddress}";
        }
    }
}
