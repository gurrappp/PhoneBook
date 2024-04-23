using PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook
{
    public class UserInput
    {
        private Validate validate;
        private string connectionString;
        private Controller controller;

        private SQLHelper sqlHelper;
        public UserInput()
        {
            validate = new Validate();
            
            sqlHelper = new SQLHelper();
            connectionString = sqlHelper.GetConnectionString();
            controller = new Controller();
        }

        public void Menu()
        {
            using var db = new PhoneBookContext();

            bool closeApp = false;


            Console.Clear();
            while (!closeApp)
            {
                Console.WriteLine("----- PHONE BOOK MENU ---------");
                Console.WriteLine(" Options: ");
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - Get records");
                Console.WriteLine("2 - Add records");
                Console.WriteLine("3 - Update a record");
                Console.WriteLine("4 - Delete a record");

                var option = Console.ReadLine();

                var answer = validate.ValidateMenuOption(option);
                if (answer == -1)
                {
                    Console.Clear();
                    break;
                }

                switch (answer)
                {
                    case 0:
                        closeApp = true;
                        break;
                    case 1:
                        controller.GetRecords();
                        break;
                    case 2:
                        controller.AddRecords();
                        break;
                    case 3:
                        controller.UpdateRecord();
                        break;
                    case 4:
                        controller.DeleteRecord();
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
