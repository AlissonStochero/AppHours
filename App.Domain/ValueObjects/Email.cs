using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ValueObjects
{
    public class Email
    {
        public Email()
        {

        }
        public Email(string address)
        {
            Address = address;
        }
        //[Required(ErrorMessage = "Email address is required.")]
        //[MaxLength(100, ErrorMessage = "Email address is greater than 100 characters.")]
        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
