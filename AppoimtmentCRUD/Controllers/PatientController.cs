using AppoimtmentCRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AppoimtmentCRUD.Models;
using System.Net;
using System.Net.Mail;
using Ninject;

namespace AppoimtmentCRUD.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientContext context;
        public PatientController(IPatientContext patientContext)
        {
            this.context = patientContext;
        }
        public async Task<IActionResult> Index()
        {
            var patients = await context.Patients.ToListAsync();
            return View(patients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                context.Patients.Add(patient);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var patientDb = await context.Patients.FirstOrDefaultAsync(e => e.ID == id);
            if(patientDb == null) return NotFound();
            return View(patientDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            context.Entry(patient).State = EntityState.Modified;
            context.Patients.Update(patient);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var patientDb = await context.Patients.FirstOrDefaultAsync(e => e.ID == id);
            if (patientDb == null) return NotFound();

            context.Patients.Remove(patientDb);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var patientDb = await context.Patients.FirstOrDefaultAsync(e => e.ID == id);
            if (patientDb == null) return NotFound();
            return View(patientDb);
        }

        public IActionResult SendReminders(string email)
        {
            if (email == null) return BadRequest();

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("zihor990@gmail.com");
                    mail.To.Add("traktor20011 @gmail.com");
                    mail.Subject = "Hello World";
                    mail.Body = "<h1>Hello</h1>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("zihor990@gmail.com", "Ihor569ihor569");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
            ViewBag.Message = "Mail has been sent Successfuly!";
            return View();
        }
    }
}
