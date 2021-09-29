using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerRemaindEmail
{
    class Program
    {
        static void Run()
        {
            const int hourBeforeSend = 120;
            using (PatientContext db = new PatientContext())
            {
                var patients = db.Patients;

                foreach (var u in patients)
                {
                    if ((DateTime.Now.Minute - u.VisitTime.Minute) == hourBeforeSend)
                    {
                        try
                        {
                            SendEmailMessage sendEmailMessage = new SendEmailMessage(u.ID, u.Email.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    if (u.VisitTime.ToShortDateString() == "27.09.2021" && !u.IsSendEmailRemainder)
                    {
                        try
                        {
                            Console.WriteLine("The reminder has been sent!");
                            SendEmailMessage sendEmailMessage = new SendEmailMessage(u.ID, u.Email.ToString());
                            u.IsSendEmailRemainder = true;

                            Console.WriteLine("Save changes to database!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Run();
                Thread.Sleep(5000);
                Console.WriteLine(DateTime.Now);
            }   
        }
    }
}
