using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_WPF.Classes
{
    public class Orders
    {
        private int id;
        private int user_id;
        private string status;
        private string pizza;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Pizza
        {
            get { return pizza; }
            set { pizza = value; }
        }
        private string grote;

        public string Grote
        {
            get { return grote; }
            set { grote = value; }
        }

    }
}
