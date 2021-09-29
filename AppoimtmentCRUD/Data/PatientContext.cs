using AppoimtmentCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppoimtmentCRUD.Data
{
    public interface IPatientContext
    {
        public DbSet<Patient> Patients {get;set;}

        Task SaveChangesAsync();
        EntityEntry Entry(Patient patient);
    }

    public class PatientContext: DbContext, IPatientContext
    {
        public DbSet<Patient> Patients { get; set; }
        public PatientContext(DbContextOptions<PatientContext> context) : base(context)
        {
        }

        public Task SaveChangesAsync() => base.SaveChangesAsync();

        public EntityEntry Entry(Patient patient) => base.Entry(Patients);
    }
}
