using AutoMapper;
using Entities.Database;
using Entities.Dtos;

namespace API {
    public class AutoMapping : Profile {
        public AutoMapping() {
            CreateMap<User, UserDto>();
            CreateMap<TutorApplication, TutorApplicationDto>();
            CreateMap<SubmitTutorApplicationDto, TutorApplication>();
            CreateMap<DegreeCertification, DegreeOrCertDto>();
            CreateMap<DegreeOrCertDto, DegreeCertification>();
            CreateMap<User, Tutor>();

        }
    }
}