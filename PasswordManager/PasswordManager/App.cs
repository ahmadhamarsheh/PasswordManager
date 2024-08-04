using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordManagerProject.PasswordManager
{
    public static class App
    {
        private static readonly Dictionary<string, string> _passwordEntries = new Dictionary<string, string>();
        public static void Run(string[] args)
        {
            ReadPasswords();
            Console.WriteLine("\t\t===== Welcome to Password Manager Application =====\n\n\n");
            while (true)
            {
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("1. Lisa all passwords");
                Console.WriteLine("2. Add/Change password");
                Console.WriteLine("3. Get password");
                Console.WriteLine("4. Delete password");
                Console.WriteLine("5. Exit");

                Console.Write("\nYour option is: ");
                var selectOption = Console.ReadLine();
                if (selectOption == "1") { ListAllPasswords(); }
                else if (selectOption == "2") { AddorChangePassword(); }
                else if (selectOption == "3") { GetPassword(); }
                else if (selectOption == "4") { DeletePassword(); }
                else if (selectOption == "5") { Console.WriteLine("See you soon (:"); return; }
                else { Console.WriteLine("Invalid option"); }

                Console.WriteLine("\n\n*********************************************************************");
            }
        }

        private static void ReadPasswords()
        {
            if (File.Exists("passwords.txt")) 
            { 
                var passwordLines = File.ReadAllText("passwords.txt");
                foreach (var line in passwordLines.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var equalIndex = line.IndexOf('=');
                        var appName = line.Substring(0, equalIndex);
                        var password = line.Substring(equalIndex + 1);
                        _passwordEntries.Add(appName, EncryptionUtility.Decrypt(password));
                    }
                }
            }
        }
        private static void SavePasswords()
        {
            var sb = new StringBuilder();
            foreach(var entry in _passwordEntries) { sb.AppendLine($"{entry.Key}={EncryptionUtility.Encrypt(entry.Value)}"); }
            File.WriteAllText("passwords.txt", sb.ToString());
        }

        private static void DeletePassword()
        {
            Console.WriteLine("Please enter website/app name:");
            var appName = Console.ReadLine();
            if(_passwordEntries.ContainsKey(appName)) { _passwordEntries.Remove(appName); SavePasswords(); }
            else { Console.WriteLine("Password not found!"); }
        }

        private static void GetPassword()
        {
            Console.WriteLine("Please enter website/app name:");
            var appName = Console.ReadLine();
            if(_passwordEntries.ContainsKey(appName.ToLower())) { Console.WriteLine($"Your password is: {_passwordEntries[appName]}"); }
            else { Console.WriteLine("Password not found!"); }
        }

        private static void AddorChangePassword()
        {
        user:
            Console.WriteLine("Please enter website/app name:");
            var appName = Console.ReadLine();
            if (appName == null || !EncryptionUtility.IsUsernameValid(appName))
            {
                Console.WriteLine("Invalid name, Please enter valid password\n"); goto user;
            }
        pass:
            Console.WriteLine("Please enter your password:");
            var password = Console.ReadLine();
            if (password != null && EncryptionUtility.IsPasswordValid(password))
            {
                if (_passwordEntries.ContainsKey(appName.ToLower())) { _passwordEntries[appName] = password; }
                else { _passwordEntries.Add(appName.ToLower(), password); }
                SavePasswords();
            }
            else
            {
                Console.WriteLine("Invalid password, Please enter valid password\n"); goto pass;
            }
        }

        private static void ListAllPasswords()
        {
            if( _passwordEntries.Count > 0 ) { Console.WriteLine("All Your Websites/Apps Password:\n"); }
            foreach(var entry in _passwordEntries)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine($"{entry.Key} = {entry.Value}");
            }
            Console.WriteLine("===================================================");
        }

        
    }
}

