namespace ContactInformation.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using ContactInformation.Data.Repositories;
    using ContactInformation.Models;

    public class ContactData : IContactData
    {
        private readonly DbContext context;

        private readonly IDictionary<Type, object> repositories;

        public ContactData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ContactInfo> Contacts
        {
            get
            {
                return this.GetRepository<ContactInfo>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EntityFrameworkRepository<T>);
            
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
