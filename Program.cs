using System;
using System.Text;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string inputString = "12345678919873"; //custom input

        // Converting to ASCII
        byte[] asciiBytes = Encoding.ASCII.GetBytes(inputString);
        string asciiRep = string.Join(" ", asciiBytes);
        Console.WriteLine("ASCII Representation: " + asciiRep);

        // Converting to ASCII HEX
        string asciiHex = BitConverter.ToString(asciiBytes).Replace("-", "");
        Console.WriteLine("ASCII HEX Representation: " + asciiHex);

        // Converting to BCD
        byte[] bcdBytes = inputString.Select(c => (byte)(c - '0')).ToArray();
        string bcdRep= string.Join(" ", bcdBytes.Select(b => Convert.ToString(b, 2).PadLeft(4, '0')));
        Console.WriteLine("BCD Representation: " + bcdRep);

        // Converting to HEX
        string hexRep = BitConverter.ToString(asciiBytes).Replace("-", "");
        Console.WriteLine("HEX Representation: " + hexRep);

        // Converting the input number to EBCDIC
        Encoding ebcdicEncoding = Encoding.GetEncoding("IBM037");
        byte[] ebcdicBytes = ebcdicEncoding.GetBytes(inputString);
        string ebcdicString = ebcdicEncoding.GetString(ebcdicBytes);
         Console.WriteLine("EBCDIC Value: " + ebcdicString);

        // Converting to EBCDIC Binary
        string ebcdicBinaryRep = string.Join(" ", ebcdicBytes.Select(b => Convert.ToString(b, 2)));
        Console.WriteLine("EBCDIC Binary Representation: " + ebcdicBinaryRep);

        // Converting to EBCDIC HEX
        string ebcdicHexRep = BitConverter.ToString(ebcdicBytes).Replace("-", "");
        Console.WriteLine("EBCDIC HEX Representation: " + ebcdicHexRep);

        // Converting to Signed EBCDIC Numeric
        byte[] signedEBCDICNumericBytes = ebcdicBytes.Select(b => (byte)(b + 0x30)).ToArray();
        string signedEBCDICNumericRep= BitConverter.ToString(signedEBCDICNumericBytes).Replace("-", "");
        Console.WriteLine("Signed EBCDIC Numeric Representation: " + signedEBCDICNumericRep);

        // Converting to Binary-HEX
        string binaryHexRep = BitConverter.ToString(asciiBytes).Replace("-", " ");
        Console.WriteLine("Binary-HEX Representation: " + binaryHexRep);

        Console.ReadLine();
    }
}
