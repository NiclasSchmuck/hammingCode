using System;
using System.Collections.Generic;
using System.Linq;

namespace hammingCodeClient
{

    //Matrik. Nr: 5824990

    class HammingClient
    {
        public const bool t = true;
        public const bool f = false;
        public const int startWith = 2;
        static int length;

        static void Main(string[] args)
        {

            //Code aus der Aufgabe: 0110001
            Manager mngr = new Manager();
            HammingClient client = new HammingClient();
            length = 11;
            Console.WriteLine("Please enter a bitstring:");
            String inputCode = Console.ReadLine();
            if(inputCode.Contains("2") || inputCode.Contains("3") || inputCode.Contains("4") || inputCode.Contains("5") || inputCode.Contains("6") || inputCode.Contains("7") || inputCode.Contains("8") || inputCode.Contains("9"))
            {
                Console.WriteLine("Please only use 0 and 1");
                Console.ReadLine();
                return;
            }
            if(inputCode.Length != 7)
            {
                Console.WriteLine("The given String does not have the length of 7 chars.");
                Console.ReadLine();
                return;
            }
            string codeString = inputCode;

            var code = mngr.convertToBool(codeString);
            var byteArrayEncoded = client.encode(code);

            Console.WriteLine(mngr.convertToString(byteArrayEncoded));

            Console.WriteLine();

            Console.ReadLine();
        }

        private bool[] encode(bool[] boolArrayOriginal)
        {
            Manager mngr = new Manager();
            var byteArrayEncoded = new bool[length];

            int i = startWith, j = 0;
            while (i < length)
            {
                if (i == 3 || i == 7) i++;
                byteArrayEncoded[i] = boolArrayOriginal[j];

                i++;
                j++;
            }

            byteArrayEncoded[0] = mngr.xor(byteArrayEncoded, length, 1);
            byteArrayEncoded[1] = mngr.xor(byteArrayEncoded, length, 2);
            byteArrayEncoded[3] = mngr.xor(byteArrayEncoded, length, 4);
            if (length > 7)
                byteArrayEncoded[7] = mngr.xor(byteArrayEncoded, length, 8);

            return byteArrayEncoded;
        }

        private bool[] Decode(bool[] byteArrayEncoded)
        {
            var decoded = new bool[11];

            int i = startWith, j = 0;
            while (i < length)
            {
                if (i == 3 || i == 7) i++;
                decoded[j] = byteArrayEncoded[i];

                i++;
                j++;
            }

            return decoded;
        }
    }
}
