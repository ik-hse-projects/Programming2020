using System;

partial class Program
{
    // В случае, если введённый день недели не соответствует формату входных данных
    // метод должен вернуть int.MinValue.
    // Гарантируется, что int.MinValue не может быть получен как верный ответ.
    static int MorningWorkout(string dayOfWeek, int firstNumber, int secondNumber)
    {
        switch (dayOfWeek)
        {
            case "Monday":
            case "Wednesday":
            case "Friday":
                return GetSumOfOddOrEvenDigits(firstNumber, 1);
            case "Tuesday":
            case "Thursday":
                return GetSumOfOddOrEvenDigits(secondNumber, 0);
            case "Saturday":
                return firstNumber > secondNumber ? firstNumber : secondNumber;
            case "Sunday":
                return firstNumber * secondNumber;
            default:
                return int.MinValue;
        }
    }

    static int GetSumOfOddOrEvenDigits(int value, int remainder)
    {
        value = value < 0 ? -value : value;
        var result = 0;
        while (value != 0)
        {
            if (value % 2 == remainder)
            {
                result += value % 10;
            }

            value /= 10;
        }
        return result;
    }
}