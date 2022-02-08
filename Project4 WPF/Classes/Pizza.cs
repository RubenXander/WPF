using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_WPF.Classes
{
    public class Pizza
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string pizzas;

        public string Pizzas
        {
            get { return pizzas; }
            set { pizzas = value; }
        }

        private string prijs;

        public string Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
