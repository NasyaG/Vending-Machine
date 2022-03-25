using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Inventory
    {
        public Inventory() { }
        //Importing the data:
        //Get file path
        //Verify file exists
        //open and read the file
        //readLine and:
        //EACH line is seperated and put into an List?
        // pipe seperated 
        // index 0: location property.  index 1: name property....
        // access each list to set the properties of each class
        // set Class.Property= List index 0, 1, 2 etc.  Parse the price 
        //
        //

        public static Dictionary<string, Product> ProductDictionary = new Dictionary<string, Product>(); 


        public static void ImportVendingStock()
        {
            const string relativeFileName = @"..\..\..\vendingmachine.csv";

            string directory = Environment.CurrentDirectory;
            // Check in that this directory path "environment" is the "dynamic file path" that Myron was talking about

            string importFilePath = Path.Combine(directory, relativeFileName);

            string fullPath = Path.GetFullPath(importFilePath);



            if (File.Exists(importFilePath))
            {
                using (StreamReader sr = new StreamReader(importFilePath))
                {



                    while (!sr.EndOfStream)
                    {
                        
                            string line = sr.ReadLine();

                            List<string> importProperties = new List<string>(line.Split("|"));

                            string location = importProperties[0];
                            string name = importProperties[1];
                            decimal price = decimal.Parse(importProperties[2]);
                            string category = importProperties[3];

                            Product productName  = new Product(location, name, price, category) { };

                        ProductDictionary.Add(location, productName);


                           Console.WriteLine($"{name} has been imported!");

                       
                        //instatiate the class, which in turn IS the properties of that class. 
                        //how do we insantiate an object while referencing changing/looping variable?
                        //trying to reference variable name when instantiating the object. 

                        //for or foreach loop to instantiate and give each object a diffrent name (index)?


                    }

                    foreach (KeyValuePair<string, Product> kvp in ProductDictionary)
                    {
                        Console.WriteLine(kvp.Key + "  " + kvp.Value.Name + "   " + kvp.Value.Price); 
                        //Hell yea this prints!!
                    
                    }
                }
            }


        }

    }
}
