using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C968___Inventory_System
{
    public class Product
    {
        public Product() { this.ProductID = _id++; }

        public Product(String name, decimal price, int stock, int min, int max)
        {
            this.ProductID = _id++;
            this.Name = name;
            this.Price = price;
            this.InStock = stock;
            this.Min = min;
            this.Max = max;
        }

        public BindingList<Part> AssociatedParts { get; set; } = new BindingList<Part>();
        private static int _id = 0;
        public int ProductID { get; private set; }
        public  String Name { get; set; }
        public decimal Price { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int InStock { get; set; }


        public void copyID(Product product)
        {
            this.ProductID = product.ProductID;
        }

        public void addAssociatedPart(Part part)
        {
            this.AssociatedParts.Add(part);
        }

        public bool removeAssociatedPart(int partID)
        {
            var part = this.lookupAssocatedPart(partID);
            return this.AssociatedParts.Remove(part);
        }

        public Part lookupAssocatedPart(int partID)
        {
            foreach (Part part in this.AssociatedParts)
            {
                if (partID == part.PartID)
                {
                    return part;
                }
            }
            return null;
        }
    }
}
