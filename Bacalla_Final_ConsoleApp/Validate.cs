using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bacalla_Final_ConsoleApp
{
    internal class Validate
    {
        public bool PasswordInput(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            // length check
            if (password.Length < 8 || password.Length > 64)
                return false;

            // must contain at least 1 uppercase
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // must contain at least 1 lowercase
            if (!Regex.IsMatch(password, "[a-z]"))
                return false;

            // must contain at least 1 number
            if (!Regex.IsMatch(password, "[0-9]"))
                return false;

            // must not contain spaces
            if (password.Contains(" "))
                return false;

            // must contain at least 1 special character
            if (!Regex.IsMatch(password, "[^a-zA-Z0-9]"))
                return false;

            return true;
        }

        public bool IdInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (input.Contains(" "))
                return false;

            return input.All(char.IsDigit);
        }

        public bool UsernameInput(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            if (username.Length > 40)
                return false;

            if (username.Contains(" "))
                return false;

            return true;
        }
    }
}
