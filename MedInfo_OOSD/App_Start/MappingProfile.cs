using AutoMapper;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Dtos;
using MedInfo_OOSD.Models;

namespace MedInfo_OOSD
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Model to Domain
            Mapper.CreateMap<NewDoctorViewModel, Doctor>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            
            //Domain to Model

            Mapper.CreateMap<Doctor, NewDoctorViewModel>();
            Mapper.CreateMap<Doctor, DoctorDto>();
        }
    }
}