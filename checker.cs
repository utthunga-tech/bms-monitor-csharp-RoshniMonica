using System;
using System.Diagnostics;

class Checker
{
    private static bool BatteryIsOk(float temperature, float soc, float chargeRate)
    {
        if (!ExecuteMethod(CheckTemperatureIsOk, temperature))
        {
            PrintWarningInConsole("Temperature");
            return false;
        }

        if (!ExecuteMethod(CheckSOCIsOk, soc))
        {
            PrintWarningInConsole("State of Charge");
            return false;
        }

        if (!ExecuteMethod(ChargeRateIsOK, chargeRate))
        {
            PrintWarningInConsole("Charge Rate");
            return false;
        }

        return true;
    }

    private static void PrintWarningInConsole(string parameter)
    {
        Console.WriteLine($"{parameter} is out of range!");
    }

    private static bool ExecuteMethod(Func<float, bool> conditionFunc, float inputValue)
    {
        return conditionFunc.Invoke(inputValue);
    }

    private static bool CheckTemperatureIsOk(float temperature)
    {
        if (temperature < 0 || temperature > 45)
        {
            return false;
        }
        return true;
    }

    private static bool CheckSOCIsOk(float soc)
    {
        if (soc < 20 || soc > 80)
        {
            return false;
        }
        return true;
    }
    private static bool ChargeRateIsOK(float chargeRate)
    {
        if (chargeRate > 0.8)
        {
            return false;
        }
        return true;
    }

    private static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    private static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    private static int Main()
    {
        ExpectTrue(BatteryIsOk(25, 70, 0.7f));
        ExpectFalse(BatteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");
        Console.ReadKey();
        return 0;
    }
}