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

        Button[] btns = new Button[16];
        bool[] bools = new bool[16];
        //Input Label
        Label lblFunction = new Label();
        Button butUpdate;
        TextBox tbFunction = new TextBox();
        
        string inputFunction;
        Queue<string> RPN = new Queue<string>();
        Queue<string> RPNwithvalues = new Queue<string>();

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

                    btns[index] = button;
                }
            }
            
            //Input Buttons
           
            butUpdate = new Button();
            butUpdate.Size = new Size(side, 2 * side);
            butUpdate.Text = "Update";            
            butUpdate.Location = new Point(450, 300);
            this.Controls.Add(butUpdate);
            butUpdate.Click += new EventHandler(Button_Update);

            
            //Function label
            lblFunction.Text = "F(A,B,C,D) = " + inputFunction;
            lblFunction.Location = new Point(100, 350);
            lblFunction.AutoSize = true;
            lblFunction.Visible = true;
            this.Controls.Add(lblFunction);

            tbFunction.Location = new Point(100, 375);
            this.Controls.Add(tbFunction);
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
            Button button = sender as Button;

            inputFunction = tbFunction.Text;
            string[] tokens = inputFunction.Split(null);
            lblFunction.Text = "F(A,B,C,D) = " + inputFunction;

            b = new BooleanFunction(tokens);
            RPN = b.getRPN();
            bools = b.getTruthTable(RPN);
            string output = "";
            foreach (string value in RPN)
            {
                output += value + " ";
            }            
            lblFunction.Text = "F(A,B,C,D) = " + output;
            int i = 0;
            foreach(bool value in bools)
            {
                Console.WriteLine(value + " " + Convert.ToString(i, 2).PadLeft(4, '0'));
                i++;
            }
            setButton();
        }

        void setButton()
        {
            for (int i = 0; i < 16; i++)
            {
                if (bools[i] == false)
                {
                    btns[i].BackColor = Color.Gainsboro;
                }
                else
                {
                    btns[i].BackColor = SystemColors.Control;
                }

            }
        }

               
    }
 }
