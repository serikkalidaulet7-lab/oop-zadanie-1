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


if __name__ == "__main__":
    try:
        calculator()
    except (ValueError, EOFError):
        print("Podaj poprawne dane.")
