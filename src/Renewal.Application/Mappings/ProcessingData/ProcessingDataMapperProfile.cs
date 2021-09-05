using AutoMapper;
using Renewal.Application.Models.Financial;
using Renewal.Domain.Entities;
using System;

namespace Renewal.Application.Mappings.ProcessingData
{
    public class ProcessingDataMapperProfile : Profile
    {
        public ProcessingDataMapperProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<RenewalInvites, RenewalProcessing>()
                .ForPath(d => d.AffinityCode, opt => opt.MapFrom(s => s.AffinityCode))
                .ForPath(d => d.RenewalProcessStatusDate, opt => opt.MapFrom(s => DateTime.Now))
                .AfterMap(AfterMap);
            CreateMap<RenewalInvites, FinancialResponseModel>();
        }

        private void AfterMap(RenewalInvites s, RenewalProcessing d)
        {
            d.PaymentMethod = null;
            d.RenewalProcessStatusDate = DateTime.Now;
            d.PaymentTransactionId = null;
            d.RenewalProcessStatus = null;
        }
    }
}
