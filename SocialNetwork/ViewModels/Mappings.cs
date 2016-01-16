using AutoMapper;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureUserMapping();
        }

        private static void ConfigureUserMapping()
        {

            Mapper.CreateMap<UserImage, UserImageViewModel>();
            Mapper.CreateMap<UserImageViewModel, UserImage>();
        }
    }
}