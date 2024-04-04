using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs;
using Core.Entities;

namespace Business.Shared
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Conversation, ConversationCreateDTO>();
            CreateMap<Conversation, ConversationInfoDTO>();
            CreateMap<Message, MessageGetAllDTO>();
            CreateMap<Message, MessageSimpleDTO>();
            CreateMap<User, UserCreateDTO>();
            CreateMap<User, UserReadDTO>();
        }
    }
}
