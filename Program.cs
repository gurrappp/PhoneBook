using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection.Metadata;


namespace PhoneBook
{
    public class Program
    {

       
        public static void Main()
        {
            using var db = new PhoneBookContext();

            

            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.connectionString}.");

            // Create
            Console.WriteLine("Inserting a new contact");
            db.Add(new Contact
            {
                Id = 0,
                Name = "Gustav",
                Email = "gustav@email.com",
                PhoneNumber = "076"
            });
            db.SaveChanges();

            // Read
            Console.WriteLine("Querying for a contact");
            var contact = db.Contacts
                .OrderBy(b => b.Id)
                .First();

            // Update
            Console.WriteLine("Updating the contact");
            contact.Name = "Gustav2";
            
            db.SaveChanges();

            // Delete
            Console.WriteLine("Delete the contact");
            db.Remove(contact);
            db.SaveChanges();
        }
    }


}

