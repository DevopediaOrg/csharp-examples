using System;
using System.Linq;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // https://learn.microsoft.com/en-us/dotnet/api/system.array
        // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1

        byte[] buff = new byte[]
        {
            0x12, 0x34, 0x56, 0x78, // hdr
            0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF // body
        };

        // Whole array is passed into the methods
        DecodeHeader(buff);
        DecodeBody(buff);

        // Pass only what's needed but this does a copy
        const int HDRLEN = 4;
        DecodeHeader(buff[..HDRLEN]);
        DecodeBody(buff[HDRLEN..]);

        // Span avoids copying
        // ReadOnlySpan in the method argument is even better
        Span<byte> sbuff = buff;
        DecodeHeader(sbuff[..HDRLEN]);
        DecodeBody(sbuff[HDRLEN..]);

        // Using List instead of Array
        // Take() is a System.LINQ syntax
        // Take() returns IEnumerable<byte>
        var lbuff = new List<byte>(buff);
        DecodeHeader(lbuff.Take(HDRLEN));
        DecodeBody(lbuff.Take(HDRLEN..));
    }

    static void DecodeHeader(byte[] arr)
    {
        Console.WriteLine($"DecodeHeader(byte[]): {arr.Length} bytes");
    }

    static void DecodeBody(byte[] arr)
    {
        Console.WriteLine($"DecodeBody(byte[]): {arr.Length} bytes");
    }

    static void DecodeHeader(ReadOnlySpan<byte> arr)
    {
        Console.WriteLine($"DecodeHeader(Span<byte>): {arr.Length} bytes");
    }

    static void DecodeBody(ReadOnlySpan<byte> arr)
    {
        Console.WriteLine($"DecodeBody(Span<byte>): {arr.Length} bytes");
    }

    static void DecodeHeader(IEnumerable<byte> arr)
    {
        Console.WriteLine($"DecodeHeader(IEnumerable<byte>): arr[0]: 0x{arr.ElementAt(0):X2}");
        Console.WriteLine($"DecodeHeader(IEnumerable<byte>): last: 0x{arr.Last():X2}");
        Console.WriteLine($"DecodeHeader(IEnumerable<byte>): {arr.Count()} bytes");
    }

    static void DecodeBody(IEnumerable<byte> arr)
    {
        Console.WriteLine($"DecodeBody(IEnumerable<byte>): {arr.Count()} bytes");
    }
}

