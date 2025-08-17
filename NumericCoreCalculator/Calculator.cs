// © The Numeric Core Calculator contributors
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

namespace NumericCoreCalculator;

public static class Calculator
{
    private enum MathOp
    {
        Subtract,
        Divide,
        Multiply
    }

    private static readonly List<List<MathOp>> s_possibleOperations =
    [
        [ MathOp.Divide, MathOp.Multiply, MathOp.Subtract ],
        [ MathOp.Divide, MathOp.Subtract, MathOp.Multiply ],
        [ MathOp.Multiply, MathOp.Divide, MathOp.Subtract ],
        [ MathOp.Multiply, MathOp.Subtract, MathOp.Divide ],
        [ MathOp.Subtract, MathOp.Divide, MathOp.Multiply ],
        [ MathOp.Subtract, MathOp.Multiply, MathOp.Divide ]
    ];

    public static int? Calculate(int[] numbers)
    {
        if (numbers.Any(n => n < 1))
        {
            throw new ArgumentException("All elements in numbers must be positive.", nameof(numbers));
        }

        if (numbers.Length != 4)
        {
            throw new ArgumentException("Exactly 4 elements required to calculate a numeric core.", nameof(numbers));
        }
        int? result = null;
        foreach (var ops in s_possibleOperations)
        {
            double calc = numbers[0]; //storing as double to ensure float calculation.
            for (int i = 0; i < ops.Count; i++)
            {
                var op = ops[i];
                switch (op)
                {
                    case MathOp.Subtract:
                        calc -= numbers[i + 1];
                        break;
                    case MathOp.Divide:
                        calc /= numbers[i + 1];
                        break;
                    case MathOp.Multiply:
                        calc *= numbers[i + 1];
                        break;
                }
            }

            if (calc % 1 != 0 || calc < 1)
            {
                continue;
            }

            if (result == null || calc < result)
            {
                result = (int)calc;
            }
        }

        return result;
    }
}
