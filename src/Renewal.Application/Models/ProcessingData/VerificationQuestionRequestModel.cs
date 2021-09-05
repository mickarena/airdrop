using System;
using System.Collections.Generic;
using System.Text;

namespace Renewal.Application.Models.ProcessingData
{
    public class VerificationQuestionRequestModel
    {
        public string EmailAddress { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public string PolicyReference { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
