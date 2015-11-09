namespace ContactInformation.WebClient.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using ContactInformation.Data.Repositories;
    using ContactInformation.Data;
    using ContactInformation.Models;
    using System.Web.Http.Cors;

    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactInfoController : ApiController
    {
        private IContactData data;

        public ContactInfoController()
        {

        }

        public ContactInfoController(IContactData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IEnumerable<ContactInfo> Get()
        {
            var result = this.data.Contacts.GetAll()
               .Where(c => c.Status != UserStatus.Deleted);
            return result;
        }

        [HttpPost]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(ContactInfo contact)
        {
            var id = contact.Id;

            this.data.Contacts.Delete(id);
            this.data.Contacts.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("api/changeStatus")]
        public IHttpActionResult ChangeStatus(ContactInfo contact)
        {
            var id = contact.Id;
            var databaseContact = this.data.Contacts.GetById(id);

            if (databaseContact.Status != UserStatus.Active)
            {
                databaseContact.Status = UserStatus.Active;
            }
            else
            {
                databaseContact.Status = UserStatus.Inactive;
            }

            this.data.Contacts.Update(databaseContact);
            this.data.Contacts.SaveChanges();
            
            return Ok();
        }
    }
}
