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
        private int customer_id;
        private string status;
        private string pizza;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Customer_id
        {
            get { return customer_id; }
            set { customer_id = value; }
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
