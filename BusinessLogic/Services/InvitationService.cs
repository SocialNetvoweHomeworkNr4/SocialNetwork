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

        public List<int> GetInvitesByMe(int id) // I invited others
        {
            try
            {
                return GetMany(s => s.CurrentUserID == id && s.Accepted == false).Select(s => s.RequestedUserID).Distinct().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<int> GetMyInvites(int id) // I'am invited
        {
            try
            {
                return GetMany(s => s.RequestedUserID == id && s.Accepted == false).Select(s => s.CurrentUserID).Distinct().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool AcceptDeclineInvite(int userId, int requestedUserId, bool act )
        {

            if(userId > 0 && requestedUserId > 0)
            {
                var invitation = Get(s => s.CurrentUserID == userId && s.RequestedUserID == requestedUserId);
                if(act == true)
                {
                    invitation.Accepted = true;
                    this.Update(invitation);
                }
                else if(act == false)
                {
                    this.Delete(invitation);
                }     
                dataContext.SaveChanges();
                return true;
            }

            return false;
        }
    }

    public interface IInvitationService : IBaseService<Invintation>
    {
        List<int> GetMyInvites(int id);
        List<int> GetInvitesByMe(int id);
        bool AcceptDeclineInvite(int userId, int requestedUserId, bool act);
        string InviteUser(int currentUserId, int userId);
        int[] GetInvitationIDsByUserId(int userId);
    }
}
