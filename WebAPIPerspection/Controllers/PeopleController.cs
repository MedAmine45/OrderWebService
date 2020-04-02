using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPerspection.Models;

namespace WebAPIPerspection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PrescriptionDbContext _context;

        public PeopleController(PrescriptionDbContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> GetPerson()
        {
            return _context.Person;
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.Person.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson([FromRoute] long id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        //// PUT: api/People/Patient/5
       // [Route("Patient")]
        [HttpPut("patient")]
        public async Task<IActionResult> PutPatient([FromRoute] long id, [FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Route("Prescriber")]
        [HttpPut("{prescriberid}")]
        public async Task<IActionResult> PutPrescriber([FromRoute] long prescriberid, [FromBody] Prescriber prescriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (prescriberid != prescriber.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(prescriber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(prescriberid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(_context.Person.Any((p => p.Firstname == person.Firstname && p.Lastname == person.Lastname && p.Email == person.Email)))
            {
                _context.Person.Add(person);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound("person is already exists");
            }
            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        [Route("PatientPerson")]
        [HttpPost]
        public async Task<IActionResult> PostPatient([FromBody] Patient patientPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (patientPerson == null)
            {
                return BadRequest();
            }
            if (! (_context.Person.Any(p=>p.Firstname== patientPerson.Firstname || p.Lastname== patientPerson.Lastname || p.Email == patientPerson.Email || p.Birth_date==patientPerson.Birth_date)))
            {
                _context.Patients.Add(patientPerson);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound("patient is already exists");
            }
           

            return CreatedAtAction("GetPerson", new { id = patientPerson.PersonId }, patientPerson);
        }

        [Route("PrescriberPerson")]
        [HttpPost]
        public async Task<IActionResult> PostPrescriber([FromBody] Prescriber prescriberPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (prescriberPerson == null)
            {
                return BadRequest();
            }
            if (!(_context.Person.Any(p => p.Firstname == prescriberPerson.Firstname || p.Lastname == prescriberPerson.Lastname || p.Email == prescriberPerson.Email || p.Birth_date == prescriberPerson.Birth_date)))
            {
                _context.Prescribers.Add(prescriberPerson);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound("patient is already exists");
            }


            return CreatedAtAction("GetPerson", new { id = prescriberPerson.PersonId }, prescriberPerson);
        }
        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        private bool PersonExists(long id)
        {
            return _context.Person.Any(e => e.PersonId == id);
        }
    }
}