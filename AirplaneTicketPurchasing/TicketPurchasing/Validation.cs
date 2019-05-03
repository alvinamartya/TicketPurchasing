using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
    }
}
