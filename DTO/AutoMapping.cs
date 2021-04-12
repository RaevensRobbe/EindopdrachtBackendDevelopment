using System;
using AutoMapper;
using EindopdrachtBackendDevelopment.Models;

namespace EindopdrachtBackendDevelopment.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {
            CreateMap<SponsorDTO, Sponsor>();
            CreateMap<TeamDTO, Team>();
        }
    }
}
