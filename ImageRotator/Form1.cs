using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRotator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            //foreach(var file in Directory.GetFiles(@"C:\Users\Admin\Desktop\code\ImageStuff\Normal2"))
            Parallel.ForEach<string>(Directory.GetFiles(@"C:\Users\Admin\Desktop\code\ImageStuff\Normal2"), (file) =>
            {
                Image img = Image.FromFile(file);
                img.RotateFlip(RotateFlipType.Rotate180FlipX);
                FileInfo fileInfo = new FileInfo(file);
                img.Save(@"C:\Users\Admin\Desktop\code\ImageStuff\Rotated\" + fileInfo.Name);
                MessageBox.Show($"Done in {sw.ElapsedMilliseconds}ms");

            });
        }
    }
}
