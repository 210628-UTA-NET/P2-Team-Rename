using AutoMapper;
using Entities.Database;
using Entities.Dtos;

namespace API {
    public class AutoMapping : Profile {
        public AutoMapping() {
            CreateMap<User, UserDto>();
            CreateMap<TutorApplication, TutorApplicationDto>();
        }
    }
}