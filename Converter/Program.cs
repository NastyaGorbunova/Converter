using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Program
    {

        static void Main(string[] args)
        {
            //test pull request
            const byte ZeroAnscii = 48;
            const byte NineAnscii = 57;
            const byte AAnscii = 65;
            const byte FAnscii = 70;
            const byte aAnscii = 97;
            const byte fAnscii = 102;

            Console.Write("Enter the number in hexadecimal system:");
            string input = Console.ReadLine();

            //Валидация:
            byte[] AnsciiCode = Encoding.ASCII.GetBytes(input);
            foreach (byte symbol in AnsciiCode)
            {
                if ((symbol >= ZeroAnscii && symbol <= NineAnscii)
                    || (symbol >= AAnscii && symbol <= FAnscii)
                    || (symbol >= aAnscii && symbol <= fAnscii))
                    Console.ReadLine();
                else
                {
                    break;
                }
            }

            Methods Conversion = new Methods();
            int input_dec = Conversion.ConvertHexToDec(input);
            Console.WriteLine("Your number in decimal: " + input);
            Console.ReadLine();

            string input_bin = Conversion.ConvertDecToBinary(input);
            Console.WriteLine("Your number in binary: " + input);
            Console.ReadLine();

        }
    }

    class Methods
    {
        const byte AAnscii = 65; const byte aAnscii = 97;
        const byte BAnscii = 66; const byte bAnscii = 98;
        const byte CAnscii = 67; const byte cAnscii = 99;
        const byte DAnscii = 68; const byte dAnscii = 100;
        const byte EAnscii = 69; const byte eAnscii = 101;
        const byte FAnscii = 70; const byte fAnscii = 102;

        public int ConvertHexToDec(string input_hex)
        {
            char[] char_input = input_hex.ToCharArray();
            byte[] AnsciiInput = Encoding.ASCII.GetBytes(input_hex);

            for (int i = 0; i < input_hex.Length; i++)
            {
                if (AnsciiInput[i] == AAnscii)
                    char_input[i].Equals(10);
                if (AnsciiInput[i] == AAnscii)
                    char_input[i].Equals(11);
                if (AnsciiInput[i] == AAnscii)
                    char_input[i].Equals(12);
                if (AnsciiInput[i] == AAnscii)
                    char_input[i].Equals(13);
                if (AnsciiInput[i] == AAnscii)
                    char_input[i].Equals(14);
                if (AnsciiInput[i] == AAnscii)
                    char_input[i].Equals(15);
            }

            int output = input_hex[0];

            for (int i = 1; i < input_hex.Length; i++)
            {
                output = output + output * 16 + input_hex[i];
            }

            return output;
        }

        public string ConvertDecToBinary(string input_hex)
        {
            Methods ToBinary = new Methods();
            int input_dec = ToBinary.ConvertHexToDec(input_hex);
            int leftover = input_dec;
            int temp = 0;
            string Output = "";

            while (leftover > 0)
            {
                temp = leftover % 2;
                leftover = leftover / 2;
                Output = Output + temp;
            }
            /*
            char[] OutputChar = Output.ToArray();
            string OutputBinary = "";
            for (int i = Output.Length; i >= 0; i--)
            {
                OutputBinary = (OutputChar[i]);}
            }

            return OutputBinary;
        }*/
            return Output;
        }
    }
}