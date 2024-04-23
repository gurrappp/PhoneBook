using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection.Metadata;
using PhoneBook;


namespace PhoneBook
{
    public class Program
    {
        public static void Main()
        {
            var userInput = new UserInput();

            userInput.Menu();
            
        }
    }
}

