using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Drawing2D;

namespace TicketPurchasing
{
    class Support
    {
        // general variables
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
        // method for design panel
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

        // drag and drop all controls in form
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
                if (c is Panel || c is UserControl)
                {
                    foreach (Control cPanel in c.Controls)
                    {
                        if(cPanel is Panel || cPanel is FlowLayoutPanel)
                        {
                            cPanel.MouseDown += (s2, e2) => ctrl_MouseDown(s2, e2, form);
                            cPanel.MouseMove += (s2, e2) => ctrl_MouseMove(s2, e2, form);
                            cPanel.MouseUp += ctrl_MouseUp;
                        }
                    }
                }
            }
        }

        // convert image to byte array
        public byte[] imgToByteArray(Image img)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }

        // convert from byte array to image
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        #endregion
        #endregion
    }
}
