using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadStuffButGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawRedStuff(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Random rnd = new Random();
            Task t = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    for(int j=0; j < 10; j++)
                    {
                        Pen p = new Pen(Color.FromArgb(rnd.Next()));
                        int x = i * 30;
                        int y = j * 30;
                        g.DrawRectangle(p, x, y, 20, 20);
                        Thread.Sleep(500);

                    }
                }
            });
        }
        private void DrawBlueStuff(object sender, EventArgs e)
        {
            //Red rectangles
            Graphics g = panel2.CreateGraphics();
            Random rnd = new Random();
            Task t = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    int x = rnd.Next(panel2.Width - 20);
                    int y = rnd.Next(panel2.Height - 20);
                    g.DrawRectangle(Pens.Blue, x, y, 20, 20);
                    Thread.Sleep(500);
                }
            });
        }
    }
}
