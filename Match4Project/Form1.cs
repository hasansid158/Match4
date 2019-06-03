using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match4Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 503;
            this.Height = 525;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int posX = 0, posY = 0;

            for (int i = 0; i < 7; i++)
            {
                for (int x = 0; x < 7; x++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, posX, posY, 65, 65);
                    posX += 70;
                }
                posY += 70;
                posX = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
