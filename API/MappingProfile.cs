using AutoMapper;
using Entities.Database;
using Entities.Dtos;
using NetTopologySuite.Geometries;

namespace API {
    public class AutoMapping : Profile {
        public AutoMapping() {
            CreateMap<User, UserDto>();
            CreateMap<TutorApplication, TutorApplicationDto>();
            CreateMap<SubmitTutorApplicationDto, TutorApplication>();
            CreateMap<DegreeCertification, DegreeOrCertDto>();
            CreateMap<DegreeOrCertDto, DegreeCertification>();
            CreateMap<User, Tutor>();
            CreateMap<Tutor, TutorDto>();
            CreateMap<Point, LocationDto>()
                .ForMember(l => l.Latitude, opt => opt.MapFrom(p => p.Y))
                .ForMember(l => l.Longitude, opt => opt.MapFrom(p => p.X));

        }
    }
}