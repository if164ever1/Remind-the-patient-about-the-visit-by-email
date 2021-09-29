using System;

namespace ServerRemaindEmail
{
    public class Patient
    {
        public int ID{ get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string phoneNumber { get; set; }
        public DateTime VisitTime { get; set; }
        public bool IsAddEmailReminder { get; set; }
        public bool IsSendEmailRemainder { get; set; }
    }
}
