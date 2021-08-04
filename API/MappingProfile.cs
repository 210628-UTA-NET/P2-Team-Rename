using AutoMapper;
using DL.Entities;

namespace API {
    public class AutoMapping : Profile {
        public AutoMapping() {
            CreateMap<User, UserDto>();
        }
    }
}