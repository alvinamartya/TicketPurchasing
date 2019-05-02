using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace TicketPurchasing
{
    class Support
    {
        // general variables
        public static string role = "";
        public static string name = "";
        public static Form frm;
        #region Design Form
        #region Declaration
        // variable for drag and drop application
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // variable for change color when position mouse in up of panel
        private Color light = Color.FromArgb(46, 47, 48);
        private Color dark = Color.FromArgb(36, 37, 38);
        Thread Enter;
        Thread Leave;
        #endregion
        #region Events
        // event for drag and drop application
        private void ctrl_MouseDown(object sender, MouseEventArgs e,Control form)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = form.Location;
        }

        private void ctrl_MouseMove(object sender, MouseEventArgs e, Control form)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                form.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        //event for change color when position mouse in up of panel
        private void PanelMouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            Enter = new Thread(() => changeColor(p, dark));
            Enter.Start();
        }

        private void PanelMouseLeave(object sender, EventArgs e)
        {
            if (Enter != null)
                Enter.Abort();
            Panel p = (Panel)sender;
            Leave = new Thread(() => changeColor(p, light));
            Leave.Start();
        }
        private void changeColor(Panel panel, Color color)
        {
            panel.BackColor = color;
        }

        private void PictBoxMouseEnter(object sender, EventArgs e)
        {
            if (Leave != null)
                Leave.Abort();
            var obj = (PictureBox)sender;
            PanelMouseEnter(obj.Parent, e);
        }

        private void LableMouseEnter(object sender, EventArgs e)
        {
            if (Leave != null)
                Leave.Abort();
            var obj = (Label)sender;
            PanelMouseEnter(obj.Parent, e);
        }
        #endregion
        #region Method
        public void panelMouse(Panel panel)
        {
            panel.MouseEnter += PanelMouseEnter;
            panel.MouseLeave += PanelMouseLeave;
            foreach(Control c in panel.Controls)
            {
                if (c is Label) c.MouseEnter += LableMouseEnter;
                if (c is PictureBox) c.MouseEnter += PictBoxMouseEnter;
            }
        }

        public void DragandDropForm(Control form)
        {
            form.MouseDown += (s2, e2) => ctrl_MouseDown(s2, e2, form);
            form.MouseMove += (s2, e2) => ctrl_MouseMove(s2, e2, form);
            form.MouseUp += ctrl_MouseUp;

            foreach (Control c in form.Controls)
            {
                c.MouseDown += (s2, e2) => ctrl_MouseDown(s2, e2, form);
                c.MouseMove += (s2, e2) => ctrl_MouseMove(s2, e2, form);
                c.MouseUp += ctrl_MouseUp;
                if (c is Panel)
                {
                    foreach (Control cPanel in c.Controls)
                    {
                        cPanel.MouseDown += (s2, e2) => ctrl_MouseDown(s2, e2, form);
                        cPanel.MouseMove += (s2, e2) => ctrl_MouseMove(s2, e2, form);
                        cPanel.MouseUp += ctrl_MouseUp;

                        if (cPanel is UserControl)
                        {
                            foreach (Control cUserControl in cPanel.Controls)
                            {
                                if (!(cUserControl is ComboBox))
                                {
                                    cUserControl.MouseDown += (s2, e2) => ctrl_MouseDown(s2, e2, form);
                                    cUserControl.MouseMove += (s2, e2) => ctrl_MouseMove(s2, e2, form);
                                    cUserControl.MouseUp += ctrl_MouseUp;

                                    if (cUserControl is Panel)
                                    {
                                        foreach (Control cPanel2 in cUserControl.Controls)
                                        {
                                            cPanel2.MouseDown += (s2, e2) => ctrl_MouseDown(s2, e2, form);
                                            cPanel2.MouseMove += (s2, e2) => ctrl_MouseMove(s2, e2, form);
                                            cPanel2.MouseUp += ctrl_MouseUp;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion
        #endregion
    }
}
