using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusinessLogic.Models;
using BusinessLogic.Infrastructure;
using System.Security.Cryptography;
using System.IO;

namespace BusinessLogic.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IDataContext dataContext)
            : base(dataContext)
        {
        }



    }

    public interface IUserService : IService<User>
    {

    }
}
