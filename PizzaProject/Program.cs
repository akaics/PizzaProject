using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
namespace PizzaProject
{
    internal class Program
    {

        // calculate full price
        // whenever you catch an exception, you show the menu again (application shouldn't end) 

        static double fullPrice = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gül's Pizzaria!! حلال  Please check out our menu: ");
            ShowMenu();
            Console.WriteLine();
            Toppings();
            // HowManyPizzas();
            ChooseDrink();
            Console.Clear();
            AddExtraDrink();


            // Console.WriteLine("Your total is " + fullPrice);

        }


        public static void ShowMenu()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Pizzas:");
                Console.WriteLine("1. Carbonara(mozzarella, ricotta, eggs)   100kr");
                Console.WriteLine("2. Diavola(spicy salami):   110kr");
                Console.WriteLine("3. Vegetarian(no meat)   89kr");
                Console.WriteLine();
                Console.WriteLine("Deal: buy 1 pizzas with 2 drinks for 20% off your whole order. The deal will be automatically counted in checkout");
                Console.WriteLine();
                Console.Write("Name the number of the pizza you'd like: ");
                int inputPizza = Convert.ToInt32(Console.ReadLine());

                if (inputPizza == 1)
                {
                    Console.WriteLine("You've chosen Carbonara, with mozzarella, ricotta, and eggs");
                    fullPrice += 100;
                }
                else if (inputPizza == 2)
                {
                    Console.WriteLine("You've chosen Diavola with spicy salami");
                    fullPrice += 110;
                }
                else if (inputPizza == 3)
                {
                    Console.WriteLine("You've chosen Vegetarian with no meat");
                    fullPrice += 89;
                }
                else
                {
                    Console.WriteLine("Please only type between the numbers 1-3.");
                    ShowMenu();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please only type 1, 2, or 3.");
                ShowMenu();
            }
        }

        public static void Toppings()
        {
            try
            {
                Console.WriteLine("Toppings: ");
                Console.WriteLine("1. Extra cheese: +5kr");
                Console.WriteLine("2. Nothing.");
                Console.Write("Choose topping: ");

                int inputToppings = Convert.ToInt32(Console.ReadLine());

                if (inputToppings == 1)
                {
                    Console.WriteLine("You've added extra cheese.");
                    fullPrice += 5;
                }
                else if (inputToppings == 2)
                {
                    Console.WriteLine("No extra toppings, got that.");
                }
                else
                {
                    Console.WriteLine("Please only type between the numbers 1-2.");
                    Toppings();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No letters allowed - only type numbers please.");
                Toppings();
            }
        }

        public static void ChooseDrink()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Drinks Menu:");
                Console.WriteLine("1. Redbull: 25kr");
                Console.WriteLine("2. Cola: 20kr");
                Console.WriteLine("3. Pepsi Max: 20kr");
                Console.Write("Now, please choose a drink:");
                int inputDrink = Convert.ToInt32(Console.ReadLine());

                if (inputDrink == 1)
                {
                    Console.WriteLine("You've added a Redbull, doesn't go with pizza but okay.");
                    fullPrice += 25;
                }
                else if (inputDrink == 2)
                {
                    Console.WriteLine("You've added a cola.. perfect for a meal.");
                    fullPrice += 20;
                }
                else if (inputDrink == 3)
                {
                    Console.WriteLine("You've added a Pepsi Max.");
                    fullPrice += 20;
                }
                else
                {
                    Console.WriteLine("Please only type numbers from 4-6..");
                    ChooseDrink();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please only type numbers, I don't understand what you're trying to say.");
                ChooseDrink();
            }
            finally
            {
                Console.WriteLine("Heres your full price so far: " + fullPrice);
            }
        }

        public static void AddExtraDrink()
        {
            Console.Write("Would you like to add an extra drink? Don't miss out on our deal for 20% off! (yes/no): ");
            string inputYesOrNo = Console.ReadLine().ToLower();

            if (inputYesOrNo == "yes")
            {

                Console.WriteLine("1. Redbull: 25kr");
                Console.WriteLine("2. Cola: 20kr");
                Console.WriteLine("3. Pepsi Max: 20kr");
                Console.WriteLine();
                Console.Write("Yayy just type whichever number you'd like as an extra drink: ");
                int extraDrink = Convert.ToInt32(Console.ReadLine());
                if (extraDrink == 1)
                {
                    Console.WriteLine("You've added a nice Redbull for later.");
                    fullPrice += 25;
                    Console.WriteLine("You will save " + GetDeal(fullPrice) + "kr on your order now!");
                }
                else if (extraDrink == 2)
                {
                    Console.WriteLine("You've added a cola.");
                    fullPrice += 20;
                }
                else if (extraDrink == 3)
                {
                    Console.WriteLine("You've added a Pepsi Max as well.. ew.");
                    fullPrice += 20;
                }
                if (extraDrink >= 1 && extraDrink <= 3)
                {
                    Console.WriteLine("Your full price after the 20% deal is " + GetDeal(fullPrice) + "kr on your order now!");
                }
            }
            else if (inputYesOrNo == "no")
            {
                Console.WriteLine("No deal for you then.");
                Console.WriteLine("Your full price is " + fullPrice);
            }

        }
        public static double GetDeal(double fullPrice)
        {
            return (fullPrice * 0.2);
        }
        // public static int HowManyPizzas()
        //{
        // Console.WriteLine("How many of those pizzas would you like? ");
        //    int howMany = Console.ReadLine();
        // }
    }
}
