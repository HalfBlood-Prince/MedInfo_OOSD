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

            Mapper.CreateMap<NewHospitalViewModel,Hospital>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            
            //Domain to Model

            Mapper.CreateMap<Doctor, NewDoctorViewModel>();
            Mapper.CreateMap<Doctor, DoctorDto>();
            Mapper.CreateMap<Hospital, NewHospitalViewModel>();
            Mapper.CreateMap<Hospital, HospitalDto>();
            Mapper.CreateMap<Speciality, SpecialityDto>();

            //Domain to Domain

            Mapper.CreateMap<Speciality, Speciality>();
        }
    }
}