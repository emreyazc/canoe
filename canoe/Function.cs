using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canoe
{
    class Function
    {
        private string literals;

        public Function(string literals)
        {
            this.literals = literals;
        }
        public void Compute()
        {

            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 2; b++)
                {
                    for (int c = 0; c < 2; c++)
                    {
                        for (int d = 0; d < 2; d++)
                        {

                        }
                    }
                }
            }
        }
        public void TruthTable()
        {

        }
        public void KMap()
        {

        }
        public string Literals
        {
            get { return literals; }
            set { literals = value; }
        }
    }
}
