using AutoMapper;
using BusinessLogic.Models;
using SocialNetwork.Helpers.ValueResolvers;
using SocialNetwork.ViewModels;
using SocialNetwork.ViewModels.Image;
using SocialNetwork.ViewModels.Profile;
using System.Linq;

namespace SocialNetwork.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<UserImage, UserImageViewModel>()
                .ForMember(d => d.Date, i => i.MapFrom(s => s.Date.ToString()))
                .ForMember(d => d.Comments, i => i.MapFrom(s => s.UserImageComments.ToList()))
                .ForMember(d => d.Comment, i => i.ResolveUsing<CommentValueResolver>().FromMember(s => s.Comment));

            Mapper.CreateMap<UserImageViewModel, UserImage>();

            Mapper.CreateMap<UserImageComment, ImageCommentViewModel>()
                .ForMember(d => d.AuthorName, i => i.MapFrom(s => string.Format("{0} {1}", s.User.FirstName, s.User.LastName)))
                .ForMember(d => d.Date, i => i.MapFrom(s => s.Date.ToString()));

            Mapper.CreateMap<User, UserViewModel>();

            Mapper.CreateMap<User, ProfileInfoViewModel>()
                .ForMember(d => d.BirthDate, i => i.MapFrom(s => s.DateOfBirth))
                .ForMember(d => d.Information, i => i.MapFrom(s => s.Interests))
                .ForMember(d => d.Phone, i => i.MapFrom(s => s.PhoneNumber));

        }
    }
}