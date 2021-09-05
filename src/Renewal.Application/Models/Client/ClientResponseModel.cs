using AutoMapper;
using Renewal.Application.Mappings;
using System;

namespace Renewal.Application.Models.Client
{
    public class ClientResponseModel : IMapFrom<Domain.Entities.Client>
    {
        public int ClientNumber { get; set; }
        public string Prefix { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Client, ClientResponseModel>();
        }
    }
}
