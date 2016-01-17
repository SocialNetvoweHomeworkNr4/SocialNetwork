using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.Helpers.ValueResolvers
{
    public class DateToStringValueResolver : ValueResolver<DateTime, string>
    {
        protected override string ResolveCore(DateTime source)
        {
            return source.ToString(DateHelper.Format);
        }
    }
}