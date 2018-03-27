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

            Mapper.CreateMap<CommentViewModel, Comment>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<BloodBankViewModel, BloodBank>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            


            //Domain to Model
            Mapper.CreateMap<Doctor, NewDoctorViewModel>();
            Mapper.CreateMap<Doctor, DoctorDto>();
            Mapper.CreateMap<Hospital, NewHospitalViewModel>();
            Mapper.CreateMap<Hospital, HospitalDto>();
            Mapper.CreateMap<Speciality, SpecialityDto>();
            Mapper.CreateMap<Doctor, DoctorDetailsViewModel>();
            Mapper.CreateMap<Hospital, HospitalDetailsViewModel>();
            Mapper.CreateMap<Comment, CommentDto>();
            Mapper.CreateMap<BloodBank, BloodBankViewModel>();
            Mapper.CreateMap<BloodBank, BankDetailsViewModel>();
            Mapper.CreateMap<BloodBank, BloodBankDto>();
           


            //Domain to Domain
            Mapper.CreateMap<Speciality, Speciality>();
        }
    }
}