using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Declare a variable to store the input expression
        private static String displayExpresion = "";

        // Declare a variable to keep track of the editing position
        private int editingPosition = 0;

        // Declare a variable to keep track of ANS
        private string ANS = "";

        //Form1 constructor
        public Form1()
        {
            InitializeComponent();

            // Subscribe to the AnswerChanged event
            ExpressionEvaluator.AnswerChanged += AnwserDisplay_TextChanged;

            // Subscribe to the KeyDown event for the form
            this.KeyDown += Form1_KeyDown;

            // Set KeyPreview to true in the Form_Load event
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set KeyPreview to true
            this.KeyPreview = true;
        }
        // keyboard functions for the buttons
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for keyboard shortcuts
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    btn_0.PerformClick();
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    btn_1.PerformClick();
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    btn_2.PerformClick();
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    btn_3.PerformClick();
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    btn_4.PerformClick();
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    btn_5.PerformClick();
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    btn_6.PerformClick();
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    btn_7.PerformClick();
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    btn_8.PerformClick();
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    btn_9.PerformClick();
                    break;
                case Keys.Oemplus: // Plus key
                    btn_plus.PerformClick();
                    break;
                case Keys.OemMinus: // Minus key
                    btn_minus.PerformClick();
                    break;
                case Keys.Escape: // Escape key
                case Keys.C: // C key
                    btn_Clear.PerformClick();
                    break;
                case Keys.Right: // RightArrow
                    btn_ArrowR.PerformClick();
                    break;
                case Keys.Left: // LeftArrow
                    btn_ArrowL.PerformClick();
                    break;
                case Keys.M: // M key
                    btn_Multiplication.PerformClick();
                    break;
                case Keys.D: // D key
                    btn_Division.PerformClick();
                    break;
                case Keys.S: // S key
                    btn_Sqrt2.PerformClick();
                    break;
                case Keys.P: // P key
                    btn_PowOfY.PerformClick();
                    break;
                case Keys.Q: // Q key
                    btn_PowerOfTwo.PerformClick();
                    break;
                case Keys.A: // A key
                    btn_ANS.PerformClick();
                    break;
                case Keys.Decimal:
                case (Keys)188: // Key code for comma (,)
                case Keys.OemPeriod:
                    btn_dot.PerformClick();
                    break;
                case Keys.Back:
                    btn_backspace.PerformClick();
                    break;
                case Keys.Delete:
                    btn_Delite.PerformClick();
                    break;
                // Add more cases for other keys as needed

                case Keys.Enter: // curently dons't work for some reason, it aparently writes the latest pressed button instead 
                case Keys.Space:
                    btn_Equal.PerformClick();
                    break;
            }
        }

        // Method to update the display with the current input expression
        private void UpdateDisplay(string text)
        {
            // Insert an underscore at the editing position
            var displayTextWithUnderscore = new StringBuilder(text);
            displayTextWithUnderscore.Insert(editingPosition, '_');

            // Update the display
            Display.Text = displayTextWithUnderscore.ToString();
        }


        private void btn_0_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("0");
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("1");
        }
        private void btn_2_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("2");
        }
        private void btn_3_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("3");
        }
        private void btn_4_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("4");
        }
        private void btn_5_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("5");
        }
        private void btn_6_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("6");
        }
        private void btn_7_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("7");
        }
        private void btn_8_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("8");
        }
        private void btn_9_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("9");
        }
        private void btn_plus_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("+");
        }
        private void btn_minus_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("-");
        }
        private void btn_Division_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("/");
        }
        private void btn_Multiplication_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("*");
        }
        private void btn_ParantheseR_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition(")");
        }
        private void btn_dot_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition(".");
        }
        private void btn_ParantheseL_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("(");
        }
        private int InsertAtCurrentPosition(string text)
        {
            // Insert the text at the current editing position
            displayExpresion = displayExpresion.Insert(editingPosition, text);

            // Calculate the number of positions inserted
            int positionsInserted = text.Length;

            // Increment the editing position
            editingPosition += positionsInserted;

            // Update the display immediately
            UpdateDisplay(displayExpresion);

            return positionsInserted;
        }
        // Event handler for when the left arrow key is pressed
        private void btn_ArrowL_Click(object sender, EventArgs e)
        {
            // Move the editing position to the left
            if (editingPosition == 0)
            {
                // If at the beginning, wrap around to the end
                editingPosition = displayExpresion.Length;
            }
            else
            {
                // Otherwise, move one position to the left
                editingPosition--;
            }

            // Update the display
            UpdateDisplay(displayExpresion);
        }
        // Event handler for when the right arrow key is pressed
        private void btn_ArrowR_Click(object sender, EventArgs e)
        {
            // Move the editing position to the right
            editingPosition = (editingPosition + 1) % (displayExpresion.Length + 1);

            // Update the display
            UpdateDisplay(displayExpresion);
        }


        // Event handler for when the backspace key is pressed
        private void btn_backspace_Click(object sender, EventArgs e)
        {
            // Check if there's something to delete
            if (editingPosition > 0)
            {
                // Convert the displayExpresion to a StringBuilder for mutable operations
                var sb = new StringBuilder(displayExpresion);

                // Remove the character to the left of the editing position
                sb.Remove(editingPosition - 1, 1);

                // Update the editing position
                editingPosition--;

                // Update the displayExpresion with the modified StringBuilder
                displayExpresion = sb.ToString();

                // Update the display
                UpdateDisplay(displayExpresion);
            }
            else
            {
                // Optionally, you might want to handle the case when the editing position is already at the beginning.
                // For example, do nothing or wrap around to the end.
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            displayExpresion = "";
            editingPosition = 0; // Reset editing position
            UpdateDisplay(displayExpresion);
        }
        private void btn_PowerOfTwo_Click(object sender, EventArgs e)
        {
            // Insert ^2
            InsertAtCurrentPosition("^2");

            // Move forward 2 positions, but ensure editingPosition does not exceed the string length
            editingPosition = Math.Min(editingPosition + 2, displayExpresion.Length);

            // Update the display
            UpdateDisplay(displayExpresion);
        }
        private void btn_PowOfY_Click(object sender, EventArgs e)
        {
            InsertAtCurrentPosition("^");
        }
        private void btn_Sqrt2_Click(object sender, EventArgs e)
        {
            // Add Sqrt and its parentheses
            InsertAtCurrentPosition("√()");

            // Set the editing position to the position inside the parentheses
            editingPosition = displayExpresion.Length - 1;

            // Update the display
            UpdateDisplay(displayExpresion);
        }
        private void btn_ANS_Click(object sender, EventArgs e)
        {
            // Insert ANS
            InsertAtCurrentPosition(ANS);
        }

        //This is the function to have the program start calculating everything
        private void btn_Equal_Click(object sender, EventArgs e)
        {
            // Instantiate Calculator class
            Calculator calc = new Calculator();

            // Pass the displayExpresion to the Calculator class
            calc.Run(displayExpresion);

            // Assuming you want to update the display immediately after calculation
            AnwserDisplay_TextChanged(null, EventArgs.Empty);
        }


        // Event handler for AnswerChanged
        private void AnwserDisplay_TextChanged(object sender, EventArgs e)
        {
            // This is where the answers will be displayed
            string currentAnswer = ExpressionEvaluator.CurrentAnswer;
            if (!(currentAnswer.Contains("Error") || currentAnswer.Contains("NaN")))
            {
                ANS = currentAnswer;
            }

            // Display the expression and answer
            AnwserDisplay.Text = $"{displayExpresion} = {currentAnswer}";
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //remove the charekter infront of the editing position and then update the display, do not change the editiong position so next time the delite button is pressed the charekter that previusly was 2 steps to the right of the editing position will be the thing delited, if there's nothing to delite then do nothing
        }
    }
}
