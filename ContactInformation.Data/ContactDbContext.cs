namespace ContactInformation.Data
{
    using System.Data.Entity;
    using ContactInformation.Data.Migrations;
    using ContactInformation.Models;    

    public class ContactDbContext : DbContext
    {
        public ContactDbContext() :
            base("testname")
        {
             Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactDbContext, Configuration>());
        }
       

        public IDbSet<ContactInfo> Contacts { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public static ContactDbContext Create()
        {
            return new ContactDbContext();
        }
    }
}
