namespace ContactInformation.ConsoleClient
{
    using System;
    using System.Linq;
    using ContactInformation.Data;

    public class Start
    {
        public static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new ContactDbContext();

            var contacts = new ContactInfoGenerator(random, db, 20);

            contacts.Generate();

            db.SaveChanges();

            Console.WriteLine(db.Contacts.Count());
        }
    }
}
