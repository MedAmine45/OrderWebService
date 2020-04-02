using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIPerspection.Models;

namespace WebAPIPerspection.Models
{
    public class PrescriptionDbContext :DbContext
    {
        public PrescriptionDbContext(DbContextOptions<PrescriptionDbContext> options) : base(options)
        {
        }
       
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescriber> Prescribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType");
        }

        public DbSet<WebAPIPerspection.Models.Person> Person { get; set; }


    }
}
