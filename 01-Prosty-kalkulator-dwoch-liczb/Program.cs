using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            Calculator();
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

    static void Calculator()
    {
        double first = ReadNumber("Pierwsza liczba: ");
        double second = ReadNumber("Druga liczba: ");
        Console.Write("Operacja (+, -, *, /): ");
        string operation = (Console.ReadLine() ?? "").Trim();
        double result;

        if (operation == "+")
            result = first + second;
        else if (operation == "-")
            result = first - second;
        else if (operation == "*")
            result = first * second;
        else if (operation == "/")
        {
            if (second == 0)
            {
                Console.WriteLine("Nie można dzielić przez zero.");
                return;
            }
            result = first / second;
        }
        else
        {
            Console.WriteLine("Nieznana operacja.");
            return;
        }

        Console.WriteLine("Wynik: " + Format(result));
    }
}
