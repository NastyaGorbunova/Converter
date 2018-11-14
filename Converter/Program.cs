using System;
using System.Linq;
using System.Text;

namespace Converter
{
    class ConverterToDecAndBin
    {
        //The programm takes the number in Hex system and convert it in decimal and binary ones
        static void Main(string[] args)
        {
            ANSCII_Variables HexANSCII = new ANSCII_Variables();
            byte ZEROANSCII = HexANSCII.ANSCII_Zero();
            byte NineANSCII = HexANSCII.ANSCII_Nine();
            byte AANSCII = HexANSCII.ANSCII_A();
            byte FANSCII = HexANSCII.ANSCII_F();
                        
            bool isHex = false;
            string Hexinput = string.Empty;

            while (isHex == false)
            {
                Console.Write("Please enter the correct number in hexadecimal system: 0x");
                string Input = Console.ReadLine();
                Hexinput = Input.ToUpper();

                // Validate, if entered value is in Hex
                byte[] AnsciiCode = Encoding.ASCII.GetBytes(Hexinput);
                isHex = true;
                foreach (byte symbol in AnsciiCode)
                {
                    if ((symbol < ZEROANSCII || (symbol > NineANSCII && symbol < AANSCII) || symbol > FANSCII))
                        isHex = false;
                        break;
                }
            }

            ConversionMethods Conversion = new ConversionMethods();
            string input_dec = Conversion.ConvertHexToDec(Hexinput);
            Console.WriteLine("Your number in decimal: " + input_dec);

            string input_bin = Conversion.ConvertDecToBinary(Hexinput);
            Console.WriteLine("Your number in binary: " + input_bin);
            Console.ReadLine();
        }
    }

    class ConversionMethods
        //This class contains methods to convert Hex number to Dec and Dec to Bin
    {
        public string ConvertHexToDec(string input_hex)

            //Method to convert Hex number to Dec
        {
            ANSCII_Variables HexANSCII = new ANSCII_Variables();
            byte ZEROANSCII = HexANSCII.ANSCII_Zero();
            byte NineANSCII = HexANSCII.ANSCII_Nine();
            byte AANSCII = HexANSCII.ANSCII_A();
            byte BANSCII = HexANSCII.ANSCII_B();
            byte CANSCII = HexANSCII.ANSCII_C();
            byte DANSCII = HexANSCII.ANSCII_D();
            byte EANSCII = HexANSCII.ANSCII_E();
            byte FANSCII = HexANSCII.ANSCII_F();
            byte Difference = 7;

            byte[] AnsciiInput = Encoding.ASCII.GetBytes(input_hex);
            int[] int_input = new int [AnsciiInput.Length];

            //Transform letters in Hex into numbers in Dec
            for (int i = 0; i < int_input.Length; i++)
            {
                int_input[i] = AnsciiInput[i] - ZEROANSCII;
                if (int_input[i] > 15)
                {
                    int_input[i] = int_input[i] - Difference;
                }
            }
  
            Array.Reverse(int_input);
            int Intoutput = 0;
            int Multiplier = 16;
            double Multiple;

            for (int i = 0; i < int_input.Length; i++)
            {
                Multiple = Math.Pow (Multiplier, i);
                int MultipleInt = Convert.ToInt32(Multiple);
                Intoutput = (Intoutput + (int_input[i] * MultipleInt));
                Multiplier = 16;
            }

            string Output = Intoutput.ToString();
            return Output;
         }

        public string ConvertDecToBinary (string input_hex)
        //Method to convert Dec number to Bin
        {
            ConversionMethods DecToBinary = new ConversionMethods();
            string str_input_dec = DecToBinary.ConvertHexToDec(input_hex);
            int input_dec = Convert.ToInt32(str_input_dec);
            int leftover = input_dec;
            int temp = 0;
            string Output = string.Empty;

            while (leftover > 0)
            {
                temp = leftover % 2;
                leftover = leftover / 2;
                Output = Output + temp;
            }
           
            char[] OutputChar = Output.ToArray();
            string OutputBinary = string.Empty;
            for (int i = Output.Length - 1; i >= 0; i--)
            {
                OutputBinary = OutputBinary + OutputChar[i].ToString();
            }

            return OutputBinary;
        }
    }

    class ANSCII_Variables
    {
        public byte ANSCII_Zero()
        {
            const byte ZeroANSCII = 48;
            return ZeroANSCII;
        }
        public byte ANSCII_Nine()
        {
            const byte NineANSCII = 57;
            return NineANSCII;
        }
        public byte ANSCII_A()
        {
            const byte AANSCII = 65;
            return AANSCII;
        }
        public byte ANSCII_B()
        {
            const byte BANSCII = 66;
            return BANSCII;
        }
        public byte ANSCII_C()
        {
            const byte CANSCII = 67;
            return CANSCII;
        }
        public byte ANSCII_D()
        {
            const byte DANSCII = 68;
            return DANSCII;
        }
        public byte ANSCII_E()
        {
            const byte EANSCII = 69;
            return EANSCII;
        }
        public byte ANSCII_F()
        {
            const byte FANSCII = 70;
            return FANSCII;
        }        
    }
}