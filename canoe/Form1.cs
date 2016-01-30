using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canoe
{
    public partial class Form1 : Form
    {
        private static int size = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tbSize_TextChanged(object sender, EventArgs e)
        {
            string t = tbSize.Text;
            size = Int32.Parse(t);


            Label lbl = new Label();
            lbl.Text = size.ToString();
            lbl.Location = new Point(100, 100);
            this.Controls.Add(lbl);

        }

        private void tbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Use this function to track changes to textbox on key presses.
        }
    }
}
