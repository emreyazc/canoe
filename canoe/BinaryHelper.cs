using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canoe
{
    class BinaryHelper
    {
        public static int decToGray(int num)
        {
            //Simple switch to be Gray Code friendly
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
                    throw new Exception("Graycode out of bounds");
            }
        }

        public static bool GetBit(int num, int bitPosition)
        {
            bool bit = (num & (1 << bitPosition - 1)) != 0;
            return bit;
        }
    }
}
