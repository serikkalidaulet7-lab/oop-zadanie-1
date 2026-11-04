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


if __name__ == "__main__":
    try:
        grade_average()
    except (ValueError, EOFError):
        print("Podaj poprawne dane.")
