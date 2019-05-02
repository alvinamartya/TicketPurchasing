using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPurchasing
{
    class Parameter
    {
        private string key;
        private string value;

        public string Key { get { return key; } set { key = value; } }
        public string Value { get { return value; } set { this.value = value; } }
    }
}
