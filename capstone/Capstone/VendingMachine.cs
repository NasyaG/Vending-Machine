using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {

        public decimal Balance { get; set; }
        public decimal VendingMachineBalance { get; set; }



       
        public VendingMachine(decimal Balance, decimal VendingMachineBalance)
        {
            this.Balance = Balance;
            this.VendingMachineBalance = VendingMachineBalance;

        }

        public VendingMachine() { }




        public void AddMoney()
        {
            bool moneyMenu = true;

            while (moneyMenu)
            {
                Console.Clear();
                Console.WriteLine("Please enter the amount you will put into the machine($1.00, $2.00, $5.00, $10.00):");
                string feedMoney = Console.ReadLine();
               //going to have to do "out of area exception" or something.  1,2,5,10 only. 

                Balance += decimal.Parse(feedMoney);
                Console.WriteLine($"You have added {feedMoney}. Your balance is now: $ {Balance}.");

                WriteLog("FEED MONEY", decimal.Parse(feedMoney), Balance);

                Console.WriteLine("Would you like to add more? y/n");
                string exit = Console.ReadLine();
                if (exit == "n")
                {
                    moneyMenu = false;
                    // MainMenu(); 
                    // How do we get to the main menu?!?
                     
                }

            }
            Console.WriteLine("debug" + Balance);
        }




        public void SelectProduct()
        {
           
            bool moneyMenu = true;

            while (moneyMenu)
            {
                Console.Clear();
                Console.WriteLine("Please look at the items below and make a selection");
                Console.WriteLine("Your current balance is" + Balance);
                foreach (KeyValuePair<string, Product> kvp in Inventory.ProductDictionary)
                {
                    Console.WriteLine(kvp.Key + "  " + kvp.Value.Name + "   " + kvp.Value.Price);
                }


                string selection = Console.ReadLine();
                
                foreach (KeyValuePair<string, Product> kvp in Inventory.ProductDictionary)
                {
                    //does this object have property(a1 location)?
                    if (kvp.Key.Contains(selection) && kvp.Value.Inventory > 0 && Balance > kvp.Value.Price)
                    {
                        kvp.Value.Inventory--;
                        Balance -= kvp.Value.Price;
                        VendingMachineBalance += kvp.Value.Price;
                        string toPrint = string.Join(kvp.Key, kvp.Value.Name);


                        WriteLog(toPrint, kvp.Value.Price, Balance);

                        switch (kvp.Value.Category)
                        {
                            case "Chip":
                                Console.WriteLine("Crunch Crunch, Yum");
                                Console.WriteLine("Would you like to make another selection? (y/n)");
                                string anotherSelection = Console.ReadLine();
                                if (anotherSelection == "n")
                                {
                                    moneyMenu = false;
                                }
                                break;
                            case "Candy":
                                Console.WriteLine("Munch Munch, Yum!");
                                Console.WriteLine("Would you like to make another selection? (y/n)");
                                string anotherSelection2 = Console.ReadLine();
                                if (anotherSelection2 == "n")
                                {
                                    moneyMenu = false;
                                }
                                break;
                            case "Drink":
                                Console.WriteLine("Glug Glug, Yum");

                                Console.WriteLine("Would you like to make another selection? (y/n)");
                                string anotherSelection3 = Console.ReadLine();
                                if (anotherSelection3 == "n")
                                {
                                    moneyMenu = false;
                                }
                                break;
                            case "Gum":
                                Console.WriteLine("Chew Chew, Yum");

                                Console.WriteLine("Would you like to make another selection? (y/n)");
                                string anotherSelection4 = Console.ReadLine();
                                if (anotherSelection4 == "n")
                                {
                                    moneyMenu = false;
                                }
                                break;

                        }
                        Console.WriteLine("Thank you!");

                    }
                    else if (kvp.Key.Contains(selection) && kvp.Value.Inventory == 0)
                    {
                        Console.WriteLine("SOLD OUT");
                        //return to purchase menu
                    }


                }
                //log 
            }
        }



        public void FinishTransaction()
        {
            bool transactionMenu = true;
            while (transactionMenu)
            {
               Console.Clear();
                if (Balance > 0.05M)
                {

                    //decimal qaurters = Balance / 0.25M;
                    int qaurters = (int)Math.Floor(Balance / 0.25M);
                    Balance -= (0.25M * qaurters);


                    int dimes = (int)Math.Floor(Balance / 0.10M);
                    Balance -= (0.10M * dimes);

                    int nickles = (int)Math.Floor(Balance / 0.05M);
                    Balance -= (0.05M * nickles);

                    Console.WriteLine($"Thank you for your purchase! Here are your {qaurters} qaurters, {dimes} dimes, and {nickles} nickles.");
                    decimal changeCoins = qaurters + dimes + nickles;
                    decimal changeTotal = (0.25M * qaurters) + (0.10M * dimes) + (0.05M * nickles); 

                    WriteLog("GIVE CHANGE", changeTotal, Balance);
                    Console.WriteLine("To return to the main menu, press n");
                    string returnMenu = Console.ReadLine();
                    if (returnMenu == "n") 
                    { transactionMenu = false; }

                }
                else
                {
                    Console.WriteLine("Thank you for your purchase! Press any key to return to the main menu");
                    Console.ReadLine();
                    transactionMenu = false; 
                }
            }
        }


        public void WriteLog(string category, decimal amount, decimal totals)
        {
            string logDirectory = Environment.CurrentDirectory;
            const string relativeLogName = @"..\..\..\Log.txt";
            string fullLogPath = Path.Combine(logDirectory, relativeLogName);
            string actualLogPath = Path.GetFullPath(fullLogPath);
            
            
            using (StreamWriter sw = new StreamWriter(actualLogPath, true))
            {
                sw.WriteLine(DateTime.Now + " " + category + " " + "$" + amount + " " + "$" + totals);
            }

        }











    }
}
