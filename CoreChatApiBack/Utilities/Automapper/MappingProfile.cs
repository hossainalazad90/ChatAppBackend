using AutoMapper;
using CoreChatApiBack.Models;
using CoreChatApiBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.Utilities.Automapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, SignUpViewModel>().ReverseMap();
            //CreateMap<SignUpViewModel, User>();
        }
    }
}
