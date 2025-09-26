using System;
using System.Text;

public class Utf8Validation
{
    public static bool IsValidUtf8(byte[] bytes)
    {
        try
        {
            // Create a UTF8Encoding object with validation enabled (throwOnInvalidBytes: true)
            var utf8Validator = new UTF8Encoding(false, true); 
            
            // Attempt to get a string from the bytes. 
            // If the bytes are not valid UTF-8, an ArgumentException will be thrown.
            utf8Validator.GetString(bytes); 
            return true; // If no exception, it's valid UTF-8
        }
        catch (ArgumentException)
        {
            return false; // Invalid UTF-8 sequence found
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Test de trois chaînes de caractères pour vérifier si ces chaînes sont des UTF-8 valides.");
        Console.WriteLine("Ces chaînes sont...");
        Console.WriteLine("Hello, world! (ici gît un émoticône sourire)");
        Console.WriteLine("La combinaison des caractères 0xC3 et 0x28 .");
        Console.WriteLine("Le caractère 0x80 .");
        Console.WriteLine("");

        // Example of valid UTF-8
        byte[] validUtf8Bytes = Encoding.UTF8.GetBytes("Hello, world! 😊");
        Console.WriteLine($"Is valid UTF-8: {IsValidUtf8(validUtf8Bytes)}"); // Expected: True

        // Example of invalid UTF-8 (malformed sequence)
        byte[] invalidUtf8Bytes = new byte[] { 0xC3, 0x28 }; // Invalid two-byte sequence
        Console.WriteLine($"Is valid UTF-8: {IsValidUtf8(invalidUtf8Bytes)}"); // Expected: False

        // Example of invalid UTF-8 (standalone continuation byte)
        byte[] invalidUtf8Bytes2 = new byte[] { 0x80 }; 
        Console.WriteLine($"Is valid UTF-8: {IsValidUtf8(invalidUtf8Bytes2)}"); // Expected: False
    }
}