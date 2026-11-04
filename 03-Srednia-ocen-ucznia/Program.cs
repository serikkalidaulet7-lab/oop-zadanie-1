using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            GradeAverage();
        }
        catch (FormatException)
        {
            Console.WriteLine("Podaj poprawne dane.");
        }
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
