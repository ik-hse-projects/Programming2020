using System;

public static class TemperatureCalculator
{
    private static void CheckFahrenheit(double fahrenheitTemperature)
    {
        if (fahrenheitTemperature < -459.67)
        {
            throw new ArgumentException("Incorrect input");
        }
    }

    private static void CheckCelsius(double celsiusTemperature)
    {
        if (celsiusTemperature < -273.15)
        {
            throw new ArgumentException("Incorrect input");
        }
    }

    private static void CheckKelvin(double kelvinTemperature)
    {
        if (kelvinTemperature < 0)
        {
            throw new ArgumentException("Incorrect input");
        }
    }

    public static double FromCelsiusToFahrenheit(double celsiusTemperature)
    {
        CheckCelsius(celsiusTemperature);
        return celsiusTemperature * 9 / 5 + 32;
    }

    public static double FromCelsiusToKelvin(double celsiusTemperature)
    {
        CheckCelsius(celsiusTemperature);
        return celsiusTemperature + 273.15;
    }

    public static double FromFahrenheitToCelsius(double fahrenheitTemperature)
    {
        CheckFahrenheit(fahrenheitTemperature);
        return (fahrenheitTemperature - 32) * 5 / 9;
    }

    public static double FromFahrenheitToKelvin(double fahrenheitTemperature)
    {
        CheckFahrenheit(fahrenheitTemperature);
        return FromCelsiusToKelvin(FromFahrenheitToCelsius(fahrenheitTemperature));
    }

    public static double FromKelvinToCelsius(double kelvinTemperature)
    {
        CheckKelvin(kelvinTemperature);
        return kelvinTemperature + 273.15;
    }

    public static double FromKelvinToFahrenheit(double kelvinTemperature)
    {
        CheckKelvin(kelvinTemperature);
        return FromCelsiusToFahrenheit(FromKelvinToCelsius(kelvinTemperature));
    }
}