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


if __name__ == "__main__":
    try:
        convert_temperature()
    except (ValueError, EOFError):
        print("Podaj poprawne dane.")
