using System;
using System.Collections.Generic;
using System.Linq;

namespace hammingCodeClient
{
    public class Manager
    {
        public String convertToString(bool[] arr)
        {
            return String.Join("", arr.Select(x => Convert.ToInt32(x)));
        }

        public bool[] convertToBool(String s)
        {
            return s.ToArray().Select(x => ((Convert.ToInt32(x) - 48) > 0)).ToArray();
        }

        public bool isnotpower(int x)
        {
            return !(x == 1 || x == 2 || x == 4 || x == 8);
        }

        public int[] getXorPosition(int length, int currentHammingPosition)
        {
            var positions = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                if ((i & currentHammingPosition) > 0 && isnotpower(i))
                    positions.Add(i);

            }
            return positions.ToArray();
        }

        public bool xor(bool[] vector, int length, int currentHammingPosition)
        {
            return getXorPosition(length, currentHammingPosition)
                .Select(x => vector[x - 1])
                .Aggregate((x, y) => x ^ y);
        }
    }
}
