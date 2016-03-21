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
        public const int FORM_SIZE = 500;
        public const int NUM_BUT = 4;
        TextBox tb0 = new TextBox();

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Control Generation

            int side = 50;
            //Labels
            for (int i = 0; i < NUM_BUT; ++i)
            {
                Label label = new Label();
                label.Text = Convert.ToString(i, 2).PadLeft(2, '0');
                int x = (FORM_SIZE / 2) - (side * 2) + (side *decToGray(i)) + 17;
                label.Location = new Point(x, 10);
                label.Visible = true;
                label.AutoSize = true;
                Controls.Add(label);
            }
            for (int i = 0; i < NUM_BUT; ++i)
            {
                Label label = new Label();
                label.Text = Convert.ToString(i, 2).PadLeft(2, '0');
                int y = (FORM_SIZE / 2) - (side * 2) + (side * decToGray(i)) - side * 2 + 18;
                label.Location = new Point(100, y);
                label.Visible = true;
                label.AutoSize = true;
                Controls.Add(label);
            }
            //K-Table
            for (int i = 0; i < NUM_BUT; ++i)
            {
                for (int j = 0; j < NUM_BUT; ++j)
                {
                    Button button = new Button();
                    button.Size = new Size(side, side);
                    int index = i * 4 + j;
                    button.Text = index.ToString();
                    button.Name = "button" + index;
                    int x, y;
                    x = (FORM_SIZE / 2) - (side * 2) + (side * decToGray(j));
                    y = (FORM_SIZE / 2) - (side * 2) + (side * decToGray(i)) - side*2;
                    button.Location = new Point(x, y);

                    button.BackColor = Color.Gainsboro;
                    this.Controls.Add(button);

                    button.Click += new EventHandler(Button_Toggle);

                }
            }
            
            //Input Buttons
            for (int i = 0; i < NUM_BUT; ++i)
            {
                Button button = new Button();
                button.Size = new Size(side, side);
                button.Text = ((char)('A' + i)).ToString();
                int x = (FORM_SIZE / 2) - (side * 2) + (side * i);
                button.Location = new Point(x, 300);
                this.Controls.Add(button);
            }
            for (int i = 0; i < 4; ++i)
            {
                Button button = new Button();
                button.Size = new Size(side, side);
                switch (i)
                    {
                    case 0:
                        button.Text = "+";
                        break;
                    case 1:
                        button.Text = "*";
                        break;
                    case 2:
                        button.Text = "!";
                        break;
                    case 3:
                        button.Text = "<--";
                        break;
                }
                
                int x = (FORM_SIZE / 2) - (side * 2) + (side * i);
                button.Location = new Point(x, 350);
                this.Controls.Add(button);
            }

            //Function label
            Label lblFunction = new Label();
            lblFunction.Text = "F(A,B,C,D) = ";
            lblFunction.Location = new Point(100, 400);
            lblFunction.AutoSize = true;
            lblFunction.Visible = true;
            this.Controls.Add(lblFunction);

            #endregion
        }
        
        void Button_Toggle(object sender, EventArgs e)
        {
            Button button = sender as Button;
            
            if (button.BackColor == Color.Gainsboro)
            {
                button.BackColor = SystemColors.Control;
            }
            else
            {
                button.BackColor = Color.Gainsboro;
            }
            
        }
        void Button_Update(object sender, EventArgs e)
        {

        }

        int decToGray(int num)
        {
            //Cheat
            switch (num)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 3;
                case 3:
                    return 2;
                default:
                    MessageBox.Show("Gray Code Error: Out of Range");
                    break;
            }
            return 0;
        }
        
    }
    //////Gameplan//////
    //--Create Function for Boolean Functions (eg: F(a,b,c,d) = abcd)
    //-Take string literals ie 'abcd' and convert to custom class equation
    //-Use equation to equate several details of Function class (eg Truth Table (1D Array), K Map (2D Array))
    //--Use functions to display Truth tables and K Maps of entered functions
    //--Using minterms and recursive algebra solve K Maps to determine function creating dual input systems.

}
