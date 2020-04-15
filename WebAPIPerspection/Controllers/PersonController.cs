using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIPerspection.Models;

namespace WebAPIPerspection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        List<Person> personnes = new List<Person>()
        {
            new Person(){ PersonId = 1,
                                    Firstname ="Mohamed Amine ",
                                    Lastname ="Ben Noureddine",
                                    Email = "mohamed.bennourddine@gmail.com", 
                                     Address1 ="rue okba ben nafaa",
                                     Address2 ="mornag 2090",
                                     Zip="2090",
                                     City="Ben Arous",
                                     Country="TN",
                                     Mobile_phone ="24251609"
                                        },
            new Person(){ PersonId = 2,
                                    Firstname ="Zinédine ",
                                    Lastname ="Zidane",
                                    Email = "Zinédine.Zidane@gmail.com" ,
                                     Address1 ="Émile et Armand Massard (Avenue)",
                                     Address2 ="75017 Paris",
                                     Zip="75017",
                                     City="Paris",
                                     Country="FR",
                                     Mobile_phone ="87864521213"
                                        },
        };
        [HttpGet]
        public IActionResult Gets()
        {
            if (personnes.Count == 0)
            {
                return NotFound("No List found");
            }
            return Ok(personnes);
        }
        [HttpGet("{id}")]
        public IActionResult GetPersonById(long id)
        {
            var person = personnes.SingleOrDefault(x => x.PersonId == id);
            if (person == null)
            {
                return NotFound("No person found");
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Save(Person person)
        {
            personnes.Add(person);
            if (personnes.Count == 0)
            {
                return NotFound("No List found");
            }
            return Ok(personnes);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            var person = personnes.SingleOrDefault(x => x.PersonId == id);
            if (person == null)
            {
                return NotFound("No Person found");
            }
            personnes.Remove(person);
            if (personnes.Count == 0)
            {
                return NotFound("No List found");
            }
            return Ok(personnes);
        }

    }
}