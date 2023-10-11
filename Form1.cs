namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btn_1_Click(object sender, EventArgs e)
        {
            Display.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            Display.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            Display.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            Display.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            Display.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            Display.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            Display.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            Display.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            Display.Text += "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            Display.Text += "0";
        }

        private void btn_dot_Click(object sender, EventArgs e)
        {
            Display.Text += ".";
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            Display.Text += "+";
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            Display.Text += "-";
        }

        private void btn_Multiplication_Click(object sender, EventArgs e)
        {
            Display.Text += "*";
        }

        private void btn_Division_Click(object sender, EventArgs e)
        {
            Display.Text += "/";
        }

        private void btn_PowerOfTwo_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_PowOfY_Click(object sender, EventArgs e)
        {

        }

        private void btn_Sqrt2_Click(object sender, EventArgs e)
        {

        }

        private void btn_ParantheseL_Click(object sender, EventArgs e)
        {
            Display.Text += "(";
        }

        private void btn_ParantheseR_Click(object sender, EventArgs e)
        {
            Display.Text += ")";
        }

        private void btn_Equal_Click(object sender, EventArgs e)
        {
            //here we'll save the input and make then calculate it. 
        }

        private void Display_TextChanged(object sender, EventArgs e)
        {
            //string textBoxText = Display_TextChanged.Text;
        }

        private void btn_backspace_Click(object sender, EventArgs e)
        {
            // Check if there's anything to backspace
            if (Display.Text.Length > 0)
            {
                // Remove the last character
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
        }

        private void keyboardInputReader()
        {
            /*switch read what key is down
            *{
            *case 1
            *   if (key 1 was not down frame before 'downbefore')
            *      do the stuff as if button btn_1 was presed
            *      make the bool for key 1 downbefore true 
            *   //else nothing will hapen but we dont have to write this
            *   break;
            *case 1
            *   if (key 2 was not down frame before 'downbefore')
            *      do the stuff as if button btn_2 was presed
            *      make the bool for key 2 downbefore true 
            *   //else nothing will hapen but we dont have to write this
            *   break;
            *... rest of buttons
            *default
            *   when nothing was presed
            *}
            */
        }
    }
}