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
   
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            var result = data.Contacts.GetAll()
               .Where(c => c.Status != UserStatus.Deleted);
            return result;           
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(string idString)
        {
            var id = int.Parse(idString);
            data.Contacts.Delete(id);
            data.Contacts.SaveChanges();
            return Ok();
        }
    }
}
