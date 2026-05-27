using System;
using System.Collections.Generic;
using System.Text;

namespace Bacalla_Final_ConsoleApp
{
    internal class Menu
    {
        public static void MainMenu(string username)
        {
            Console.WriteLine(" ___________ ");
            Console.WriteLine("|           |");
            Console.WriteLine("| Main Menu |");
            Console.WriteLine("|___________|");
            Console.WriteLine(" -----------");
            Console.WriteLine();
            Console.WriteLine("Welcome, " + username + "!");
            Console.WriteLine();
            Console.WriteLine("{0,-25} {1,5}", "edit username", "[user]");
            Console.WriteLine("{0,-25} {1,5}", "borrow available books", "[borrow]");
            Console.WriteLine("{0,-25} {1,5}", "return borrowed books", "[return]");
            Console.WriteLine("{0,-25} {1,5}", "list all active profiles", "[profiles]");
            Console.WriteLine("{0,-25} {1,5}", "list all books", "[books]");
            Console.WriteLine("{0,-25} {1,5}", "list specific books", "[filter]");
            Console.WriteLine("{0,-25} {1,5}", "deactivate account", "[deactivate]");
            Console.WriteLine("{0,-25} {1,5}", "delete account", "[delete]");
            Console.WriteLine("{0,-25} {1,5}", "log out", "[logout]");
            Console.WriteLine("{0,-25} {1,5}", "close the program", "[exit]");
            Console.WriteLine();
            Console.Write("Input: ");
        }

        public static void LoginMenu()
        {
            Console.WriteLine(" ____________ ");
            Console.WriteLine("|            |");
            Console.WriteLine("| Login Menu |");
            Console.WriteLine("|____________|");
            Console.WriteLine(" ------------");
            Console.WriteLine();
            Console.WriteLine("{0,-25} {1,5}", "Login to your account", "[login]");
            Console.WriteLine("{0,-25} {1,5}", "Register new account", "[register]");
            Console.WriteLine("{0,-25} {1,5}", "Close the program", "[exit]");
            Console.WriteLine();
            Console.Write("Input: ");
        }

        public static void FilterMenu()
        {
            Console.WriteLine(" ______________");
            Console.WriteLine("|              |");
            Console.WriteLine("| Choose Genre |");
            Console.WriteLine("|______________|");
            Console.WriteLine(" --------------");
            Console.WriteLine();
            Console.WriteLine("{0,-25} {1,5}", "Adventure", "[ADV]");
            Console.WriteLine("{0,-25} {1,5}", "Ethics", "[ETH]");
            Console.WriteLine("{0,-25} {1,5}", "Science", "[SCI]");
            Console.WriteLine("{0,-25} {1,5}", "Mangaka", "[MNG]");
            Console.WriteLine("{0,-25} {1,5}", "History", "[HIS]");
            Console.WriteLine();
            Console.Write("Input: ");
        }
    }
}
