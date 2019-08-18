using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentNetwork.DAL
{
    public class Helpers
    {
        public static int GetHashCode(object obj)
        {
            return obj == null ? -1 : obj.GetHashCode();
        }
    }
}
