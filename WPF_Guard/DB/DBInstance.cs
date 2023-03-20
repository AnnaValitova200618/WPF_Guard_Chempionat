using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Guard.DB
{
    public class DBInstance
    {
        private static User501Context instance;
        public static User501Context GetInstance()
        {
            if(instance == null)
                instance = new User501Context();
            return instance;
        }
    }
}
