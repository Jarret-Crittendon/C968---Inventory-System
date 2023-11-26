using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968___Inventory_System
{
    public abstract class Part
    {
        public Part() { this.PartID = _id++;  }

        public Part(String name, decimal price, int stock, int min, int max)
        {
            this.PartID = _id++;
            this.Name = name;
            this.Price = price;
            this.InStock = stock;
            this.Min = min;
            this.Max = max;
        }

        private static int _id = 0;
        public int PartID { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min {  get; set; }
        public int Max { get; set; }

        public void copyID(Part part)
        {
            this.PartID = part.PartID;
        }
    }

    public class Inhouse : Part
    {
        public Inhouse() { }

        public Inhouse(String name, decimal price, int stock, int min, int max, int machine):
            base(name, price, stock, min, max)
        { this.MachineID  = machine; }

        public int MachineID { get; set; }
    }

    public class Outsourced : Part
    {
        public Outsourced() { }
        
        public Outsourced(String name, decimal price, int stock, int min, int max, String company) :
            base(name, price, stock, min, max)
        { this.CompanyName = company; }


        public String CompanyName { get; set; }
    }
}
