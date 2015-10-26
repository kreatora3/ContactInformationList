namespace ContactInformation.Data
{
    using ContactInformation.Models;
    using ContactInformation.Data.Repositories;

    public interface IContactData
    {
       IRepository<ContactInfo> Contacts { get; }

       int SaveChanges();
    }
}
