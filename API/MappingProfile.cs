using AutoMapper;
using DL.Entities;
using API.Entities;

namespace API {
    public class AutoMapping : Profile {
        public AutoMapping() {
            CreateMap<User, UserDto>();
        }
    }
}