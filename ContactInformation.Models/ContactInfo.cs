namespace ContactInformation.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Telephone { get; set; }

        public UserGender Gender { get; set; }

        public string PhotoUrl { get; set; }

        public UserStatus Status { get; set; }
    }
}
