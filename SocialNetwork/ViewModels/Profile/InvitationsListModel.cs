using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels.Profile
{
    public class InvitationsListModel
    {
        public List<ProfileInvitationsViewModel> MyInvitations { get; set; }

        public List<ProfileInvitationsViewModel> InvitationsByMe { get; set; }
    }
}
