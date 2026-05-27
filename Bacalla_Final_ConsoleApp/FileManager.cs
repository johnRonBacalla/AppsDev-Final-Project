using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Bacalla_Final_ConsoleApp
{
    internal class FileManager
    {
        public static void LoadBooks()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Program.ProfilesFilePath));

            if (!File.Exists(Program.BookFilePath))
            {
                string[] books =
                {
                    "ADV001|Treasure Island|Robert Louis Stevenson|active",
                    "ADV002|Journey to the Center of the Earth|Jules Verne|active",
                    "ADV003|The Three Musketeers|Alexandre Dumas|active",
                    "ADV004|Robinson Crusoe|Daniel Defoe|active",
                    "ADV005|The Call of the Wild|Jack London|active",
                    "ADV006|White Fang|Jack London|active",
                    "ADV007|King Solomon's Mines|H. Rider Haggard|active",
                    "ADV008|The Lost World|Arthur Conan Doyle|active",
                    "ADV009|Moby-Dick|Herman Melville|active",
                    "ADV010|Around the World in Eighty Days|Jules Verne|active",
                    "ADV011|The Count of Monte Cristo|Alexandre Dumas|active",
                    "ADV012|Swiss Family Robinson|Johann David Wyss|active",
                    "ADV013|The Hobbit|J.R.R. Tolkien|active",
                    "ADV014|Percy Jackson and the Lightning Thief|Rick Riordan|active",
                    "ADV015|The Hunger Games|Suzanne Collins|active",
                    "ADV016|Eragon|Christopher Paolini|active",
                    "ADV017|Hatchet|Gary Paulsen|active",
                    "ADV018|Into the Wild|Jon Krakauer|active",
                    "ADV019|Life of Pi|Yann Martel|active",
                    "ADV020|Treasure Planet|Robert Louis Stevenson (inspired)|active",

                    "ETH001|Meditations|Marcus Aurelius|active",
                    "ETH002|Nicomachean Ethics|Aristotle|active",
                    "ETH003|Beyond Good and Evil|Friedrich Nietzsche|active",
                    "ETH004|The Republic|Plato|active",
                    "ETH005|Critique of Practical Reason|Immanuel Kant|active",
                    "ETH006|The Prince|Niccolò Machiavelli|active",
                    "ETH007|The Art of Happiness|Dalai Lama|active",
                    "ETH008|Man's Search for Meaning|Viktor E. Frankl|active",
                    "ETH009|The Analects|Confucius|active",
                    "ETH010|Letters from a Stoic|Seneca|active",
                    "ETH011|Walden|Henry David Thoreau|active",
                    "ETH012|The Moral Landscape|Sam Harris|active",
                    "ETH013|Justice|Michael J. Sandel|active",
                    "ETH014|Ethics|Baruch Spinoza|active",
                    "ETH015|Utilitarianism|John Stuart Mill|active",
                    "ETH016|Groundwork of the Metaphysics of Morals|Immanuel Kant|active",
                    "ETH017|Civil Disobedience|Henry David Thoreau|active",
                    "ETH018|The Conquest of Happiness|Bertrand Russell|active",
                    "ETH019|On Liberty|John Stuart Mill|active",
                    "ETH020|Tao Te Ching|Lao Tzu|active",

                    "SCI001|A Brief History of Time|Stephen Hawking|active",
                    "SCI002|The Selfish Gene|Richard Dawkins|active",
                    "SCI003|Cosmos|Carl Sagan|active",
                    "SCI004|The Origin of Species|Charles Darwin|active",
                    "SCI005|The Elegant Universe|Brian Greene|active",
                    "SCI006|Astrophysics for People in a Hurry|Neil deGrasse Tyson|active",
                    "SCI007|The Gene|Siddhartha Mukherjee|active",
                    "SCI008|Silent Spring|Rachel Carson|active",
                    "SCI009|The Double Helix|James D. Watson|active",
                    "SCI010|The Immortal Life of Henrietta Lacks|Rebecca Skloot|active",
                    "SCI011|Pale Blue Dot|Carl Sagan|active",
                    "SCI012|The Demon-Haunted World|Carl Sagan|active",
                    "SCI013|Surely You're Joking, Mr. Feynman!|Richard Feynman|active",
                    "SCI014|The Fabric of the Cosmos|Brian Greene|active",
                    "SCI015|Why We Sleep|Matthew Walker|active",
                    "SCI016|Brief Answers to the Big Questions|Stephen Hawking|active",
                    "SCI017|The Body|Bill Bryson|active",
                    "SCI018|Sapiens|Yuval Noah Harari|active",
                    "SCI019|The Hidden Life of Trees|Peter Wohlleben|active",
                    "SCI020|Thinking, Fast and Slow|Daniel Kahneman|active",

                    "MNG001|One Piece|Eiichiro Oda|active",
                    "MNG002|Naruto|Masashi Kishimoto|active",
                    "MNG003|Bleach|Tite Kubo|active",
                    "MNG004|Attack on Titan|Hajime Isayama|active",
                    "MNG005|Death Note|Tsugumi Ohba|active",
                    "MNG006|Dragon Ball|Akira Toriyama|active",
                    "MNG007|Demon Slayer|Koyoharu Gotouge|active",
                    "MNG008|Jujutsu Kaisen|Gege Akutami|active",
                    "MNG009|Blue Lock|Muneyuki Kaneshiro|active",
                    "MNG010|Chainsaw Man|Tatsuki Fujimoto|active",
                    "MNG011|Tokyo Ghoul|Sui Ishida|active",
                    "MNG012|Hunter x Hunter|Yoshihiro Togashi|active",
                    "MNG013|Berserk|Kentaro Miura|active",
                    "MNG014|Vinland Saga|Makoto Yukimura|active",
                    "MNG015|Fullmetal Alchemist|Hiromu Arakawa|active",
                    "MNG016|Haikyuu!!|Haruichi Furudate|active",
                    "MNG017|Black Clover|Yuki Tabata|active",
                    "MNG018|Spy x Family|Tatsuya Endo|active",
                    "MNG019|Solo Leveling|Chugong|active",
                    "MNG020|My Hero Academia|Kohei Horikoshi|active",

                    "HIS001|The Guns of August|Barbara W. Tuchman|active",
                    "HIS002|1776|David McCullough|active",
                    "HIS003|The Rise and Fall of the Third Reich|William L. Shirer|active",
                    "HIS004|Team of Rivals|Doris Kearns Goodwin|active",
                    "HIS005|The Wright Brothers|David McCullough|active",
                    "HIS006|Genghis Khan and the Making of the Modern World|Jack Weatherford|active",
                    "HIS007|The Silk Roads|Peter Frankopan|active",
                    "HIS008|SPQR|Mary Beard|active",
                    "HIS009|The Diary of a Young Girl|Anne Frank|active",
                    "HIS010|The Crusades|Thomas Asbridge|active",
                    "HIS011|The Cold War|John Lewis Gaddis|active",
                    "HIS012|The Romanovs|Simon Sebag Montefiore|active",
                    "HIS013|Postwar|Tony Judt|active",
                    "HIS014|Alexander Hamilton|Ron Chernow|active",
                    "HIS015|The History of the Ancient World|Susan Wise Bauer|active",
                    "HIS016|A People's History of the United States|Howard Zinn|active",
                    "HIS017|The Second World War|Antony Beevor|active",
                    "HIS018|The Vietnam War|Max Hastings|active",
                    "HIS019|The Lessons of History|Will & Ariel Durant|active",
                    "HIS020|The Story of Civilization|Will Durant|active"
                };

                File.WriteAllLines(Program.BookFilePath, books);

                Console.WriteLine("books.txt created successfully.");
            }
        }

        public static void AddProfile(string studentId, string username, string password)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Program.ProfilesFilePath));

            string dateTime = DateTime.Now.ToString("MM/dd/yyyy|hh:mmtt");

            File.AppendAllText(
                Program.ProfilesFilePath,
                studentId + " " + username + " " + password + " " + "active" + " " + "CreatedAt:" + dateTime + " " + "UpdatedAt:" + dateTime + Environment.NewLine
            );
        }

        public static int BorrowedQuantity(string id)
        {
            int count = 0;

            foreach (string line in File.ReadLines(Program.BookFilePath))
            {
                string[] parts = line.Split('|');
                if (parts[3] == id)
                    count++;
            }

            return count;
        }

        public static void ShowProfile()
        {
            Console.WriteLine();
            Console.WriteLine(" _________________");
            Console.WriteLine("|                 |");
            Console.WriteLine("| Active Profiles |");
            Console.WriteLine("|_________________|");
            Console.WriteLine(" -----------------");
            Console.WriteLine();
            int i = 0;
            foreach (string line in File.ReadLines(Program.ProfilesFilePath))
            {
                string[] parts = line.Split(' ');

                if (parts[3] == "active")
                {
                    Console.WriteLine("{0,-5} {1,5}", ++i + ".", "Student ID: " + parts[0]);
                    Console.WriteLine("{0,-5} {1,5}", "", "Username: " + parts[1]);
                    Console.WriteLine("{0,-5} {1,5}", "", "Created at: " + parts[4].Replace("CreatedAt:", ""));
                    Console.WriteLine("{0,-5} {1,5}", "", "Updated at: " + parts[5].Replace("UpdatedAt:", ""));
                    Console.WriteLine("{0,-5} {1,5}", "", "Books borrowed: " + BorrowedQuantity(parts[0]));
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        public static void ShowBooks()
        {
            Console.WriteLine();
            Console.WriteLine(" _________________");
            Console.WriteLine("|                 |");
            Console.WriteLine("| Available Books |");
            Console.WriteLine("|_________________|");
            Console.WriteLine(" -----------------");
            Console.WriteLine();
            int i = 0;
            bool hasBooks = false;
            foreach (string line in File.ReadLines(Program.BookFilePath))
            {
                string[] parts = line.Split('|');

                if (parts[3] == "active")
                {
                    Console.WriteLine("{0,-5} {1,5}", ++i + ".", "Name: " + parts[1]);
                    Console.WriteLine("{0,-5} {1,5}", "", "Author: " + parts[2]);
                    Console.WriteLine("{0,-5} {1,5}", "", "Book ID: " + parts[0]);
                    Console.WriteLine();
                    hasBooks = true;
                }
            }
            if (!hasBooks)
                Console.WriteLine("No books to borrow.");
            Console.WriteLine();
        }

        public static void BorrowBook(string id)
        {
            List<string> updatedLines = new List<string>();

            Console.WriteLine(" ______________");
            Console.WriteLine("|              |");
            Console.WriteLine("| Borrow Books |");
            Console.WriteLine("|______________|");
            Console.WriteLine(" --------------");
            Console.WriteLine();

            Console.Write("Enter Book ID: ");
            string bookId = Console.ReadLine();

            if (!IsBookIdTaken(bookId))
            {
                Console.WriteLine("Invalid Book ID.");
                return;
            }

            foreach (string line in File.ReadLines(Program.BookFilePath))
            {
                string[] parts = line.Split('|');

                if (parts[0] == bookId)
                {
                    if (parts[3] == "active")
                    {
                        parts[3] = id;
                        Console.WriteLine("Borrow Succesful!");
                        Log("ID: " + id + " borrowed Book ID: " + bookId + ".");
                    }
                    else
                        Console.WriteLine("Book is currently borrowed by someone.");
                }
                updatedLines.Add(string.Join('|', parts));
            }
            File.WriteAllLines(Program.BookFilePath, updatedLines);
            Checksum.UpdateBookSum();
            
        }

        public static void ShowBooks(string genre)
        {
            Console.WriteLine();
            Console.WriteLine(" _________________");
            Console.WriteLine("|                 |");
            Console.WriteLine("| Available Books |");
            Console.WriteLine("|_________________|");
            Console.WriteLine(" -----------------");
            Console.WriteLine();
            int i = 0;
            bool hasBooks = false;
            foreach (string line in File.ReadLines(Program.BookFilePath))
            {
                string[] parts = line.Split('|');

                if (parts[3] == "active")
                {
                    if (parts[0].Contains(genre))
                    {
                        Console.WriteLine("{0,-5} {1,5}", ++i + ".", "Name: " + parts[1]);
                        Console.WriteLine("{0,-5} {1,5}", "", "Author: " + parts[2]);
                        Console.WriteLine("{0,-5} {1,5}", "", "Book ID: " + parts[0]);
                        Console.WriteLine();
                        hasBooks = true;
                    }
                }
            }
            if(!hasBooks)
                Console.WriteLine("No books to borrow.");
            Console.WriteLine();
        }

        public static void ShowBorrow(string id)
        {
            List<string> updatedLines = new List<string>();

            Console.WriteLine();
            Console.WriteLine(" ________________");
            Console.WriteLine("|                |");
            Console.WriteLine("| Borrowed Books |");
            Console.WriteLine("|________________|");
            Console.WriteLine(" ----------------");
            Console.WriteLine();
            int i = 0;
            bool hasBorrowedBooks = false;
            foreach (string line in File.ReadLines(Program.BookFilePath))
            {
                string[] parts = line.Split('|');

                if (parts[3] == id)
                {
                    Console.WriteLine("{0,-5} {1,5}", ++i + ".", "Name: " + parts[1]);
                    Console.WriteLine("{0,-5} {1,5}", "", "Author: " + parts[2]);
                    Console.WriteLine("{0,-5} {1,5}", "", "Book ID: " + parts[0]);
                    Console.WriteLine();
                    hasBorrowedBooks = true;
                }
            }
            if (!hasBorrowedBooks)
            {
                Console.WriteLine("You do not have borrowed books");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Return Book");
            Console.Write("Enter Book ID: ");
            string bookId = Console.ReadLine();

            if (!IsBookIdTaken(bookId))
            {
                Console.WriteLine("Invalid Book ID.");
                return;
            }

            foreach (string line in File.ReadLines(Program.BookFilePath))
            {
                string[] parts = line.Split('|');

                if (parts[0] == bookId)
                {
                    if (parts[3] == id)
                    {
                        parts[3] = "active";
                        Console.WriteLine("Book return successful.");
                        Log("ID: " + id + " returned Book ID: " + bookId + ".");
                    }
                    else
                        Console.WriteLine("Book is currently not borrowed.");
                }
                updatedLines.Add(string.Join('|', parts));
            }
            File.WriteAllLines(Program.BookFilePath, updatedLines);
        }

        public static void RenameUsername(string id, string username)
        {
            List<string> updatedLines = new List<string>();
            string dateTime = DateTime.Now.ToString("MM/dd/yyyy|hh:mmtt");

            foreach (string line in File.ReadLines(Program.ProfilesFilePath))
            {
                string[] parts = line.Split(' ');

                if (parts[0] == id)
                {
                    parts[1] = username;
                    parts[5] = "UpdatedAt:" + dateTime;
                }

                updatedLines.Add(string.Join(' ', parts));
            }

            File.WriteAllLines(Program.ProfilesFilePath, updatedLines);
            Checksum.UpdateProfileSum();
        }

        public static bool HasBorrowed(string id)
        {
            foreach (string line in File.ReadLines(Program.BookFilePath))
            {
                string[] parts = line.Split("|");

                if (parts[3] == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static void DeactivateProfile(string id)
        {
            List<string> updatedLines = new List<string>();

            foreach (string line in File.ReadLines(Program.ProfilesFilePath))
            {
                string[] parts = line.Split(' ');

                if (parts[0] == id)
                {
                    parts[3] = "inactive";
                }

                updatedLines.Add(string.Join(' ', parts));
            }

            Console.WriteLine("\nAccount deactivation succesful.\nLog in to reactivate.");
            File.WriteAllLines(Program.ProfilesFilePath, updatedLines);
            Checksum.UpdateProfileSum();
        }

        public static string getProfileStatus(string id)
        {
            foreach (string line in File.ReadLines(Program.ProfilesFilePath))
            {
                string[] parts = line.Split(' ');

                if (parts[0] == id)
                {
                    return parts[3];

                }
            }
            return null;
        }

        public static void ReactivateProfile(string id)
        {
            List<string> updatedLines = new List<string>();

            foreach (string line in File.ReadLines(Program.ProfilesFilePath))
            {
                string[] parts = line.Split(" ");

                if (parts[0] == id)
                {
                    parts[3] = "active";
                }

                updatedLines.Add(string.Join(' ', parts));
            }

            Console.WriteLine("Account reactivation succesful.");
            File.WriteAllLines(Program.ProfilesFilePath, updatedLines);
            FileManager.Log("ID: " + id + " reactivated account.");
            Checksum.UpdateProfileSum();
        }


        public static void DeleteProfile(string id)
        {
            List<string> lines = File.ReadAllLines(Program.ProfilesFilePath).ToList();

            lines.RemoveAll(line =>
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return parts.Length > 0 && parts[0] == id;
            });

            File.WriteAllLines(Program.ProfilesFilePath, lines);
            Checksum.UpdateProfileSum();

            Console.WriteLine("\nAccount deletion successful.");
        }

        public static bool IsStudentIdTaken(string studentId)
        {
            if (!File.Exists(Program.ProfilesFilePath))
                return false;

            foreach (string line in File.ReadAllLines(Program.ProfilesFilePath))
            {
                string[] parts = line.Split(' ');

                if (parts[0] == studentId)
                    return true;
            }

            return false;
        }

        public static bool IsBookIdTaken(string bookId)
        {
            if (!File.Exists(Program.BookFilePath))
                return false;

            foreach (string line in File.ReadAllLines(Program.BookFilePath))
            {
                string[] parts = line.Split('|');

                if (parts[0] == bookId)
                    return true;
            }

            return false;
        }

        public static string FindIdPass(string studentId, string password)
        {
            if (!File.Exists(Program.ProfilesFilePath))
                return null;

            foreach (string line in File.ReadAllLines(Program.ProfilesFilePath))
            {
                string[] parts = line.Split(' ');

                if (parts[0] == studentId && parts[2] == password)
                {
                    return parts[1];
                }
            }

            return null;
        }

        public static void Log(string message)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Program.LogFilePath));

            File.AppendAllText(
                Program.LogFilePath, message + " | " + DateTime.Now + Environment.NewLine
            );
        }
    }
}
