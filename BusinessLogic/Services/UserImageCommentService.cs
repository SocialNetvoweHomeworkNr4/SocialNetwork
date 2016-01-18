using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserImageCommentService : BaseService<UserImageComment>, IUserImageCommentService
    {
        public UserImageCommentService(IDataContext dataContext)
            : base(dataContext)
        { }

    }

    public interface IUserImageCommentService : IBaseService<UserImageComment>
    { }
}
