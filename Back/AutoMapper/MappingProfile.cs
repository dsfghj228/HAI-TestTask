using AutoMapper;
using Back.Dto;
using Back.Models;

namespace Back.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Disease, ReturnDiseaseDto>();
        CreateMap<Doctor, ReturnDoctorDto>();
    }
}