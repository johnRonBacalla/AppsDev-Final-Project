using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Bacalla_Final_ConsoleApp
{
    class Program
    {
        public enum FileCheckSum { Profile, Book }

        public static readonly string BasePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        public static readonly string DataDirFilePath = Path.Combine(BasePath, "data");
        public static readonly string ProfilesFilePath = Path.Combine(BasePath, "data", "profiles.txt");
        public static readonly string BookFilePath = Path.Combine(BasePath, "data", "books.txt");
        public static readonly string LogFilePath = Path.Combine(BasePath, "data", "log.txt");
        public static readonly string ChecksumFilePath = Path.Combine(BasePath, "data", "checksum.txt");

        public static string BooksCheckSum = null;
        public static string ProfilesCheckSum = null;

        static void Main(string[] args)
        {

            bool isRunning = true;
            bool isLoggedIn = false;

            Account acc = new Account();
            Validate check = new Validate();

            FileManager.LoadBooks();

            //initialize files and checksum
            //book already initialized
            Directory.CreateDirectory(DataDirFilePath);
            File.AppendAllText(Program.ProfilesFilePath, "");
            File.AppendAllText(Program.LogFilePath, "");

            if (!File.Exists(Program.ChecksumFilePath))
            {
                File.AppendAllText(Program.ChecksumFilePath, Checksum.getCurrentSum(Program.BookFilePath) + Environment.NewLine);
                File.AppendAllText(Program.ChecksumFilePath, Checksum.getCurrentSum(Program.ProfilesFilePath));
                Console.WriteLine("Checksum Initialized");
            }

            string[] lines = File.ReadAllLines(Program.ChecksumFilePath);

            if (lines.Length > 1)
            {
                BooksCheckSum = lines[0];
                ProfilesCheckSum = lines[1];
            }

            Console.WriteLine(" ________________________________________");
            Console.WriteLine("|                                        |");
            Console.WriteLine("| University of Cebu Library Loan System |");
            Console.WriteLine("|________________________________________|");
            Console.WriteLine(" ----------------------------------------");
            Console.WriteLine();

            while (isRunning)
            {

                if (isLoggedIn)
                {
                    Menu.MainMenu(acc.getUsername());
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "profiles":
                            if(ProfilesCheckSum == Checksum.getCurrentSum(Program.ProfilesFilePath))
                            {
                                FileManager.ShowProfile();
                                FileManager.Log("ID: " + acc.getId() + " read file profiles.txt.");
                            }
                            else
                            {
                                Console.WriteLine("File Corrupted.");
                                FileManager.Log("Error profiles.txt is corrupted.");
                            }
                            break;

                        case "user":
                            Console.Write("Enter new Username: ");
                            string updatedUsername = Console.ReadLine();
                            FileManager.RenameUsername(acc.getId(), updatedUsername);
                            Console.WriteLine("Update Successful");
                            acc.ReloadUsername();
                            FileManager.Log("ID: " + acc.getId() + " changed username to " + acc.getUsername() + ".");
                            break;

                        case "books":
                            if(BooksCheckSum == Checksum.getCurrentSum(Program.BookFilePath))
                            {
                                FileManager.ShowBooks();
                                FileManager.Log("ID: " + acc.getId() + " read file books.txt.");
                            }
                            else
                            {
                                Console.WriteLine("File Corrupted.");
                                FileManager.Log("Error books.txt is corrupted.");
                            }
                            break;

                        case "filter":
                            Menu.FilterMenu();
                            string genre = Console.ReadLine();
                            string[] choices = {"ADV", "HIS", "MNG", "ETH", "SCI"};
                            bool isValid = false;
                            foreach (string choice in choices)
                            {
                                if (genre == choice)
                                {
                                    if (BooksCheckSum == Checksum.getCurrentSum(Program.BookFilePath))
                                    {
                                        FileManager.ShowBooks(genre);
                                        FileManager.Log("ID: " + acc.getId() + " read file books.txt.");
                                        isValid = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("File Corrupted.");
                                        FileManager.Log("Error books.txt is corrupted.");
                                    }
                                }
                            }
                            if (!isValid)
                                Console.WriteLine("Invalid input.");
                            break;

                        case "borrow":
                            FileManager.BorrowBook(acc.getId());
                            break;

                        case "return":
                            if (BooksCheckSum == Checksum.getCurrentSum(Program.BookFilePath))
                            {
                                FileManager.ShowBorrow(acc.getId());
                                FileManager.Log("ID: " + acc.getId() + " read file books.txt.");
                            }
                            else
                            {
                                Console.WriteLine("File Corrupted.");
                                FileManager.Log("Error books.txt is corrupted.");
                            }
                            break;

                        case "deactivate":
                            Console.WriteLine("\nDeactivated accounts will be deleted after 30 days.\nEnter Password to Deactivate Account.");
                            Console.Write("Password: ");
                            string answer = acc.ReadPassword();
                            if (answer == acc.getPassword())
                            {
                                if (FileManager.HasBorrowed(acc.getId()))
                                {
                                    Console.WriteLine("Return borrowed books before deactivation.");
                                }
                                else
                                {
                                    FileManager.DeactivateProfile(acc.getId());
                                    FileManager.Log("ID: " + acc.getId() + " deactivated their account.");
                                    isLoggedIn = false;
                                    acc.clear();
                                }
                            } else Console.WriteLine("Action cancelled!");
                            break;

                        case "delete":
                            Console.WriteLine("\nDelete account permanently.\nEnter Password to Delete Account.");
                            Console.Write("Password: ");
                            string ans = acc.ReadPassword();
                            if (ans == acc.getPassword())
                            {
                                if (FileManager.HasBorrowed(acc.getId()))
                                {
                                    Console.WriteLine("Return borrowed books before deletion.");
                                }
                                else
                                {
                                    FileManager.DeleteProfile(acc.getId());
                                    FileManager.Log("ID: " + acc.getId() + " permanently deleted their account.");
                                    isLoggedIn = false;
                                    acc.clear();
                                }
                            }
                            else Console.WriteLine("Action cancelled!");
                            break;

                        case "logout":
                            isLoggedIn = false;
                            FileManager.Log("ID: " + acc.getId() + " logged out!");
                            acc.clear();
                            break;

                        case "exit":
                            isRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid input, Try Again.");
                            break;
                    }
                } else
                {
                    Menu.LoginMenu();
                    string accountInput = Console.ReadLine();

                    switch (accountInput)
                    {
                        case "login":
                            if (ProfilesCheckSum == Checksum.getCurrentSum(Program.ProfilesFilePath))
                            {
                                if (acc.Login(check))
                                {
                                    if (FileManager.getProfileStatus(acc.getId()) != "active")
                                    {
                                        FileManager.ReactivateProfile(acc.getId());
                                    }
                                    isLoggedIn = acc.isLoggedIn();
                                }
                            }
                            else
                            {
                                Console.WriteLine("File Corrupted.");
                                FileManager.Log("Error profiles.txt is corrupted.");
                            }
                            break;
                        case "register":
                            if (ProfilesCheckSum == Checksum.getCurrentSum(Program.ProfilesFilePath))
                            {
                                acc.Register(check);
                            }
                            else
                            {
                                Console.WriteLine("File Corrupted.");
                                FileManager.Log("Error profiles.txt is corrupted.");
                            }
                            break;
                        case "exit":
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input, Try Again.");
                            break;
                    }
                }
            }
        }
    }
}