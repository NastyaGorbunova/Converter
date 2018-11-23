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
            AnsciiVariables HexANSCII = new AnsciiVariables();
            byte zeroANSCII = HexANSCII.AnsciiZero();
            byte nineANSCII = HexANSCII.AnsciiNine();
            byte aANSCII = HexANSCII.AnsciiLetterA();
            byte fANSCII = HexANSCII.AnsciiLetterF();
                        
            bool isHex = false;
            string hexInput = string.Empty;

            while (isHex == false)
            {
                Console.Write("Please enter the correct number in hexadecimal system: 0x");

                string input = Console.ReadLine();
                hexInput = input.ToUpper();

                // Validate, if entered value is in Hex
                byte[] ANSCIICode = Encoding.ASCII.GetBytes(hexInput);
                isHex = true;

                foreach (byte symbol in ANSCIICode)
                {
                    if ((symbol < zeroANSCII || (symbol > nineANSCII && symbol < aANSCII) || symbol > fANSCII))
                        isHex = false;
                        break;
                }
            }

            ConversionMethods Conversion = new ConversionMethods();
            string inputDec = Conversion.ConvertHexToDec(hexInput);
            Console.WriteLine("Your number in decimal: " + inputDec);

            string inputBin = Conversion.ConvertDecToBinary(hexInput);
            Console.WriteLine("Your number in binary: " + inputBin);
            Console.ReadLine();
        }
    }

    class ConversionMethods
        //This class contains methods to convert Hex number to Dec and Dec to Bin
    {
        public string ConvertHexToDec(string input_hex)

            //Method to convert Hex number to Dec
        {
            AnsciiVariables HexANSCII = new AnsciiVariables();
            byte zeroANSCII = HexANSCII.AnsciiZero();
            byte nineANSCII = HexANSCII.AnsciiNine();
            byte aANSCII = HexANSCII.AnsciiLetterA();
            byte bANSCII = HexANSCII.AnsciiLetterB();
            byte cANSCII = HexANSCII.AnsciiLetterC();
            byte dANSCII = HexANSCII.AnsciiLetterD();
            byte eANSCII = HexANSCII.AnsciiLetterE();
            byte fANSCII = HexANSCII.AnsciiLetterF();
            const byte differenceToConvertDec = 7;
            const int differenceFromAToZero = 15;
            const int multiplierInDecConversion = 16;


            byte[] inputANSCII = Encoding.ASCII.GetBytes(input_hex);
            int[] intInput = new int [inputANSCII.Length];

            //Transform letters in Hex into numbers in Dec
            for (int i = 0; i < intInput.Length; i++)
            {
                intInput[i] = inputANSCII[i] - zeroANSCII;
                if (intInput[i] > differenceFromAToZero)
                {
                    intInput[i] = intInput[i] - differenceToConvertDec;
                }
            }
  
            Array.Reverse(intInput);
            int intOutput = 0;

            for (int i = 0; i < intInput.Length; i++)
            {
                intOutput = (intOutput + (intInput[i] * (int)Math.Pow(multiplierInDecConversion, i)));
            }

            string output = intOutput.ToString();
            return output;
         }

        public string ConvertDecToBinary (string input_hex)
        //Method to convert Dec number to Bin
        {
            ConversionMethods DecToBinary = new ConversionMethods();
            string strInputDec = DecToBinary.ConvertHexToDec(input_hex);
            int intInputDec = Convert.ToInt32(strInputDec);
            int leftover = intInputDec;
            int temp = 0;
            string output = string.Empty;

            while (leftover > 0)
            {
                temp = leftover % 2;
                leftover = leftover / 2;
                output = output + temp;
            }
           
            char[] charBinConvert = output.ToArray();
            string strBinConvrt = string.Empty;
            for (int i = output.Length - 1; i >= 0; i--)
            {
                strBinConvrt = strBinConvrt + charBinConvert[i].ToString();
            }

            return strBinConvrt;
        }
    }

    class AnsciiVariables
    {
        public byte AnsciiZero()
        {
            const byte zeroANSCII = 48;
            return zeroANSCII;
        }
        public byte AnsciiNine()
        {
            const byte nineANSCII = 57;
            return nineANSCII;
        }
        public byte AnsciiLetterA()
        {
            const byte aANSCII = 65;
            return aANSCII;
        }
        public byte AnsciiLetterB()
        {
            const byte bANSCII = 66;
            return bANSCII;
        }
        public byte AnsciiLetterC()
        {
            const byte cANSCII = 67;
            return cANSCII;
        }
        public byte AnsciiLetterD()
        {
            const byte dANSCII = 68;
            return dANSCII;
        }
        public byte AnsciiLetterE()
        {
            const byte eANSCII = 69;
            return eANSCII;
        }
        public byte AnsciiLetterF()
        {
            const byte fANSCII = 70;
            return fANSCII;
        }        
    }
}