using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserImageService : BaseService<UserImage>, IUserImageService
    {
        public UserImageService(IDataContext dataContext)
            : base(dataContext)
        {
        }

    }

    public interface IUserImageService : IBaseService<UserImage>
    {        
    }
}
