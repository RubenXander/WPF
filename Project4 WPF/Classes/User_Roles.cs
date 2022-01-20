using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_WPF.Classes
{
    public class User_Roles
    {
        private int id;
        private int user_id;
        private int role_id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public int user_Id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        
        public int role_Id
        {
            get { return role_id; }
            set { role_id = value; }
        }

    }
}
