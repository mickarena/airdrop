using AutoMapper;
using Renewal.Application.Mappings;

namespace Renewal.Application.Models.OnlineRenewalsStatus
{
    public class OnlineRenewalsStatusResponseModel : IMapFrom<Domain.Entities.OnlineRenewalsStatus>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.OnlineRenewalsStatus, OnlineRenewalsStatusResponseModel>();
        }
    }
}
