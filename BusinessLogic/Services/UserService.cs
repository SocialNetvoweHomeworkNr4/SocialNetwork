using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private IFriendService friendService;

        public UserService(IDataContext dataContext, IFriendService friendService)
            : base(dataContext)
        {
            this.friendService = friendService;
        }

        public IQueryable<User> GetUsersByUserIDs(int userId)
        {
            int[] userIDs = friendService.GetFriendIDsByUserId(userId);

            return dataContext.Users.Where(a => userIDs.Contains(a.UserID));
        }
    }

    public interface IUserService : IBaseService<User>
    {
        IQueryable<User> GetUsersByUserIDs(int userId);
    }
}
