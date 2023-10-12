class displayExpresionToInput
{
    public static string Interpret(string input)
    {
        // Check for special symbols and transform the input
        string interpretedInput = TransformSymbols(input);

        return interpretedInput;
    }

    private static string TransformSymbols(string input)
    {
        string modifiedInput = input;
        while (modifiedInput.Contains('^') || modifiedInput.Contains('√') || modifiedInput.Contains('V'))
        {
            if (modifiedInput.Contains('^'))
            {
                // Find the position of '^' in the modified input
                int index = modifiedInput.IndexOf('^');

                // Extract the base and exponent
                string baseNum = ExtractLeftOperand(modifiedInput, index);
                string exponent = ExtractRightOperand(modifiedInput, index);

                // Replace the '^' expression with Pow(base, exponent)
                string replacement = $"Pow({baseNum}, {exponent})";
                modifiedInput = modifiedInput.Remove(index - baseNum.Length, index + exponent.Length + 1 - (index - baseNum.Length)).Insert(index - baseNum.Length, replacement);
            }
            else if (modifiedInput.Contains('√') || modifiedInput.Contains('V'))
            {
                // Find the position of the square root symbol or 'V' in the modified input
                int index = modifiedInput.IndexOfAny(new[] { '√', 'V' });

                // Extract the expression inside the square root
                string expression = ExtractParenthesizedExpression(modifiedInput, index);

                // Replace the square root symbol or 'V' with Sqrt(expression)
                string replacement = $"Sqrt({expression})";
                modifiedInput = modifiedInput.Remove(index, expression.Length + 1).Insert(index, replacement); // +1 for '√' or 'V'
            }
        }

        return modifiedInput;
    }

    private static string ExtractLeftOperand(string input, int index)
    {
        // Extract the base number to the left of '^'
        int leftIndex = index - 1;
        while (leftIndex >= 0 && (char.IsDigit(input[leftIndex]) || input[leftIndex] == '.'))
        {
            leftIndex--;
        }

        return input.Substring(leftIndex + 1, index - leftIndex - 1);
    }

    private static string ExtractRightOperand(string input, int index)
    {
        // Extract the exponent to the right of '^'
        int rightIndex = index + 1;
        while (rightIndex < input.Length && (char.IsDigit(input[rightIndex]) || input[rightIndex] == '.'))
        {
            rightIndex++;
        }

        return input.Substring(index + 1, rightIndex - index - 1);
    }

    private static string ExtractParenthesizedExpression(string input, int index)
    {
        // Extract the expression inside parentheses after '√' or 'V'
        int start = index + 1;
        int end = input.IndexOf(')', start);

        if (end != -1)
        {
            return input.Substring(start, end - start);
        }

        // Handle the case where the ')' is missing
        throw new ArgumentException($"Mismatched parentheses after '{input[index]}'");
    }
}