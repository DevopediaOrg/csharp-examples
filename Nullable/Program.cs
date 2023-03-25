internal class Program
{
    private static void Main(string[] args)
    {
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types

        // ? indicate Nullable type
        string? name = null;
        PrintName(name);

        int? age = 90;
        PrintAge(age);

        Console.WriteLine($"Arc Length for radius 2: {GetArcLength(2)}");

        string[]? names = null; // {}
        if (names?.Length > 0) Console.WriteLine($"Number of names in array: {names.Length}"); // ?.
        else Console.WriteLine("Names array is empty.");
    }

    static void PrintName(string? name)
    {
        if (name == null) Console.WriteLine("Name is null");
        else Console.WriteLine($"Name is {name}");

        // Other possible tests of strings:
        // string.IsNullOrEmpty(name) or string.IsNullOrWhiteSpace(name)
    }

    static void PrintAge(int? age)
    {
        if (!age.HasValue) Console.WriteLine("Age is not initialized");
        else Console.WriteLine($"Age is {age}"); // or age.Value
    }

    static double GetArcLength(double radius, double? theta = null)
    {
        // This code is shortened with the ??
        // if (theta == null) theta = 2 * Math.PI;

        // ?? is called null-coalescing operator
        // :here it converts from double? to double
        // :if null, use 2 * PI as default value
        return radius * (theta ?? 2 * Math.PI);

        // ?? is equivalent to:
        //return radius * theta.GetValueOrDefault(2 * Math.PI);
    }
}
