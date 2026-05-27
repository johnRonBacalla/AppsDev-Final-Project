using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Bacalla_Final_ConsoleApp
{
    internal class Account
    {
        private string id;
        private string username;
        private string password;

        public bool isLoggedIn()
        {
            return (username != null);
        }

        public void clear()
        {
            id = null;
            username = null;
            password = null;
        }

        public string getUsername()
        {
            return username;
        }

        public string getPassword()
        {
            return password;
        }

        public string getId()
        {
            return id;
        }

        public void Register(Validate check)
        {
            Console.WriteLine(" ______________________ ");
            Console.WriteLine("|                      |");
            Console.WriteLine("| Account Registration |");
            Console.WriteLine("|______________________|");
            Console.WriteLine(" ----------------------");
            Console.WriteLine();

            Console.Write("Student ID: ");
            string studentId = Console.ReadLine();
            while (!check.IdInput(studentId))
            {
                Console.WriteLine("Invalid Student ID.");
                Console.WriteLine("Must not contain white space.");
                Console.WriteLine("Must consist of numbers only.");
                Console.WriteLine();
                Console.Write("Student ID: ");
                studentId = Console.ReadLine();
            }

            while (FileManager.IsStudentIdTaken(studentId))
            {
                Console.WriteLine("Unique Student ID taken.");
                Console.Write("Student ID: ");
                studentId = Console.ReadLine();
                while (!check.IdInput(studentId))
                {
                    Console.WriteLine("Invalid Student ID.");
                    Console.WriteLine("Must not contain white space.");
                    Console.WriteLine("Must consist of numbers only.");
                    Console.WriteLine();
                    Console.Write("Student ID: ");
                    studentId = Console.ReadLine();
                }
            }

            Console.Write("Username: ");
            string username = Console.ReadLine();
            while (!check.UsernameInput(username))
            {
                Console.WriteLine("must be less than 40 characters long.");
                Console.WriteLine("Must not contain white space.");
                Console.Write("Username: ");
                username = Console.ReadLine();
            }

        PromptPassword:
            Console.Write("Password: ");
            string password = ReadPassword();
            while (!check.PasswordInput(password))
            {
                Console.WriteLine("Invalid password.");
                Console.WriteLine("must be 8 - 64 characters long.");
                Console.WriteLine("Must contain atleast 1 number.");
                Console.WriteLine("Must contain atleast 1 uppercase.");
                Console.WriteLine("Must contain atleast 1 lowercase.");
                Console.WriteLine("Must contain atleast 1 special character.");
                Console.WriteLine("Must not contain white space.");

                Console.WriteLine();
                Console.Write("Password: ");
                password = ReadPassword();
            }

            Console.Write("Confirm Password: ");
            string confirmPassword = ReadPassword();
            while (!string.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                Console.WriteLine("Password Mismatch!");
                goto PromptPassword;
            }

            //Save Credentials to Profiles.txt
            FileManager.AddProfile(studentId, username, password);
            Checksum.UpdateProfileSum();

            Console.WriteLine("Account Saved!");
        }

        public bool Login(Validate check)
        {
            Console.Write("Student ID: ");
            string studentId = Console.ReadLine();

            Console.Write("Password: ");
            string pass = ReadPassword();

            if (FileManager.FindIdPass(studentId, pass) != null)
            {
                id = studentId;
                username = FileManager.FindIdPass(studentId, pass);
                password = pass;
                Console.WriteLine("Log in Successful.");
                FileManager.Log("ID: " + id + " logged in!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
                return false;
            }
        }

        public void ReloadUsername()
        {
            username = FileManager.FindIdPass(id, password);
        }

        public string ReadPassword()
        {
            string password = "";

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password[0..^1];
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
            }

            return password;
        }
    }
}
