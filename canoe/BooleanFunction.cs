using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canoe
{
    class BooleanFunction
    {
        private string functionString;
        private List<char> functionList;

        public BooleanFunction(string s)
        {
            this.functionString = s;
        }

        public BooleanFunction(List<char> v)
        {
            this.functionList = v;
        }

        public bool checkSubFunctions()
        {
            if (functionString.Contains('('))
            {
                return true;
            }
            return false;
        }

      
    }
}
