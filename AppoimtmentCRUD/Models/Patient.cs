using System;
using System.ComponentModel.DataAnnotations;

namespace AppoimtmentCRUD.Models
{
    public class Patient
    {
        public int ID{ get; set; }
        [Required(ErrorMessage ="First name is required.")]
        [MaxLength(50, ErrorMessage ="First name must contain maximum 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Second name is required.")]
        [MaxLength(50, ErrorMessage = "Second name must contain maximum 50 characters.")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string phoneNumber { get; set; }
        public DateTime VisitTime { get; set; }
        public bool IsAddEmailReminder { get; set; }
        public bool IsSendEmailRemainder { get; set; }
    }
}
