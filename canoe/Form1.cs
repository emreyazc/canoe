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
        
        //Input Label
        Label lblFunction = new Label();
        Button butUpdate;

        string inputFunction = "";

        BooleanFunction b;

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Control Generation

            int side = 50;
            //Labels
            for (int i = 0; i < NUM_BUT; ++i)
            {
                Label label = new Label();
                label.Text = Convert.ToString(i, 2).PadLeft(2, '0');
                int x = (FORM_SIZE / 2) - (side * 2) + (side * BinaryHelper.decToGray(i)) + 17;
                label.Location = new Point(x, 10);
                label.Visible = true;
                label.AutoSize = true;
                Controls.Add(label);
            }
            for (int i = 0; i < NUM_BUT; ++i)
            {
                Label label = new Label();
                label.Text = Convert.ToString(i, 2).PadLeft(2, '0');
                int y = (FORM_SIZE / 2) - (side * 2) + (side * BinaryHelper.decToGray(i)) - side * 2 + 18;
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
                    button.Name = "btn" + index;
                    int x, y;
                    x = (FORM_SIZE / 2) - (side * 2) + (side * BinaryHelper.decToGray(j));
                    y = (FORM_SIZE / 2) - (side * 2) + (side * BinaryHelper.decToGray(i)) - side*2;
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

                button.Click += new EventHandler(Button_Input);

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
                        button.Text = "!";
                        break;
                    case 2:
                        button.Text = "(";
                        break;
                    case 3:
                        button.Text = ")";
                        break;
                }
                
                int x = (FORM_SIZE / 2) - (side * 2) + (side * i);
                button.Location = new Point(x, 350);
                this.Controls.Add(button);

                button.Click += new EventHandler(Button_Input);
            }

            for (int i = 0; i < 2; ++i)
            {
                Button button = new Button();
                button.Size = new Size(side, side);
                switch (i)
                {
                    case 0:
                        button.Text = "<--";
                        button.Click += new EventHandler(Button_Remove);
                        break;
                    case 1:
                        button.Text = "clear";
                        button.Click += new EventHandler(Button_Clear);
                        break;
                }

                int y = (FORM_SIZE / 2) + (side * 1) + (side * i);
                button.Location = new Point(400, y);
                this.Controls.Add(button);
                
            }

            butUpdate = new Button();
            butUpdate.Size = new Size(side, 2 * side);
            butUpdate.Text = "Update";            
            butUpdate.Location = new Point(450, 300);
            this.Controls.Add(butUpdate);
            butUpdate.Click += new EventHandler(Button_Update);

            //Function label
            lblFunction.Text = "F(A,B,C,D) = " + inputFunction;
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

        void Button_Input(object sender, EventArgs e)
        {
            Button button = sender as Button;

            inputFunction += button.Text;
            lblFunction.Text = "F(A,B,C,D) = " + inputFunction;

            if (button.Text == "!" || button.Text == "+" || button.Text == "(")
            {
                butUpdate.Enabled = false;                
            }
            else
            {
                butUpdate.Enabled = true;
            }

        }

        void Button_Remove(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (inputFunction.Length != 0)
                inputFunction = inputFunction.Remove(inputFunction.Length - 1);
            lblFunction.Text = "F(A,B,C,D) = " + inputFunction;

        }

        void Button_Clear(object sender, EventArgs e)
        {
            Button button = sender as Button;

            inputFunction = "";
            lblFunction.Text = "F(A,B,C,D) = " + inputFunction;

            butUpdate.Enabled = true;
        }      

        void Button_Update(object sender, EventArgs e)
        {
            Button button = sender as Button;

            b = new BooleanFunction(inputFunction);
            if (b.checkSubFunctions()) MessageBox.Show("Subfunctions Exists");
        }
        
    }
    //////Gameplan//////
    //--Create Function for Boolean Functions (eg: F(a,b,c,d) = abcd)
    //-Take string literals ie 'abcd' and convert to custom class equation
    //-Use equation to equate several details of Function class (eg Truth Table (1D Array), K Map (2D Array))
    //--Use functions to display Truth tables and K Maps of entered functions
    //--Using minterms and recursive algebra solve K Maps to determine function creating dual input systems.

}
