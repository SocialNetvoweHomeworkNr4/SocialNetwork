﻿using BusinessLogic.Models;
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

        public int[] GetFriendIDsByUserId(int userId)
        {
            return dataContext.Friends.Where(a => a.CurrentUserID == userId).Select(a => a.FriendID).ToArray<int>();
        }

        public void DeleteFriend(int userId, int friendId)
        {
            Friend friend = dataContext.Friends.FirstOrDefault(a => a.CurrentUserID == userId && a.FriendID == friendId);

            base.Delete(friend);
        }
    }

    public interface IFriendService : IBaseService<Friend>
    {
        int[] GetFriendIDsByUserId(int userId);
        void DeleteFriend(int userId, int friendId);
    }

}
