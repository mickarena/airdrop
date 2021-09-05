using System;
using System.Collections.Generic;
using System.Text;

namespace Renewal.Domain.Entities
{
    public class Client
    {
        public string PolicyReferenceNumber { get; set; }
        public int ClientNumber { get; set; }
        public string Prefix { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostCode { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreated { get; set; }

        public List<Policy> Policies { set; get; }
    }
}
