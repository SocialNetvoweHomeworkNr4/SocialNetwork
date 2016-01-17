using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class InvitationService : BaseService<Invintation>, IInvitationService
    {
        public InvitationService(IDataContext dataContext)
            : base(dataContext)
        { }

        public string InviteUser(int currentUserId, int userId)
        {
            try
            {
                this.Add(new Invintation()
                {
                    Accepted = false,
                    CurrentUserID = currentUserId,
                    RequestedUserID = userId
                });

                dataContext.SaveChanges();

                return null;
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public int[] GetInvitationIDsByUserId(int userId)
        {
            List<int> IDs = dataContext.Invintations.Where(a => a.CurrentUserID == userId).Select(a => a.RequestedUserID).ToList<int>();
            IDs.AddRange(dataContext.Friends.Where(a => a.FriendID == userId).Select(a => a.CurrentUserID).ToList<int>());

            return IDs.ToArray<int>();
        }
    }

    public interface IInvitationService : IBaseService<Invintation>
    {
        string InviteUser(int currentUserId, int userId);
        int[] GetInvitationIDsByUserId(int userId);
    }
}
