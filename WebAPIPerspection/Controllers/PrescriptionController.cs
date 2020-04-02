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
    public class PrescriptionController : ControllerBase
    {
        List<Prescription> prescriptions = new List<Prescription>()
        {
            new Prescription()
            {
                PrescriptionId =1234,
                State = StateEnum.prescribed.ToString(),
                Patient = new Patient()
                {
                    Firstname = "Jean",
                    Lastname = "Dupont",
                    Birth_date = "11/11/1987",
                    Sex= Gender.M.ToString(),
                    Email= "j.dupont1987@gmail.com",
                    Address1 = "1 rue des tourterelles",
                    Address2 ="Appt 112",
                    Zip = "75001",
                    City="Paris",
                    Country ="fr",
                    Mobile_phone="06 78 90 12 34",
                    Home_phone ="01 78 90 12 34"
                },
                Prescriber = new Prescriber
                {
                     Firstname="Andrée",
                     Lastname="Durand",
                     Birth_date="31/12/1980",
                     Sex = Gender.F.ToString(),
                     Email="a.durand1980@gmail.com",
                     Address1="314 avenue pi",
                     Address2="Porte 15",
                     Zip="75006",
                    City="Paris",
                    Country="fr",
                    Mobile_phone="06 78 90 12 34",
                    Office_phone="01 78 90 12 34",
                    Height = 184,
                    Weight = 84
                },
                Price_analyses =587,
                Price_shipping =609,
                Analyses= new List<string>(){ "INTINC7", "BUIO" },
                Tubes = new List<string>(){ "2 tubes violets + 3 tubes rouges + 1 tube gris + selles", "1ères urines du matin" }
            },
            new Prescription()
            {
                PrescriptionId =1235,
                State = StateEnum.ordered.ToString(),
                Patient = new Patient()
                {                   PersonId = 1,
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
                                     Home_phone ="79 351 176",
                                     Height= 184,
                                     Weight =65
                },
                Prescriber = new Prescriber
                {
                     PersonId = 2,
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
                                     Office_phone = "54621231321",
                                     Height= 185,
                                     Weight =70
                },
                Price_analyses =587,
                Price_shipping =609,
                Analyses= new List<string>(){ "INTINC7", "BUIO" },
                Tubes = new List<string>(){ "2 tubes violets + 3 tubes rouges + 1 tube gris + selles", "1ères urines du matin" }
            },
             new Prescription()
            {
                PrescriptionId =1236,
                State = StateEnum.ordered.ToString(),
                Patient = new Patient()
                {                   PersonId = 1,
                                    Firstname ="jihed ",
                                    Lastname ="jbar",
                                    Email = "jihed.jbar@gmail.com" ,
                                     Sex =Gender.M.ToString(),
                                     Birth_date ="16/01/1993",
                                     Address1 ="rue okba ben nafaa",
                                     Address2 ="mornag 2090",
                                     Zip="2090",
                                     City="tunis",
                                     Country="TN",
                                     Mobile_phone ="24251609",
                                     Home_phone ="79 351 176",
                                     Height= 184,
                                     Weight =65
                },
                Prescriber = new Prescriber
                {
                     PersonId = 2,
                                    Firstname ="Aymen ",
                                    Lastname ="Zarouk",
                                    Email = "Aymen.Zarouk@gmail.com" ,
                                     Sex ="M",
                                     Birth_date ="23/06/1972",
                                     Address1 ="rue okba ben nafaa",
                                     Address2 ="mornag 2090",
                                     Zip="75001",
                                     City="Marseille",
                                     Country="FR",
                                     Mobile_phone ="87864521213",
                                     Office_phone = "54621231321",
                                     Height= 185,
                                     Weight =70
                },
                Price_analyses =587,
                Price_shipping =609,
                Analyses= new List<string>(){ "INTINC7", "BUIO" },
                Tubes = new List<string>(){ "2 tubes violets + 3 tubes rouges + 1 tube gris + selles", "1ères urines du matin" }
            },
              new Prescription()
            {
                PrescriptionId =1237,
                State = StateEnum.prescribed.ToString(),
                Patient = new Patient()
                {                   PersonId = 1,
                                    Firstname ="mohamed ",
                                    Lastname ="Amine",
                                    Email = "mohamed.Amine@gmail.com" ,
                                     Sex =Gender.M.ToString(),
                                     Birth_date ="16/01/1993",
                                     Address1 ="rue okba ben nafaa",
                                     Address2 ="mornag 2090",
                                     Zip="2090",
                                     City="tunis",
                                     Country="TN",
                                     Mobile_phone ="24251609",
                                     Home_phone ="79 351 176",
                                     Height= 184,
                                     Weight =65
                },
                Prescriber = new Prescriber
                {
                     PersonId = 2,
                                    Firstname ="Amira ",
                                    Lastname ="ben moussa",
                                    Email = "Amira.benmoussa@gmail.com" ,
                                     Sex ="M",
                                     Birth_date ="23/06/1972",
                                     Address1 ="menzha",
                                     Address2 ="mornag 2090",
                                     Zip="75001",
                                     City="Tunis",
                                     Country="FR",
                                     Mobile_phone ="87864521213",
                                     Office_phone = "54621231321",
                                     Height= 185,
                                     Weight =70
                },
                Price_analyses =587,
                Price_shipping =609,
                Analyses= new List<string>(){ "INTINC7", "BUIO" },
                Tubes = new List<string>(){ "2 tubes violets + 3 tubes rouges + 1 tube gris + selles", "1ères urines du matin" }
            }
        };

        //Query all kit_orders
        // GET: api/Prescription
        [HttpGet]
        public IActionResult Gets()
        {
            if (prescriptions.Count == 0)
            {
                return NotFound("No List found");
            }
            return Ok(prescriptions);
        }

        // Get one kit_order by its id
        // GET: api/Prescription/5
        [HttpGet("{id}")]
        public IActionResult GetPrescriptionById(long id)
        {
            var Prescription = prescriptions.SingleOrDefault(x => x.PrescriptionId == id);
            if (Prescription == null)
            {
                return NotFound("No Prescription found");
            }
            return Ok(Prescription);
        }

        //Query kit_orders with params
        //kit_order?prescription_id=1234
        [HttpGet("GetPrescriptionId")]
        public IActionResult GetPrescription(long id)
        {
            var Prescription = prescriptions.SingleOrDefault(x => x.PrescriptionId == id);
            if (Prescription == null)
            {
                return NotFound("No Prescription found");
            }
            return Ok(Prescription);
        }
        //kit_order?state=ordered
        [HttpGet("GetPrescriptionState")]
        public IActionResult GetPrescriptionByState(string state)
        {
            var Prescription = prescriptions.Where(x => x.State == state);
            if (Prescription == null)
            {
                return NotFound("No Prescription found");
            }
            return Ok(Prescription);
        }


        //kit_order (post)
        [HttpPost]
        public IActionResult Save(Prescription prescription)
        {
            prescriptions.Add(prescription);
            if (prescriptions == null)
            {
                return NotFound("No list found");
            }
            return Ok(prescriptions);
        }

        //kit_order/id (delete)
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePrescription(long id)
        {
            var prescription = prescriptions.SingleOrDefault(x => x.PrescriptionId == id);
            if (prescription == null)
            {
                return NotFound("No prescription found");
            }
            prescriptions.Remove(prescription);
            if (prescriptions.Count == 0)
            {
                return NotFound("No List found");
            }
            return Ok(prescriptions);
        }

        //kit_order/id (put)
        // PUT: api/Prescription/5
        [HttpPut("{id}")]
        public IActionResult PutPrescription(long id,Prescription prescriptionInput)
        {
            if (id != prescriptionInput.PrescriptionId)
            {
                return BadRequest();
            }
            var Prescription = prescriptions.SingleOrDefault(x => x.PrescriptionId == id);
            Prescription = prescriptionInput;

            if (prescriptions.Count == 0)
            {
                return NotFound("No List found");
            }
            return Ok(prescriptionInput);
        }

    }

}