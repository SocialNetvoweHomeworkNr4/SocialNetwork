using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class Bazuka : IWeapon
    {
        public string Kill()
        {
            return "BIG BADABUM!";
        }
    }

    public interface IWeapon
    {
        string Kill();
    }
}
