using AutoMapper;
using Adres.API.Data.Contracts;
using Adres.API.Data.Contracts.Dto;
using Adres.API.Data.Contracts.Requests;
using Adres.API.Model;
using LP.Common.Payout.Dtos;
using LP.Common.Payout.Requests;
using System;
using System.Linq;
using System.Net.Http;

namespace Adres.API.Services.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AcquisitionRequerimentRequest, AcquisitionRequirement>()
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Quantity * src.UnitaryValue));

            CreateMap<AcquisitionRequirement, AcquisitionRequirementDto>();
            //    .ForMember(dest => dest.Method, opt => opt.MapFrom(src => src.Method.ToString()))
            //    .ForMember(dest => dest.ResponseCode, opt => opt.MapFrom(src => src.ResponseCode));




        }
    }
}