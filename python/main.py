def calculator():
    first = float(input("Pierwsza liczba: "))
    second = float(input("Druga liczba: "))
    operation = input("Operacja (+, -, *, /): ").strip()

    if operation == "+":
        result = first + second
    elif operation == "-":
        result = first - second
    elif operation == "*":
        result = first * second
    elif operation == "/":
        if second == 0:
            print("Nie można dzielić przez zero.")
            return
        result = first / second
    else:
        print("Nieznana operacja.")
        return
    print(f"Wynik: {result:g}")


def convert_temperature():
    direction = input("Kierunek (C lub F): ").strip().upper()
    if direction not in ("C", "F"):
        print("Wybierz C lub F.")
        return
    temperature = float(input("Temperatura: "))
    if direction == "C":
        print(f"{temperature:g}°C = {temperature * 1.8 + 32:g}°F")
    else:
        print(f"{temperature:g}°F = {(temperature - 32) / 1.8:g}°C")


def grade_average():
    count = int(input("Liczba ocen: "))
    if count <= 0:
        print("Podaj dodatnią liczbę ocen.")
        return

    total = 0
    for number in range(1, count + 1):
        grade = int(input(f"Ocena {number} (1–6): "))
        if not 1 <= grade <= 6:
            print("Ocena musi być liczbą całkowitą od 1 do 6.")
            return
        total += grade

    average = total / count
    print(f"Średnia: {average:.2f}")
    if average >= 3.0:
        print("Uczeń zdał.")
    else:
        print("Uczeń nie zdał.")


def main():
    while True:
        print("\n1. Kalkulator\n2. Konwerter temperatur\n3. Średnia ocen\n0. Wyjście")
        try:
            choice = input("Wybór: ").strip()
            if choice == "1":
                calculator()
            elif choice == "2":
                convert_temperature()
            elif choice == "3":
                grade_average()
            elif choice == "0":
                break
            else:
                print("Wybierz opcję od 0 do 3.")
        except ValueError:
            print("Podaj poprawną liczbę (użyj kropki w liczbie dziesiętnej).")
        except EOFError:
            break


if __name__ == "__main__":
    main()
