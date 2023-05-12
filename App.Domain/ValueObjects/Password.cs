using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Domain.ValueObjects
{
    public class Password
    {
        public Password()
        {

        }
        public Password(string key)
        {
            Key = key;
        }
        //[Required(ErrorMessage = "Key is required.")]
        //[MaxLength(300, ErrorMessage = "Key is greater than 100 characters.")]
        public string Key { get; set; }
        public override string ToString()
        {
            return $"{Key}";
        }

        public bool Validate()
        {
            bool containCapitalLetters = Regex.IsMatch(Key, (@"[A-Z]"));
            bool containsLowercaseCharacter = Regex.IsMatch(Key, (@"[a-z]"));
            bool containsSpecialCharacters = Regex.IsMatch(Key, (@"[^a-zA-Z0-9]"));

            if(containCapitalLetters && containsLowercaseCharacter && containsSpecialCharacters)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
