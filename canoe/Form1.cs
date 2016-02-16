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
        public Form1()
        {
            InitializeComponent();
        }

        public const int LABEL_OFFSET = 30;
        public const int FORM_SIZE = 545;
        public const int NUM_BUT = 4;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Creates grid with NUM_BUT^2 number of buttons
            for (int i = 0; i < NUM_BUT; i++)
            {
                for (int j = 0; j < NUM_BUT; j++)
                {
                    Button btn = new Button();
                    int btnLength = (FORM_SIZE - LABEL_OFFSET * 2) / (NUM_BUT * 2);
                    btn.Size = new Size(btnLength, btnLength);
                    btn.Text = "0";
                    btn.Location = new Point(LABEL_OFFSET + j * btnLength, LABEL_OFFSET + i * btnLength);
                    this.Controls.Add(btn);
                    btn.Click += new EventHandler(Button_Toggle);
                } 
            }
            //Creates labels
            for (int i = 0; i < 4; i++)
            {
                Label lbl = new Label();
                int btnLength = (FORM_SIZE - LABEL_OFFSET * 2) / (NUM_BUT * 2);

            }
        }
        void Button_Toggle(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text == "0")
            {
                button.Text = "1";
            }
            else
            {
                button.Text = "0";
            }
            return;
        }
    }
}
