using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canoe
{
    class BooleanFunction
    {
        private string[] token;

       
        public BooleanFunction(string[] v)
        {
            this.token = v;
        }
        
        public Queue<string> getRPN()
        {
            Stack<string> operatorStack = new Stack<string>();
            Queue<string> outputQueue = new Queue<string>();
            //Shunting Yard Algorithm Meat
            for (int i = 0; i < token.Length; i++)
            {
                if (isVariable(token[i]))
                {
                    outputQueue.Enqueue(token[i]);
                }
                else if (operatorPrecedence(token[i]) != -1)
                {
                    while (operatorStack.Count != 0 && operatorPrecedence(operatorStack.Peek()) >= operatorPrecedence(token[i]))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token[i]);
                }
                else if (token[i].Equals("("))
                {
                    operatorStack.Push(token[i]);
                }
                else if (token[i].Equals(")"))
                {
                    while (!operatorStack.Peek().Equals("("))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                }
            }
            while (operatorStack.Count != 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue;
        }  

        public Queue<string> inputVariable(char a, char b, char c, char d, Queue<string> inputQueue)
        {
            Queue<string> outputQueue = new Queue<string>();
            string temp = "";
            string temp1;
            foreach(string s in inputQueue)
            {
                temp += s + " ";
            }
            Console.WriteLine(temp);
            temp1 = temp.Replace('A', a).Replace('B', b).Replace('C', c).Replace('D', d);
            
            Console.WriteLine("Replaced " + temp1);
            string[] temp2 = temp1.Split(null);
            for (int i = 0; i < temp2.Length; i++)
            {
                outputQueue.Enqueue(temp2[i]);
            }
            return outputQueue;
        }

        public bool calculateRPN(Queue<string> inputQueue)
        {
            Stack<string> outputStack = new Stack<string>();

            while (inputQueue.Count != 1)
            {
                Console.WriteLine("STARTING LOOP with a count of " + inputQueue.Count);
                string s = inputQueue.Dequeue();
                if (isANumber(s))
                {
                                        
                    outputStack.Push(s);

                    Console.WriteLine("ITS A NUMBER!");
                    Console.WriteLine("OUTPUT STACK: ");
                    foreach(String a in outputStack){
                        Console.Write(a + " ");
                    }
                    Console.WriteLine("Count = " + outputStack.Count);
                }
                else
                {
                    if (outputStack.Count < 2)
                    {
                        Console.WriteLine("error: insufficient values");
                        Console.WriteLine("OUTPUT STACK: ");
                        foreach (String a in outputStack)
                        {
                            Console.Write(a + " ");
                        }
                        Console.WriteLine("Count = " + outputStack.Count);
                        Console.WriteLine(inputQueue.Count);
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("ITS A OPERATOR");
                        Console.WriteLine(s);
                        string value1, value2;
                        value1 = outputStack.Pop();
                        value2 = outputStack.Pop();
                        int result = 0;
                        if (s.Equals("+"))
                        {
                            result = addValues(Convert.ToInt32(value1), Convert.ToInt32(value2));
                        }
                        else if (s.Equals("*"))
                        {
                            result = multiplyValues(Convert.ToInt32(value1), Convert.ToInt32(value2));
                        }

                        string retVal = Convert.ToString(result);
                        outputStack.Push(retVal);

                        Console.WriteLine("OUTPUT STACK: ");
                        foreach (String a in outputStack)
                        {
                            Console.Write(a + " ");
                        }
                        Console.WriteLine("Count = " + outputStack.Count);
                        Console.WriteLine(inputQueue.Count);
                    }

                }

                Console.WriteLine("ENDING LOOP with a count of " + inputQueue.Count);
            }

            if (outputStack.Count == 1)
            {
                bool outcome = Convert.ToBoolean(Convert.ToInt32(outputStack.Pop()));
                Console.WriteLine("OUTCOME: " + outcome);
                return outcome;
            }
            else
            {
                Console.WriteLine("error in calculation");
                return false;
            }
        }

        public bool[] getTruthTable(Queue<string> inputQueue)
        {
            Queue<string> evalQueue = new Queue<string>();
            bool[] truthtable = new bool[16];
            for(int i = 0; i < 16; i++)
            {
                char a, b, c, d;
                a = (char)(BinaryHelper.getBit(i, 4) + '0');
                b = (char)(BinaryHelper.getBit(i, 3) + '0');
                c = (char)(BinaryHelper.getBit(i, 2) + '0');
                d = (char)(BinaryHelper.getBit(i, 1) + '0');

                evalQueue = inputVariable(a, b, c, d, inputQueue);
                truthtable[i] = calculateRPN(evalQueue);
            }
            return truthtable;
        }

       
        private int operatorPrecedence(string n)
        {
            int precedence = -1;
            char c = n[0];
            switch (c)
            {
                case '+':
                case '-':
                    precedence = 2;
                    break;
                case '*':
                case '/':
                    precedence = 3;
                    break;

                default:
                    precedence = -1;
                    break;
            }
            return precedence;
        }

        private bool isANumber(string n)
        {
            double retNum;
            bool isNumeric = double.TryParse(n, out retNum);
            return isNumeric;
        }

        private bool isVariable(string n)
        {
            if (n.Equals("A") || n.Equals("B") || n.Equals("C") || n.Equals("D") || n[0] == '!')
            {
                 return true;
            }
            
            return false;
        }

        private int addValues(int a, int b)
        {
            int sum = a + b;
            return sum;
        }

        private int multiplyValues(int a, int b)
        {
            int product = a * b;
            return product;
        }
    }
}
