using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Display
    {
        public void Run()
        {


            Inventory inv = new Inventory();
           
            Inventory.ImportVendingStock();
            MainMenu(); 

            //not able to close main menu and continue/ run methods infinite loop
            // bool showMenu = true;

            // while (showMenu)
            //  {

            //     showMenu = MainMenu();
            // }

            

            static void MainMenu()   //make bool to operate a while loop? who knows 
            {
                VendingMachine vm = new VendingMachine();
                int choice = 0;
                while (choice != 4)
                {
              
                    
                
                Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan; 
                    Console.WriteLine(
@"
            ______________
            |____________|
            |__Umbrella__|
   * ~ *    |____________|    * ~ *
            |            |
            |      [ ]   |
            |@  @  @ @ @ |
            | @  @  @ @ @|
            |@  @  @ @   |
            |____________|
            |_|--------|_|
            |_|________|_|
            |____________|
                            ");
                    Console.ForegroundColor = ConsoleColor.White; 
                Console.WriteLine("Welcome to our dysfunctional vending machine.  Maybe it will work!!");
                Console.WriteLine("Please enter a number to continue:");
                Console.WriteLine("1: Feed Money");
                Console.WriteLine("2: Select Product");
                Console.WriteLine("3: Finish Transaction");
                choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        vm.AddMoney();
                    }
                    else if (choice == 2)
                    {
                        vm.SelectProduct();
                    }
                    else if (choice == 3)
                    {
                        vm.FinishTransaction();
                    }
                    else choice = 0; 

            }







                //switch (menuSelection)
                //{
                //    //get the menu progression to work.  Right now it's just looping in the main menu.  

                //    case "1":
                //        vm.AddMoney();
                //        break;
                //    // and use the MakeAPurchase()

                //    case "2":
                //        vm.SelectProduct();
                //        break; 

                //        //   case "3":
                //        //   vm.FinishTransaction();
                //        //   break;

                //}//return false will close the program



            }

        }
    }
}
                    
       

    

