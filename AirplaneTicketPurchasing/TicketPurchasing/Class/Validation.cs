using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace TicketPurchasing
{
    class Validation
    {
        public bool regexAlphabetic(string input)
        {
            Regex regex = new Regex("^[A-Za-z ]+$");
            if (regex.IsMatch(input)) return true;
            return false;
        }

        public bool regexNumberic(string input)
        {
            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(input)) return true;
            return false;
        }

        public bool regexAlphaNumberic(string input)
        {
            Regex regex = new Regex("^[A-Za-z0-9 ]+$");
            if (regex.IsMatch(input)) return true;
            return false;
        }

        public bool regexAddress(string input)
        {
            Regex regex = new Regex("^[A-Za-z0-9./ ]+$");
            if (regex.IsMatch(input)) return true;
            return false;
        }

        public bool regexPassword(string input)
        {
            Regex regex = new Regex("^[A-Z]+[a-z]+[0-9]+$");
            Regex regex2 = new Regex("^[A-Z]+[0-9]+[a-z]+$");
            Regex regex3 = new Regex("^[a-z]+[0-9]+[a-z]+$");
            Regex regex4 = new Regex("^[a-z]+[A-Z]+[0-9]+$");
            Regex regex5 = new Regex("^[0-9]+[a-z]+[A-Z]+$");
            Regex regex6 = new Regex("^[0-9]+[A-Z]+[a-z]+$");
            if ((regex.IsMatch(input) || regex2.IsMatch(input) || regex3.IsMatch(input) ||
                regex4.IsMatch(input) || regex5.IsMatch(input) || regex6.IsMatch(input))) return true;
            return false;
        }

        public bool regexEmail(string input)
        {
            Regex regex = new Regex("^[A-Za-z0-9._ ]+[@][A-Za-z0-9._ ]+[.][A-Za-z0-9._ ]+$");
            if (regex.IsMatch(input)) return true;
            return false;
        }

        public bool validateImage(string path)
        {
            try
            {
                Image img = Image.FromFile(path);
                return true;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
