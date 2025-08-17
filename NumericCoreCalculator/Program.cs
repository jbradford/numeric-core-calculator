// © The Numeric Core Calculator contributors
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using NumericCoreCalculator;

do
{
    Console.WriteLine("Please enter either the 4 numbers (separated by spaces), or the 4 letter word to generate a core for, or Q to quit.");
    string? input = Console.ReadLine();
    int[] calculatorInput;

    if (input == null)
    {
        continue;
    }

    if (input is "Q" or "q")
    {
        break;
    }

    if (input.Length == 4 && input.All(char.IsAsciiLetter))
    {
        calculatorInput = input.Select(c => char.ToUpper(c) - 'A' + 1).ToArray();
    }
    else
    {
        string[] splitInput = input.Split(' ');
        if (input.Split(' ').Length == 4 && splitInput.All(s => int.TryParse(s, out _)))
        {
            calculatorInput = splitInput.Select(int.Parse).ToArray();
        }
        else
        {
            Console.WriteLine("Please enter a valid input!");
            continue;
        }
    }

    int? core = Calculator.Calculate(calculatorInput);
    if (core == null)
    {
        Console.WriteLine("No core found!");
    }
    else
    {
        Console.WriteLine($"Input: {input}{Environment.NewLine}Parsed Input: {string.Join(',', calculatorInput.Select(i => i.ToString()))}{Environment.NewLine}Numeric Core: {core}");
        if (core <= 27)
        {
            Console.WriteLine($"Character Core:{(char)(core + 'A' - 1)}");
        }
    }
} while (true);
