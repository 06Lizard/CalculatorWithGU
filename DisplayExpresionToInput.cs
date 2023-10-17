using NCalc;
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

        // Handle parentheses first
        while (modifiedInput.Contains('('))
        {
            // Find the index of the first '(' from right to left
            int openParenIndex = modifiedInput.LastIndexOf('(');

            // Find the corresponding ')'
            int closeParenIndex = modifiedInput.IndexOf(')', openParenIndex);

            if (openParenIndex != -1)
            {
                if (closeParenIndex != -1)
                {
                    // Extract the expression inside parentheses
                    string expressionInsideParentheses = modifiedInput.Substring(openParenIndex + 1, closeParenIndex - openParenIndex - 1);
                    string resultInsideParentheses = expressionInsideParentheses;
                    try
                    {
                        // Calculate the expression inside parentheses using ExpressionEvaluator
                        Expression expression = new Expression(expressionInsideParentheses);
                        resultInsideParentheses = expression.Evaluate().ToString();
                    }
                    catch
                    {
                        resultInsideParentheses = expressionInsideParentheses;
                    }
                    // Replace the expression inside parentheses with the result
                    modifiedInput = modifiedInput.Remove(openParenIndex, closeParenIndex - openParenIndex + 1).Insert(openParenIndex, resultInsideParentheses);
                }
                else
                {
                    // Assume all the code to the right of '(' is inside the parentheses
                    string expressionInsideParentheses = modifiedInput.Substring(openParenIndex + 1);
                    string resultInsideParentheses = expressionInsideParentheses;
                    try
                    {
                        // Calculate the expression inside parentheses using ExpressionEvaluator
                        Expression expression = new Expression(expressionInsideParentheses);
                        resultInsideParentheses = expression.Evaluate().ToString();
                    }
                    catch
                    {
                        resultInsideParentheses = expressionInsideParentheses;
                    }
                    // Replace the expression inside parentheses with the result
                    modifiedInput = modifiedInput.Remove(openParenIndex).Insert(openParenIndex, resultInsideParentheses);
                }
            }
        }

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

                // Use ExtractRightOperand for the square root
                string expression = ExtractRightOperand(modifiedInput, index);

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
}

