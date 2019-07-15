using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketPurchasing
{
    public partial class MessageFrm : Form
    {
        public MessageFrm()
        {
            InitializeComponent();
        }

        public MessageFrm(string help)
        {
            InitializeComponent();
            lblHelp.Text = help;
        }
    }
}
