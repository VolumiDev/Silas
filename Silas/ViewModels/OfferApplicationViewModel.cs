using System;

namespace Silas.ViewModels
{
    public class OfferApplicationViewModel
    {
        public int StudentId { get; set; }
        public string StudentNie { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentGender { get; set; }
        public DateTime StudentBirthdate { get; set; }
        public string StudentPhone { get; set; }
        public string StudentEmergencyPhone { get; set; }
        public string ApplicationPresentation { get; set; }
        public int ApplicationStatus { get; set; }
    }
}
