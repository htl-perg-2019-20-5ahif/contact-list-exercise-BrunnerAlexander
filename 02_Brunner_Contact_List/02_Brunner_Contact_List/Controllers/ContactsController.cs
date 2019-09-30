using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_Brunner_Contact_List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static List<Contact> contacts = new List<Contact> { };


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(contacts);
        }


        [HttpPost]
        public IActionResult AddItem([FromBody] Contact contact)
        {
            contacts.Add(contact);
            return CreatedAtRoute("GetSpecificContact", new { index = contacts.IndexOf(contact) }, contact);
        }


        [HttpDelete]
        [Route("{index}")]
        public IActionResult DeleteItem(int index)
        {
            if (index >= 0 && index < contacts.Count)
            {
                contacts.RemoveAt(index);
                return NoContent();
            }

            return BadRequest("Invalid index");
        }

        [HttpGet]
        [Route("findByName/{name}")]
        public Contact AddItem(string name)
        {
            Contact ret = contacts.FirstOrDefault(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
            return ret;
        }

    }
}
