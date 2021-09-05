using System;

namespace Renewal.Application.Models.Client
{
    public class ClientDetailsResponseModel
    {
        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public string RecordStatusName { get; set; }
    }
}
