using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.Helpers.ValueResolvers
{
    public class CommentValueResolver : ValueResolver<string, string>
    {
        protected override string ResolveCore(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return "No comment";
            }
            else
            {
                return source;
            }
        }
    }
}