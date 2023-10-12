using NCalc; //Install-Package NCalc

class Calculator
{
    public void Run(string displayExpression)
    {
        string input = displayExpression;

        // Interpret the input before calculation
        string interpretedInput = displayExpresionToInput.Interpret(input);

        // Calculate the interpreted input
        ExpressionEvaluator.Calculate(interpretedInput);
    }
}


class ExpressionEvaluator
{
    // Declare a public property to store the current answer
    public static string CurrentAnswer { get; private set; }

    // Declare a public event to notify when the answer changes
    public static event EventHandler AnswerChanged;

    private static void OnAnswerChanged()
    {
        AnswerChanged?.Invoke(null, EventArgs.Empty);
    }

    public static void Calculate(string input)
    {
        try
        {
            Expression expression = new Expression(input);
            object result = expression.Evaluate();

            if (result is double && (double.IsPositiveInfinity((double)result) || double.IsNegativeInfinity((double)result)))
            {
                CurrentAnswer = "NaN";
                // Send NaN to AnswerDisplay so AnswerDisplay displays = NaN
            }
            else
            {
                CurrentAnswer = result.ToString();
            }

            // Trigger the AnswerChanged event
            OnAnswerChanged();
        }
        catch (EvaluationException e)
        {
            CurrentAnswer = $"Error: {e.Message}";
            // Make AnswerDisplay display error
            OnAnswerChanged();
        }
        catch (Exception e)
        {
            CurrentAnswer = $"Error: Invalid input - {e.Message}";
            // Make AnswerDisplay display error
            OnAnswerChanged();
        }
    }
}