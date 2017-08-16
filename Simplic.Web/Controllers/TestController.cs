using Simplic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Simplic.Web.Controllers
{
    public class TestController : ApiController
    {
        public IList<PersonData> GetAllPersons()
        {
            return PersonRepository.GetAll();
        }

        public IHttpActionResult GetPerson(int id)
        {
            var product = PersonRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
