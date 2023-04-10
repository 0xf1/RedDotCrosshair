using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedDotCrosshair
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var path = new GraphicsPath();

            if (!System.IO.File.Exists("opt_width"))
            {
                System.IO.File.WriteAllText("opt_width.txt", "6");
            }
            this.Width = Convert.ToInt32(System.IO.File.ReadAllText("opt_width.txt"));

            if (!System.IO.File.Exists("opt_height"))
            {
                System.IO.File.WriteAllText("opt_height.txt", "6");
            }
            this.Height = Convert.ToInt32(System.IO.File.ReadAllText("opt_height.txt"));

            if (!System.IO.File.Exists("opt_top.txt"))
            {
                System.IO.File.WriteAllText("opt_top.txt", "537");
            }
            this.Top = Convert.ToInt32(System.IO.File.ReadAllText("opt_top.txt"));

            if (!System.IO.File.Exists("opt_left.txt"))
            {
                System.IO.File.WriteAllText("opt_left.txt", "960");
            }
            this.Left = Convert.ToInt32(System.IO.File.ReadAllText("opt_left.txt"));


            path.AddEllipse(0, 0, Width, Height);
            Region = new Region(path);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }
    }
}
