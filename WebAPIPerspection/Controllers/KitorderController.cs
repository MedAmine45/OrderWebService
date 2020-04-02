using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPerspection.Models;

namespace WebAPIPerspection.Controllers
{
    [Route("api/Kit_order")]
    [ApiController]
    public class KitorderController : ControllerBase
    {
        private readonly PrescriptionDbContext _context;

        public KitorderController(PrescriptionDbContext context)
        {
            _context = context;
        }

        // GET: api/Kit_order
        [HttpGet]
        public IEnumerable<Prescription> GetPrescriptions()
        {
            return _context.Prescriptions.Include(p=>p.Patient).Include(p=>p.Prescriber);
        }

        // GET: api/Kit_order/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prescription = await _context.Prescriptions.Include(p=>p.Patient).Include(p=>p.Prescriber).SingleOrDefaultAsync(p=>p.PrescriptionId==id);

            if (prescription == null)
            {
                return NotFound("No kit order found");
            }

            return Ok(prescription);
        }


        //Query Kit_order with params
        //kit_order?prescription_id=1234
        [HttpGet("Kit_Order")]
        public IActionResult GetPrescriptionById(long prescription_id)
        {
            var Prescription = _context.Prescriptions.Include(p => p.Patient).Include(p => p.Prescriber).Where(x => x.PrescriptionId == prescription_id);
            if (Prescription == null)
            {
                return NotFound("No kit order found");
            }
            return Ok(Prescription);
        }
        //kit_order?state=ordered
        [HttpGet("OrderState")]
        public IActionResult GetPrescriptionByState(string state)
        {
            var Prescription = _context.Prescriptions.Include(p => p.Patient).Include(p => p.Prescriber).Where(x => x.State == state);
            if (Prescription == null)
            {
                return NotFound("No kit order found");
            }
            return Ok(Prescription);
        }

        // PUT: api/Kitorder/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescription([FromRoute] long id, [FromBody] Prescription prescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prescription.PrescriptionId)
            {
                return BadRequest();
            }

            _context.Entry(prescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescriptionExists(id))
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

        // POST: api/Kitorder
        [HttpPost]
        public async Task<IActionResult> PostPrescription([FromBody] Prescription prescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
           //Patient patient=  SavePatient(prescription);
           // Prescriber prescribe = SavePrescriber(prescription);
          
          _context.Prescriptions.Add(prescription);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPrescription", new { id = prescription.PrescriptionId }, prescription);
          
         
        }

        // DELETE: api/Kitorder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prescription = _context.Prescriptions.Include(p => p.Patient).Include(p => p.Prescriber).SingleOrDefault(x => x.PrescriptionId == id);
            if (prescription == null)
            {
                return NotFound();
            }

            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();

            return Ok(prescription);
        }

        private bool PrescriptionExists(long id)
        {
            return _context.Prescriptions.Any(e => e.PrescriptionId == id);
        }


        private Patient SavePatient(Prescription prescription)
        {
            Patient patientInput = prescription.Patient;
            Patient existPatient = _context.Patients.Where(p => (p.Firstname == patientInput.Firstname && p.Lastname == patientInput.Lastname && p.Birth_date == patientInput.Birth_date) || p.Email == patientInput.Email || p.Mobile_phone == patientInput.Mobile_phone).ToList().FirstOrDefault() ;
    
            if (existPatient!=null)
            {
                long temp = existPatient.PersonId;
                existPatient = patientInput;
                //existPatient.PersonId = temp;
                // _context.Entry(existPatient).State = EntityState.Modified;
                //_context.Patients.Attach(existPatient);
               // _context.Patients.Add(existPatient);
                try
                {
                    _context.Entry(existPatient).State = EntityState.Modified;
                    _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;

                }
                return patientInput;
             }
            else
            {
                Patient newPatient= _context.Patients.Add(patientInput).Entity;
                _context.SaveChanges();
                return newPatient;
            }
          
        }
        private Prescriber SavePrescriber(Prescription prescription)
        {
            Prescriber prescriberInput = prescription.Prescriber;
            Prescriber existPrescriber = _context.Prescribers.Where(p => (p.Firstname == prescriberInput.Firstname && p.Lastname == prescriberInput.Lastname && p.Birth_date == prescriberInput.Birth_date) || p.Email == prescriberInput.Email || p.Mobile_phone == prescriberInput.Mobile_phone).ToList().FirstOrDefault();
            if (existPrescriber != null)
            {
                long temp = existPrescriber.PersonId;
                existPrescriber = prescriberInput;
                

                try
                {
                    _context.Entry(existPrescriber).State = EntityState.Modified;
                    _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;

                }

                return existPrescriber;
            }
            else
            {
                Prescriber newPrescriber = _context.Prescribers.Add(prescriberInput).Entity;
                _context.SaveChanges();
                return newPrescriber;
            }
            
        }
    }
}