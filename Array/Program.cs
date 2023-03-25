using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // https://learn.microsoft.com/en-us/dotnet/api/system.array
        // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1

        {
            var flags = new byte[]
            {
                0x12, 0x34, 0x56, 0x78, 0xAA, 0xBB, 0xCC, 0xDD
            };
            Console.WriteLine($"Main.flags: {GetHex(flags)}");

            // Pass by value but flags is a reference type
            // Hence, values here are modified as well
            SetLSBs(flags);
            Console.WriteLine($"Main.flags: {GetHex(flags)}\n");
        }

        {
            var flags = new byte[]
            {
                0x12, 0x34, 0x56, 0x78, 0xAA, 0xBB, 0xCC, 0xDD
            };
            Console.WriteLine($"Main.flags: {GetHex(flags)}");

            // Avoid local modifications by passing a copy
            SetLSBs(flags[..]);
            Console.WriteLine($"Main.flags: {GetHex(flags)}\n");
        }

        {
            var flags = new byte[]
            {
                0x12, 0x34, 0x56, 0x78, 0xAA, 0xBB, 0xCC, 0xDD
            };
            // List is more useful when data is not completely available
            // at the time of initialization
            // Here we create a List of bytes from an array of bytes
            var lflags = flags.ToList<byte>();
            Console.WriteLine($"Main.lflags: {GetHex(lflags.ToArray())}");

            SetLSBs(lflags);
            Console.WriteLine($"Main.lflags: {GetHex(lflags.ToArray())}\n");
        }

        {
            // Another demo to show adding items to a List
            var lflags = new List<byte> { };
            lflags.Add(0x12);
            lflags.Add(0x34);
            lflags.AddRange(new byte[] { 0x56, 0x78, 0xAA, 0xBB, 0xCC, 0xDD });
            lflags.InsertRange(0, new List<byte> { 0x01, 0x02 }); // can insert at any position
            Console.WriteLine($"Main.lflags: {GetHex(lflags.ToArray())}");

            // Make a copy and pass that into the method
            SetLSBs(new List<byte>(lflags));
            Console.WriteLine($"Main.lflags: {GetHex(lflags.ToArray())}\n");
        }

        {
            // List uses an internal array under the hood
            // This array will be dynamically scaled to meet storage needs
            // Capacity can be used to preallocate to avoid frequent reallocation
            // Preallocate for 10 but initialize only 3 items
            var scores = new List<int>(10) { 11, 22, 33 };
            Console.WriteLine($"Capacity: {scores.Capacity}; Count: {scores.Count}");
            scores.Capacity = 5; // resize Capacity, but can't resize below current Count
            Console.WriteLine($"Capacity: {scores.Capacity}; Count: {scores.Count}\n");
        }
    }

    static string GetHex(byte[] arr)
    {
        return string.Join(" ", arr.Select(b => b.ToString("X2")));
    }

    static void SetLSBs(byte[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] |= 0x01;
        }
        Console.WriteLine($"SetLSBs.arr: {GetHex(arr)}");

        // foreach is a good syntax to loop through items in an array
        // except when we wish to modify the items
        // since item is readonly
        /*
        foreach (var item in arr)
        {
            item ^= 0xFF;
        }
        */
    }

    static void SetLSBs(List<byte> arr)
    {
        for (var i = 0; i < arr.Count; i++)
        {
            arr[i] |= 0x01;
        }
        Console.WriteLine($"SetLSBs.arr: {GetHex(arr.ToArray())}");
    }
}
