/*
 *  Programmer: Hunter Johnson
 *  Info: Demonstrates graphics object and making a "mouse brush"
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseBrush
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics gfx; // graphics object
        Random rd = new Random();
        Pen p = new Pen(Color.Black); // pen object
        int x, y;

        private void MainForm_Load(object sender, EventArgs e)
        {
            gfx = this.CreateGraphics(); // create graphics
            MinimizeBox = false;
            MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void MainForm_Close(object sender, EventArgs e)
        {
            gfx.Dispose(); // dispose of the graphics
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rectEllipse = new Rectangle();
            if (e.Button != MouseButtons.Left)
                return;
            x = e.X - 1;
            y = e.Y - 1;
            rectEllipse.X = e.X - 1;
            rectEllipse.Y = e.Y - 1;
            rectEllipse.Width = 7;
            rectEllipse.Height = 7;
            gfx.DrawEllipse(p, rectEllipse);
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            p.Color = Color.Purple;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            p.Color = Color.Blue;
        }

        private void btnTurquoise_Click(object sender, EventArgs e)
        {
            p.Color = Color.Turquoise;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            p.Color = Color.Green;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            p.Color = Color.Yellow;
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            p.Color = Color.Orange;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Generates Random Color on Right-Click
            if (e.Button == MouseButtons.Right)
                gfx.Clear(Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255)));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // set the selected color to the RTB's forecolor
                p.Color = colorDialog1.Color;
            }
        }

        private void btnAquaMarine_Click(object sender, EventArgs e)
        {
            p.Color = Color.Aquamarine;
        }

        private void btnPeru_Click(object sender, EventArgs e)
        {
            p.Color = Color.Peru;
        }

        private void btnTeal_Click(object sender, EventArgs e)
        {
            p.Color = Color.Teal;
        }

        private void btnNavy_Click(object sender, EventArgs e)
        {
            p.Color = Color.Navy;
        }

        private void btnLightCoral_Click(object sender, EventArgs e)
        {
            p.Color = Color.LightCoral;
        }

        private void btnKhaki_Click(object sender, EventArgs e)
        {
            p.Color = Color.Khaki;
        }

        private void btnOrangeRed_Click(object sender, EventArgs e)
        {
            p.Color = Color.OrangeRed;
        }

        private void btnMaroon_Click(object sender, EventArgs e)
        {
            p.Color = Color.Maroon;
        }
    }
}
