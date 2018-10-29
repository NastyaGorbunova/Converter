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
            const byte ZeroAnscii = 48;
            const byte NineAnscii = 57;
            const byte AAnscii = 65;
            const byte FAnscii = 70;
            const byte aAnscii = 97;
            const byte fAnscii = 102;
            
            bool isHex = false;
            string Hexinput = "";

            while (isHex == false)
            {
                Console.Write("Please enter the number in hexadecimal system:");
                Hexinput = Console.ReadLine();
                //Валидация:
                byte[] AnsciiCode = Encoding.ASCII.GetBytes(Hexinput);
                foreach (byte symbol in AnsciiCode)
                {
                    if ((symbol >= ZeroAnscii && symbol <= NineAnscii)
                        || (symbol >= AAnscii && symbol <= FAnscii)
                        || (symbol >= aAnscii && symbol <= fAnscii))
                        isHex = true;
                    else
                    {
                        isHex = false;
                        Console.Write("WRONG! Entered number is incorrect! ");
                        break;
                    }
                }
            }

            Methods Conversion = new Methods();
            int input_dec = Conversion.ConvertHexToDec(Hexinput);
            Console.WriteLine("Your number in decimal: " + input_dec);

            string input_bin = Conversion.ConvertDecToBinary(Hexinput);
            Console.WriteLine("Your number in binary: " + input_bin);
            Console.ReadLine();
        }
    }

    class Methods
    {
        const byte ZeroAnscii = 48; const byte NineAnscii = 57;
        const byte AAnscii = 65; const byte aAnscii = 97;
        const byte BAnscii = 66; const byte bAnscii = 98;
        const byte CAnscii = 67; const byte cAnscii = 99;
        const byte DAnscii = 68; const byte dAnscii = 100;
        const byte EAnscii = 69; const byte eAnscii = 101;
        const byte FAnscii = 70; const byte fAnscii = 102;

        public int ConvertHexToDec(string input_hex)
        {
            char[] char_input_hex = input_hex.ToCharArray();
            int[] int_input = new int[char_input_hex.Length];
            byte[] AnsciiInput = Encoding.ASCII.GetBytes(input_hex);

            for (int i = 0; i < input_hex.Length; i++)
            {
                if (AnsciiInput[i] >= ZeroAnscii && AnsciiInput[i] <= NineAnscii)
                    int_input[i] = char_input_hex[i];
                if (AnsciiInput[i] == AAnscii || AnsciiInput[i] == aAnscii)
                    int_input[i] = 10;
                if (AnsciiInput[i] == BAnscii || AnsciiInput[i] == bAnscii)
                    int_input[i] = 11;
                if (AnsciiInput[i] == CAnscii || AnsciiInput[i] == cAnscii)
                    int_input[i] = 12;
                if (AnsciiInput[i] == DAnscii || AnsciiInput[i] == dAnscii)
                    int_input[i] = 13;
                if (AnsciiInput[i] == EAnscii || AnsciiInput[i] == eAnscii)
                    int_input[i] = 14;
                if (AnsciiInput[i] == FAnscii || AnsciiInput[i] == fAnscii)
                    int_input[i] = 15;
            }

            Array.Reverse(int_input);
            
            int output = 0;
            
            for (int ii = 0; ii < int_input.Length; ii++)
            {
               output = (output + int_input[ii] * (16 ^ ii));
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
           
            char[] OutputChar = Output.ToArray();
            string OutputBinary = "";
            for (int i = Output.Length - 1; i >= 0; i--)
            {
                OutputBinary = OutputBinary + OutputChar[i].ToString();
            }

            return OutputBinary;
        }
    }
}