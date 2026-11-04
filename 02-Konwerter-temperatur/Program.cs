using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            ConvertTemperature();
        }
        catch (FormatException)
        {
            Console.WriteLine("Podaj poprawne dane.");
        }
    }

    static double ReadNumber(string prompt)
    {
        Console.Write(prompt);
        double number;
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Float,
                             CultureInfo.InvariantCulture, out number))
            throw new FormatException();
        return number;
    }

    static string Format(double number, string pattern = "G6")
    {
        return number.ToString(pattern, CultureInfo.InvariantCulture);
    }

    static void ConvertTemperature()
    {
        Console.Write("Kierunek (C lub F): ");
        string direction = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
        if (direction != "C" && direction != "F")
        {
            Console.WriteLine("Wybierz C lub F.");
            return;
        }

        double temperature = ReadNumber("Temperatura: ");
        if (direction == "C")
            Console.WriteLine($"{Format(temperature)}°C = {Format(temperature * 1.8 + 32)}°F");
        else
            Console.WriteLine($"{Format(temperature)}°F = {Format((temperature - 32) / 1.8)}°C");
    }
}
