using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Validate
    {

        public int? ValidateId(string? input)
        {
            if (!int.TryParse(input, out var result))
                return null;
            return result;
        }

        public int ValidateMenuOption(string? option)
        {
            if (!int.TryParse(option, out int result))
            {
                Console.WriteLine("Wrong input!");
                return -1;
            }

            return result;
        }

        public string? ValidateName(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;
            return input;
        }

        public string? ValidateEmail(string? input)
        {
            if (string.IsNullOrWhiteSpace(input) || !input.Contains('@') || !input.Contains('.'))
                return null;

            return input;
        }

        public string? ValidatePhoneNumber(string? input)
        {
            if (!int.TryParse(input, out _))
                return null;

            return input;
        }
    }
}
