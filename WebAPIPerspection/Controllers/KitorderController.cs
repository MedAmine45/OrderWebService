using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPIPerspection.Models;

namespace WebAPIPerspection.Controllers
{
    [Route("api/Kit_order")]
    [ApiController]
    [Authorize]
    public class KitorderController : ControllerBase
    {
        private readonly PrescriptionDbContext _context;
        private readonly EmailSettings _emailSettings;

        public KitorderController(PrescriptionDbContext context, IOptions<EmailSettings> emailSettings)
        {
            _context = context;
            _emailSettings = emailSettings.Value;
        }

        // Query all kit_orders
        // GET: api/Kit_order
        [HttpGet]
        public IEnumerable<Prescription> GetPrescriptions()
        {
            
            return _context.Prescriptions
                .Include(p=>p.Analyses)
                .Include(p=>p.Logs)
                .Include(p=>p.Patient)
                .Include(p=>p.Prescriber);
        }

        //  Get one kit_order by its id
        // GET: api/Kit_order/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prescription = await _context.Prescriptions
                .Include(p=>p.Patient)
                .Include(p=>p.Prescriber)
                .Include(p => p.Analyses)
                .Include(p => p.Logs)
                .SingleOrDefaultAsync(p=>p.PrescriptionId==id);

          

            if (prescription == null)
            {
                return NotFound("No kit order found");
            }

            return Ok(prescription);
        }


        //Query Kit_order with params
        //kit_order?prescription_id=1234
        [HttpGet("OrderId")]
        public IActionResult GetPrescriptionById(long prescription_id)
        {
            var Prescription = _context.Prescriptions
                .Include(p => p.Patient)
                .Include(p => p.Prescriber)
                .Include(p=>p.Analyses)
                .Include(p=>p.Logs)
                .Where(x => x.PrescriptionId == prescription_id);
            //if (Prescription.Count() == 0 )
            //{
            //    return NotFound("No kit order found");
            //}
            return Ok(Prescription);
        }
        //kit_order?state=ordered
        [HttpGet("OrderState")]
        public IActionResult GetPrescriptionByState(string state)
        {
            var Prescription = _context.Prescriptions
                .Include(p => p.Patient)
                .Include(p => p.Prescriber)
                .Include(p=>p.Analyses)
                .Include(p=>p.Logs)
                .Where(x => x.State == state);
            //if (Prescription.Count() == 0)
            //{
            //    return NotFound("No kit order found");
            //}
            return Ok(Prescription);
        }

        // Update one kit_order
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

            Patient patient = await SavePatient(prescription);
            Prescriber prescribe = await SavePrescriber(prescription);

            IEnumerable<Analyse> analyses = await SaveAnalyses(prescription);
            IEnumerable<Log> logs = await SaveLogs(prescription);


            _context.Entry(prescription).State = EntityState.Modified;
            foreach(var analyse in prescription.Analyses)
            {
                _context.Entry(analyse).State = EntityState.Modified;
            }
            foreach (var log in prescription.Logs)
            {
                _context.Entry(log).State = EntityState.Modified;
            }

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

            return Ok(prescription);
        }

        // Create one new kit_order
        // POST: api/Kit_order
        [HttpPost]
        public async Task<IActionResult> PostPrescription([FromBody] Prescription prescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Patient patient =await  SavePatient(prescription);
            Prescriber prescribe = await SavePrescriber(prescription);

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPrescription", new { id = prescription.PrescriptionId }, prescription);
         
        }

        //Delete one  kit_order
        // DELETE: api/Kitorder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prescription = _context.Prescriptions
                .Include(p => p.Patient)
                .Include(p => p.Prescriber)
                .Include(p=>p.Analyses)
                .Include(p=>p.Logs)
                .SingleOrDefault(x => x.PrescriptionId == id);
            if (prescription == null)
            {
                return NotFound("No kit order found");
            }
            Patient patient = prescription.Patient;
            Prescriber prescriber = prescription.Prescriber;
            foreach(Analyse analyse in prescription.Analyses)
            {
                _context.Analyses.Remove(analyse);
            }
            foreach (Log log in prescription.Logs)
            {
                _context.Logs.Remove(log);
            }


            _context.Prescriptions.Remove(prescription);
             
            await _context.SaveChangesAsync();

             Patient patientdeleted = await deletePatientIsNotExist(patient);
            Prescriber prescribedeleted = await deletePrescriberIsNotExist(prescriber);

            return Ok(prescription);
        }

        //Change state of one kit order to ‘delivered’
        [HttpPost]
        [Route("{id}/state/{newState}")]
        public async Task<IActionResult> ChangeState(long id,string newState)
        {
            var prescription = _context.Prescriptions
                                .Include(p => p.Patient)
                                .Include(p => p.Prescriber)
                                .Include(p=>p.Analyses)
                                .Include(p=>p.Logs)
                                .Where(p=>p.PrescriptionId ==id).FirstOrDefault();

            if (prescription == null)
            {
                return NotFound("No kit order found");
            }
            if(Enum.IsDefined(typeof(StateEnum), newState) || newState == "Samples Received"|| newState == "Kit Sent" || newState == "Kit Delivered" || newState == "Samples Sent" || newState == "On hold")
            {
                prescription.State = newState;
                EmailState _emailOrderState = new EmailState(_emailSettings);
                _emailOrderState.EnvoieEmail(prescription, newState);
                _context.Entry(prescription).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return Ok(prescription.State);
            }
            return Ok(prescription);
        }

        private bool PrescriptionExists(long id)
        {
            return _context.Prescriptions.Any(e => e.PrescriptionId == id);
        }

        private async Task<Patient> deletePatientIsNotExist(Patient patient)
        {
            List<long> patientIds =  _context.Prescriptions.Select(p => p.Patient.PersonId).ToList<long>();
            List<long> prescriberIds = _context.Prescriptions.Select(p => p.Prescriber.PersonId).ToList<long>();

            bool isexist = patientIds.Contains(patient.PersonId) || prescriberIds.Contains(patient.PersonId);
            if (!isexist)
            {
                try
                {
                    _context.Patients.Remove(patient);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;

                }
            }
            return patient;
        }

        private async Task<Prescriber> deletePrescriberIsNotExist(Prescriber prescriber)
        {
            List<long> patientIds = _context.Prescriptions.Select(p => p.Patient.PersonId).ToList<long>();
            List<long> prescriberIds = _context.Prescriptions.Select(p => p.Prescriber.PersonId).ToList<long>();

            bool isexist = patientIds.Contains(prescriber.PersonId) || prescriberIds.Contains(prescriber.PersonId);
            if (!isexist)
            {
                try
                {
                    _context.Prescribers.Remove(prescriber);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;

                }
            }
            return prescriber;
        }


        private async Task<Patient> SavePatient(Prescription prescription)
        {
            Patient existPatient =  _context.Patients.Where(p => (p.Firstname == prescription.Patient.Firstname && p.Lastname == prescription.Patient.Lastname && p.Birth_date == prescription.Patient.Birth_date && p.Email == prescription.Patient.Email) || p.Mobile_phone == prescription.Patient.Mobile_phone).ToList().FirstOrDefault() ;
    
            if (existPatient!=null)
            {
                long temp = existPatient.PersonId;
                existPatient = prescription.Patient;
                existPatient.PersonId = temp;


                try
                {
                    _context.Entry(existPatient).State = EntityState.Modified;
                   await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;

                }

                return existPatient;
             }
            else
            {
                Patient newPatient = new Patient();
                try
                {
                     newPatient= _context.Patients.Add(prescription.Patient).Entity;
                await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;

                }
                return newPatient;
            }
          
        }
        private async Task<Prescriber> SavePrescriber(Prescription prescription)
        {
            Prescriber existPrescriber = _context.Prescribers.Where(p => (p.Firstname == prescription.Prescriber.Firstname && p.Lastname == prescription.Prescriber.Lastname && p.Email == prescription.Prescriber.Email) || p.Mobile_phone == prescription.Prescriber.Mobile_phone).ToList().FirstOrDefault();
            if (existPrescriber != null)
            {
                long temp = existPrescriber.PersonId;
                existPrescriber = prescription.Prescriber;
                existPrescriber.PersonId = temp;

                try
                {
                    _context.Entry(existPrescriber).State = EntityState.Modified;
                    await  _context.SaveChangesAsync();
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
                Prescriber newPrescriber = new Prescriber();
                try
                {
                    newPrescriber = _context.Prescribers.Add(prescription.Prescriber).Entity;
                await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;

                }
                return newPrescriber;
            }
            
        }


        private async Task<IEnumerable<Analyse>> SaveAnalyses(Prescription prescription)
        {
            var AnalysesInput = prescription.Analyses.ToList();
            foreach( var analyse in AnalysesInput)
            {
                Analyse existAnalyse = _context.Analyses.Where(a => a.Code == analyse.Code && a.Prescription.PrescriptionId == prescription.PrescriptionId).FirstOrDefault();
                if (existAnalyse != null)
                {
                    long temp = existAnalyse.AnalyseID;
                    existAnalyse = analyse;
                    existAnalyse.AnalyseID = temp;
                    try
                    {
                        _context.Entry(existAnalyse).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        throw;

                    }
                }
                else
                {
                    Analyse newAnalyse = new Analyse();
                    try
                    {
                        newAnalyse =_context.Analyses.Add(analyse).Entity;
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        throw;

                    }

                }
               
            }
            //Delete analyses 
            var analysesAll = _context.Analyses.Where(a => a.Prescription.PrescriptionId == prescription.PrescriptionId).Select(a=>a.AnalyseID).ToList();
            var analysesDeleteIds = analysesAll.Except(AnalysesInput.Select(a=>a.AnalyseID));
            var analysesDelete = from a in _context.Analyses.ToList()
                                 where analysesDeleteIds.Contains(a.AnalyseID)
                                 select a;
                              
            foreach (var analyse in analysesDelete)
            {
                _context.Analyses.Remove(analyse);
                await _context.SaveChangesAsync();

            }

            return AnalysesInput;
        }
        private async Task<IEnumerable<Log>> SaveLogs(Prescription prescription)
        {
            var LogsInput = prescription.Logs;
            foreach (var log in LogsInput)
            {
                Log existLog = _context.Logs.Where(l=> l.State == log.State && l.Billing_state == log.Billing_state &&l.Invoice_state == log.Invoice_state && l.Prescription.PrescriptionId== prescription.PrescriptionId).FirstOrDefault();
                if (existLog != null)
                {
                    long temp = existLog.LogID;
                    existLog = log;
                    existLog.LogID = temp;
                    try
                    {
                        _context.Entry(log).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        throw;

                    }
                }
                else
                {

                     Log newLog = new Log();
                    try
                    {
                        newLog =_context.Logs.Add(log).Entity;
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        throw;

                    }

                }


            }

            //Delete Logs 
            var LogsAll = _context.Logs.Where(a => a.Prescription.PrescriptionId == prescription.PrescriptionId).Select(l => l.LogID).ToList();
            var LogsDeleteIds = LogsAll.Except(LogsInput.Select(l => l.LogID));
            var LogsDelete = from l in _context.Logs.ToList()
                                 where LogsDeleteIds.Contains(l.LogID)
                                 select l;

            foreach (var Log in LogsDelete)
            {
                _context.Logs.Remove(Log);
                await _context.SaveChangesAsync();

            }
            return LogsInput;
        }



    }
}