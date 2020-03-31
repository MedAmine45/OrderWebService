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
                                    Email = "mohamed.bennourddine@gmail.com" ,
                                     Sex =Gender.M.ToString(),
                                     Birth_date ="16/01/1995",
                                     Address1 ="rue okba ben nafaa",
                                     Address2 ="mornag 2090",
                                     Zip="2090",
                                     City="Ben Arous",
                                     Country="TN",
                                     Mobile_phone ="24251609",
                                     Height= 184,
                                     Weight =65
                                        },
            new Person(){ PersonId = 2,
                                    Firstname ="Zinédine ",
                                    Lastname ="Zidane",
                                    Email = "Zinédine.Zidane@gmail.com" ,
                                     Sex ="M",
                                     Birth_date ="23/06/1972",
                                     Address1 ="rue okba ben nafaa",
                                     Address2 ="mornag 2090",
                                     Zip="75001",
                                     City="Marseille",
                                     Country="FR",
                                     Mobile_phone ="87864521213",
                                     Height= 185,
                                     Weight =70
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
        public IActionResult GetPersonById(int id)
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
        public IActionResult DeletePerson(int id)
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