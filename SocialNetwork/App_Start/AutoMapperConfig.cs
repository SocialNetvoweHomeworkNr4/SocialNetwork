using AutoMapper;
using BusinessLogic.Models;
using SocialNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<UserImage, UserImageViewModel>()
                .ForMember(d => d.Date, i => i.MapFrom(s => s.Date.ToString()))
                .ForMember(d => d.Comments, i => i.MapFrom(s => s.UserImageComments.ToList()));

            Mapper.CreateMap<UserImageViewModel, UserImage>();

            Mapper.CreateMap<UserImageComment, ImageCommentViewModel>()
                .ForMember(d => d.AuthorName, i => i.MapFrom(s => string.Format("{0} {1}", s.User.FirstName, s.User.LastName)))
                .ForMember(d => d.Date, i => i.MapFrom(s => s.Date.ToString()));
        }
    }
}