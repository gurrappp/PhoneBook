using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Controller
    {
        //private PhoneBookContext dbContext;
        private Validate validate;
        public Controller()
        {
            validate = new Validate();
        }

        public void GetRecords()
        {
            using var db = new PhoneBookContext();

            var records = db.Contacts.Select(x => x).ToList();

            TableVisualizationEngine.ShowTable(records,"contacts");



        }

        public void AddRecords()
        {
            using var db = new PhoneBookContext();
            Console.Clear();
            Console.WriteLine("Adding Records");
            bool close = false;
            while (!close)
            {
                
                Console.WriteLine("Name:");
                var name = validate.ValidateName(Console.ReadLine());

                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Wrong input, write name in string:");
                    name = validate.ValidateName(Console.ReadLine());
                }

                Console.WriteLine("Email:");

                var email = validate.ValidateEmail(Console.ReadLine());

                while (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Wrong input, write email as : test@adress.something");
                    email = validate.ValidateEmail(Console.ReadLine());
                }

                Console.WriteLine("Phone Number:");

                var phoneNumber = validate.ValidatePhoneNumber(Console.ReadLine());

                while (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    Console.WriteLine("Wrong input, write number as integers: ");
                    phoneNumber = validate.ValidatePhoneNumber(Console.ReadLine());
                }

                db.Add(new Contact
                {
                    //Id = GetNextId(),
                    Name = name,
                    Email = email,
                    PhoneNumber = phoneNumber
                });

                Console.WriteLine("Add more? write yes to add more");
                var more = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(more) && more != "yes")
                    close = true;
            }

            db.SaveChanges();

        }

        public void UpdateRecord()
        {
            using var db = new PhoneBookContext();

            GetRecords();

            Console.WriteLine("Write Id of record to update.");

            var id = validate.ValidateId(Console.ReadLine());

            while (id == null)
            {
                Console.WriteLine("Write Id of record to update. write integer.");
                id = validate.ValidateId(Console.ReadLine());
            }

            var contact = db.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                Console.WriteLine("No record found");
                return;
            }

            bool leave = false;

            while (!leave)
            {
                Console.WriteLine("Choose what to update:");
                Console.WriteLine("1 - Name");
                Console.WriteLine("2 - Email");
                Console.WriteLine("3 - PhoneNumber");
                Console.WriteLine("Write anything else to exit");

                var okInputs = new List<int> { 1, 2, 3 };

                var input = int.TryParse(Console.ReadLine(), out var result);


                if (!okInputs.Contains(result))
                {
                    leave = true;
                    return;
                }
                    

                switch (result)
                {
                    case 1:
                        Console.WriteLine("New Name:");
                        var name = validate.ValidateName(Console.ReadLine());

                        while (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Wrong input, write name in string:");
                            name = validate.ValidateName(Console.ReadLine());
                        }

                        contact.Name = name;
                        break;
                    case 2:
                        Console.WriteLine("New Email:");
                        var email = validate.ValidateEmail(Console.ReadLine());

                        while (string.IsNullOrWhiteSpace(email))
                        {
                            Console.WriteLine("Wrong input, write email as : test@adress.something");
                            email = validate.ValidateEmail(Console.ReadLine());
                        }

                        contact.Email = email;
                        break;
                    case 3:
                        Console.WriteLine("New Phone Number:");
                        var phoneNumber = validate.ValidatePhoneNumber(Console.ReadLine());

                        while (string.IsNullOrWhiteSpace(phoneNumber))
                        {
                            Console.WriteLine("Wrong input, write number as integers: ");
                            phoneNumber = validate.ValidatePhoneNumber(Console.ReadLine());
                        }
                        contact.PhoneNumber = phoneNumber;
                        break;
                    default:
                        break;
                }
            }
            

            db.SaveChanges();

        }

        public void DeleteRecord()
        {
            using var db = new PhoneBookContext();

            GetRecords();

            Console.WriteLine("Write Id of record to delete.");

            var id = validate.ValidateId(Console.ReadLine());

            while (id == null)
            {
                Console.WriteLine("Write Id of record to delete. write integer.");
                id = validate.ValidateId(Console.ReadLine());
            }

            var contact = db.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                Console.WriteLine("No record found");
                return;
            }

            db.Remove(contact);
            db.SaveChanges();
        }

        public int GetNextId()
        {

            using var db = new PhoneBookContext();

            var max = db.Contacts.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();

            return max +1;
        }

    }
}
