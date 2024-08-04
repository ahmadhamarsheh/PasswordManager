using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordManagerProject.PasswordManager
{
    internal class EncryptionUtility
    {
        private static readonly string orginalChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*()_+-=[]{}|;:',.<>/~";
        private static readonly string usernameChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890@_.";
        private static readonly string altChar = "KOd9/RyCI}tj*|;s$,kqH'LS%UmJDEx5FW=#2Z)gX<&P!B~b+0h@:{4Qp>i.(^wMcu6v]8Aa-V1Nz7eYrTon3[f_Gl";


        public static string Encrypt(string password)
        {
            if (password != null)
            {
                var sb = new StringBuilder();
                foreach(char c in password) 
                {
                    var originalIndex = orginalChar.IndexOf(c);
                    sb.Append(altChar[originalIndex]); 
                }
                return sb.ToString();
            }
            return "There is no password!";
        }
        public static string Decrypt(string password)
        {
            if (password != null)
            {
                var sb = new StringBuilder();
                foreach (char c in password)
                {
                    var altIndex = altChar.IndexOf(c);
                    sb.Append(orginalChar[altIndex]);
                }
                return sb.ToString();
            }
            return "There is no password!";
        }
        public static bool IsPasswordValid(string password)
        {
            foreach (char c in password)
            {
                if (!orginalChar.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsUsernameValid(string username)
        {
            foreach (char c in username)
            {
                if (!usernameChar.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
