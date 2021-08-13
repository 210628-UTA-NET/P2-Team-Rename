using AutoMapper;
using Entities.Database;
using Entities.Dtos;
using NetTopologySuite.Geometries;
using System.Linq;

namespace API {
    public class AutoMapping : Profile {
        public AutoMapping() {
            CreateMap<User, UserDto>();
            CreateMap<TutorApplication, TutorApplicationDto>()
                .ForMember(a => a.Topics, opt => opt.MapFrom(tu => tu.Topics.Select(topic => topic.TopicName).ToList()));
            CreateMap<SubmitTutorApplicationDto, TutorApplication>();
            CreateMap<DegreeCertification, DegreeOrCertDto>();
            CreateMap<DegreeOrCertDto, DegreeCertification>();
            CreateMap<User, Tutor>();
            CreateMap<Tutor, TutorDto>()
                .ForMember(t => t.Topics, opt => opt.MapFrom(tu => tu.TutorTopics.Select(topic => topic.TopicName).ToList()));
            CreateMap<Point, LocationDto>()
                .ForMember(l => l.Latitude, opt => opt.MapFrom(p => p.Y))
                .ForMember(l => l.Longitude, opt => opt.MapFrom(p => p.X));
        }
    }
}