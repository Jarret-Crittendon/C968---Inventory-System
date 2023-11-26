using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968___Inventory_System
{
    public class Inventory
    {
        public Inventory() { }

        public BindingList<Product> Products { get; set; } = new BindingList<Product>();
        public BindingList<Part> AllParts { get; set; } = new BindingList<Part>();

        ////////////////////////
        
        public void addProduct(Product product)
        {
            Products.Add(product);
        }

        public bool removeProduct(int productID)
        {
            foreach (Product item in Products)
            {
                if (productID == item.ProductID)
                {
                    Products.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public Product lookupProduct(int productID)
        {
            foreach (Product item in Products)
            {
                if (productID == item.ProductID)
                {
                    return item;
                }
            }

            return null;
        }

        public void updateProduct(int productID, Product product)
        {
            var item = lookupProduct(productID);
            if (item != null)
            {
                item.Name = product.Name;
                item.InStock = product.InStock;
                item.Price = product.Price;
                item.Min = product.Min;
                item.Max = product.Max;
                item.AssociatedParts = new BindingList<Part>(product.AssociatedParts);    
            }
        }

        public bool replaceProduct(Product oldProduct, Product newProduct)
        {
            newProduct.copyID(oldProduct);
            Products.Add(newProduct);
            return Products.Remove(oldProduct);

        }

        public void addPart(Part part)
        {
            AllParts.Add(part);
        }

        public bool deletePart(Part part)
        {
            return AllParts.Remove(part);
        }

        public void updatePart(int partID, Part part)
        {
            var oldPart = lookupPart(partID);
            var oldIndex = AllParts.IndexOf(oldPart);
            part.copyID(oldPart);
            AllParts.Insert(oldIndex, part);
            deletePart(oldPart);
            
        }

        public Part lookupPart(int partID)
        {
            foreach (Part item in AllParts)
            {
                if (partID == item.PartID)
                {
                    return item;
                }
            }

            return null;
        }

    }
}
