using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class FriendService : BaseService<Friend>, IFriendService
    {
        public FriendService(IDataContext dataContext)
            : base(dataContext)
        { }

    }

    public interface IFriendService : IBaseService<Friend>
    { }

}
