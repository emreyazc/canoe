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

        public const int LABEL_OFFSET = 50;
        public const int FORM_SIZE = 545;
        public const int NUM_BUT = 4;
        TextBox tb0 = new TextBox();

        private void Form1_Load(object sender, EventArgs e)
        {
            //Control Creation
            #region
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
            for (int k = 0; k < NUM_BUT; k++)
            {
                Label lbl = new Label();
                int btnLength = (FORM_SIZE - LABEL_OFFSET * 2) / (NUM_BUT * 2);
                lbl.Text = decToGray(k);
                lbl.Location = new Point(LABEL_OFFSET + (k * btnLength), 10);
                lbl.AutoSize = true;
                this.Controls.Add(lbl);
            }
            for (int k = 0; k < NUM_BUT; k++)
            {
                Label lbl = new Label();
                int btnLength = (FORM_SIZE - LABEL_OFFSET * 2) / (NUM_BUT * 2);
                lbl.Text = decToGray(k);
                lbl.Location = new Point(10, LABEL_OFFSET + (k * btnLength));
                lbl.AutoSize = true;
                this.Controls.Add(lbl);
            }
            //Creates Variable Label
            Label lbl0 = new Label();
            lbl0.Text = "AB\\CD";
            lbl0.Location = new Point(0, 20);
            lbl0.AutoSize = true;
            this.Controls.Add(lbl0);
            //Creates Function Label
            Label lbl1 = new Label();
            lbl1.Text = "F (A,B,C,D) = ";
            lbl1.Location = new Point(10, 300);
            lbl1.AutoSize = true;
            this.Controls.Add(lbl1);
            tb0.Location = new Point(100, 300);
            this.Controls.Add(tb0);
            Button btn0 = new Button();
            btn0.Location = new Point(30, 330);
            btn0.Size = new Size(250, 50);
            btn0.Text = "Update";
            this.Controls.Add(btn0);
            btn0.Click += new EventHandler(Button_Update);
            #endregion
        }

        void Button_Toggle(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text == "0")
            {
                button.Text = "1";
                button.BackColor = SystemColors.Control;
            }
            else
            {
                button.Text = "0";
                button.BackColor = Color.Gainsboro;
            }
            return;
        }
        void Button_Update(object sender, EventArgs e)
        {
            string fn = tb0.Text;

        }

        string decToGray(int num)
        {
            //Cheat
            switch (num)
            {
                case 0:
                    return "00";
                case 1:
                    return "01";
                case 2:
                    return "11";
                case 3:
                    return "10";
                default:
                    MessageBox.Show("Gray Code Error: Out of Range");
                    break;
            }
            return "00";
        }
        
    }
    //////Gameplan//////
    //--Create Function for Boolean Functions (eg: F(a,b,c,d) = abcd)
    //-Take string literals ie 'abcd' and convert to custom class equation
    //-Use equation to equate several details of Function class (eg Truth Table (1D Array), K Map (2D Array))
    //--Use functions to display Truth tables and K Maps of entered functions
    //--Using minterms and recursive algebra solve K Maps to determine function creating dual input systems.

}
