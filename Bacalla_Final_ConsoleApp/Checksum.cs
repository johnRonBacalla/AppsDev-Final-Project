using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;

namespace Bacalla_Final_ConsoleApp
{
    internal class Checksum
    {
        public static string getCurrentSum(string path)
        {
            string[] lines = File.ReadAllLines(path);
            string AllContent = string.Join(Environment.NewLine, lines);

            byte[] inputBytes = Encoding.UTF8.GetBytes(AllContent);

            byte[] hashBytes = SHA256.HashData(inputBytes);

            return Convert.ToHexString(hashBytes);
        }

        public static void UpdateProfileSum()
        {
            string[] lines = File.ReadAllLines(Program.ChecksumFilePath);
            List<string> updatedLines = new List<string>();

            lines[1] = getCurrentSum(Program.ProfilesFilePath);

            foreach (string line in lines)
            {
                updatedLines.Add(line);
            }
            File.WriteAllLines(Program.ChecksumFilePath, updatedLines);
            Program.ProfilesCheckSum = getCurrentSum(Program.ProfilesFilePath);
        }
        public static void UpdateBookSum()
        {
            string[] lines = File.ReadAllLines(Program.ChecksumFilePath);
            List<string> updatedLines = new List<string>();

            lines[0] = getCurrentSum(Program.BookFilePath);

            foreach (string line in lines)
            {
                updatedLines.Add(line);
            }
            File.WriteAllLines(Program.ChecksumFilePath, updatedLines);
            Program.BooksCheckSum = getCurrentSum(Program.BookFilePath);
        }
    }
}
