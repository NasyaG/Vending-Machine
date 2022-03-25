using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Product
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Inventory { get; set; } = 5;
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(string location, string name, decimal price, string category)
        {
            this.Location = location;
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }

        // public Product PotatoCrisps = new Product("A1", "PotatoCrisps", 3.05M, "Chip");
        //  public Product Uchews = new Product("D1", "Uchews", 0.85M, "Gum");



        public virtual int DispenseProduct(string productLocation)
        {
            //subtract from the inventory
            if (Inventory == 0)
            { //  Console.WriteLine("SOLD OUT");
                //Can we put this functionality into the printer/display class?
                return Inventory;
            }

            else
            {
                Inventory -= 1;
                return Inventory;
            }

        }




    }
}
