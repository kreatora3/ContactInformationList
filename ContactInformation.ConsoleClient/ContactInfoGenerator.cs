namespace ContactInformation.ConsoleClient
{
    using System.Collections.Generic;
    using ContactInformation.Models;
    using ContactInformation.Data;

    public class ContactInfoGenerator : DataGenerator, IDataGenerator
    {
        private List<string> photoes = new List<string>()
        {
            "http://www.mascotdesign.com/_dev/images/famous-cartoon-character-mighty-mouse.jpg",
            "http://www.jamiesale-cartoonist.com/wp-content/uploads/cartoon-monkey-free.png",
            "http://img2.wikia.nocookie.net/__cb20141207223335/epicrapbattlesofhistory/images/1/10/Penguin-cartoon.png",
            "http://www.jamiesale-cartoonist.com/wp-content/uploads/cartoon-cat-free.png",
            "http://crunchpics.com/wp-content/uploads/2014/09/old-and-better-cartoon-picture.jpg",
            "https://shechive.files.wordpress.com/2012/06/cute-cartoons-21.jpg"
        };

        public ContactInfoGenerator(IRandomDataGenerator random, ContactDbContext contact, int count)
            : base(random, contact, count)
        {
        }

        public override void Generate()
        {
            for (int i = 0; i < this.Count; i++)
            {
                var contact = new ContactInfo()
                {
                    FirstName = this.Random.GetRandomStringWithRandomLength(3, 7),
                    LastName = this.Random.GetRandomStringWithRandomLength(3, 7),
                    Gender = (UserGender)this.Random.GetRandomNumber(0, 2),
                    Status = (UserStatus)this.Random.GetRandomNumber(0, 2),
                    PhotoUrl = this.photoes[this.Random.GetRandomNumber(0, 5)],
                    Telephone = this.Random.GetPhoneNumber(10).ToString()
                };

                this.Database.Contacts.Add(contact);
                this.Database.SaveChanges();
            }
        }
    }
}
