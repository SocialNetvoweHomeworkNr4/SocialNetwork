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
    }

    public interface IInvitationService : IBaseService<Invintation>
    {
        string InviteUser(int currentUserId, int userId);
    }
}
