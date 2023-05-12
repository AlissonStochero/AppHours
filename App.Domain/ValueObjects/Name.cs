using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ValueObjects
{
    public class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        //[Required(ErrorMessage = "First Name is required.")]
        //[MaxLength(100, ErrorMessage = "name is greater than 100 characters.")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Last Name is required.")]
        //[MaxLength(100, ErrorMessage = "name is greater than 100 characters.")]
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
