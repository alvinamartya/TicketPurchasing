using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TicketPurchasing
{
    class Support
    {
        public static string role = "";
        public static string name = "";
        public static Form frm;

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
                if(c is Panel)
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
                                if(!(cUserControl is ComboBox))
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

        #region Design Form
        #region Declaration
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        #endregion
        #region Events
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
        #endregion
        #endregion
    }
}
