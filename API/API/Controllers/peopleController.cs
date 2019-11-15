using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.models;



namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static readonly List<person> _people = new List<person>
 {
     new person
     {
         Id = 1,
         Name = "Luke Skywalker",
         HairColor = "blond"
     },
     new person
     {
         Id = 5,
         Name = "Leia Organa",
         HairColor = "brown"
     }
 };
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()

        {
          
            return Ok(_people);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var person = _people.Where(p => p.Id == id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] person newPerson)
        {
            _people.Add(newPerson);
            return CreatedAtAction("Get", newPerson, new { id = new Random().Next() });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
