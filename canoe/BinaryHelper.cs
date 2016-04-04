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

        public static int getBit(int num, int bitPosition)
        {
            int bit = (num & (1 << bitPosition - 1));
            return bit;
        }
    }
}
