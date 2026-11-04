using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Kalkulator\n2. Konwerter temperatur\n3. Średnia ocen\n0. Wyjście");
            Console.Write("Wybór: ");
            string choice = Console.ReadLine();
            try
            {
                switch (choice == null ? null : choice.Trim())
                {
                    case "1": Calculator(); break;
                    case "2": ConvertTemperature(); break;
                    case "3": GradeAverage(); break;
                    case "0":
                    case null: return;
                    default: Console.WriteLine("Wybierz opcję od 0 do 3."); break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Podaj poprawną liczbę (użyj kropki w liczbie dziesiętnej).");
            }
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

    static int ReadInteger(string prompt)
    {
        Console.Write(prompt);
        int number;
        if (!int.TryParse(Console.ReadLine(), out number))
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

    static void GradeAverage()
    {
        int count = ReadInteger("Liczba ocen: ");
        if (count <= 0)
        {
            Console.WriteLine("Podaj dodatnią liczbę ocen.");
            return;
        }

        long total = 0;
        for (int index = 0; index < count; index++)
        {
            int grade = ReadInteger($"Ocena {index + 1} (1–6): ");
            if (grade < 1 || grade > 6)
            {
                Console.WriteLine("Ocena musi być liczbą całkowitą od 1 do 6.");
                return;
            }
            total += grade;
        }

        double average = (double)total / count;
        Console.WriteLine("Średnia: " + Format(average, "F2"));
        if (average >= 3.0)
            Console.WriteLine("Uczeń zdał.");
        else
            Console.WriteLine("Uczeń nie zdał.");
    }
}
