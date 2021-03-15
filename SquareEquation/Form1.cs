using System;
using System.Windows.Forms;

namespace SquareEquation
{
    public partial class Form1 : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        bool isError = false;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// CoefficientA KeyPress event.
        /// </summary>
        /// <param name="sender"> Object. </param>
        /// <param name="e"> Object of class KeyPressEventArgs. </param>
        private void coefficientA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0' && coefficientA.TextLength == 0) e.KeyChar = (char)Keys.None;
            CorrectCoeficient(coefficientA, e);
        }
        /// <summary>
        /// CoefficientB KeyPress event.
        /// </summary>
        /// <param name="sender"> Object. </param>
        /// <param name="e"> Object of class KeyPressEventArgs. </param>
        private void coefficientB_KeyPress(object sender, KeyPressEventArgs e) => CorrectCoeficient(coefficientB, e);
        /// <summary>
        /// CoefficientC KeyPress event.
        /// </summary>
        /// <param name="sender"> Object. </param>
        /// <param name="e"> Object of class KeyPressEventArgs. </param>
        private void coeficientC_KeyPress(object sender, KeyPressEventArgs e) => CorrectCoeficient(coeficientC, e);
        /// <summary>
        /// Checks the correctness of the coefficients of the equation.
        /// </summary>
        /// <param name="textbox"> Object of class Textbox. </param>
        /// <param name="e"> Object of class KeyPressEventArgs. </param>
        private void CorrectCoeficient(TextBox textbox, KeyPressEventArgs e)
        {
            int index;
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back && textbox.TextLength != 0)
                {
                    textbox.Text = textbox.Text.Remove(textbox.TextLength - 1, 1);
                    textbox.SelectionStart = textbox.Text.Length + 1;
                    e.Handled = true;
                }
                else if (e.KeyChar == '+' && textbox.TextLength == 0)
                {
                    index = textbox.Text.IndexOf('+');
                    if (index != -1) e.KeyChar = (char)Keys.None;
                }
                else if (e.KeyChar == '-' && textbox.TextLength == 0)
                {
                    index = textbox.Text.IndexOf('-');
                    if (index != -1) e.KeyChar = (char)Keys.None;
                }
                else if (e.KeyChar == ',')
                {
                    index = textbox.Text.IndexOf(',');
                    if (textbox.TextLength == 0 || index != -1) e.KeyChar = (char)Keys.None;
                }
                else e.KeyChar = (char)Keys.None;
            }
        }
        /// <summary>
        /// Clicking an event of button "Clear".
        /// </summary>
        /// <param name="sender"> Object. </param>
        /// <param name="e"> Object of class EventArgs. </param>
        private void clear_Click(object sender, EventArgs e)
        {
            coefficientA.Clear();
            coefficientB.Clear();
            coeficientC.Clear();
            firstRoot.Clear();
            secondRoot.Clear();
        }
        /// <summary>
        /// Clicking an event of button "Close".
        /// </summary>
        /// <param name="sender"> Object. </param>
        /// <param name="e"> Object of class EventArgs. </param>
        private void close_Click(object sender, EventArgs e) => Close();

        /// <summary>
        /// Searching roots of the square equation.
        /// </summary>
        /// <param name="a"> The first coefficient. </param>
        /// <param name="b"> The second coefficient. </param>
        /// <param name="c"> The third coefficient. </param>
        /// <returns> Roots of square equation. </returns>
        private (double, double, string, string) SrchRoots(double a, double b, double c)
        {
            double x1 = default, x2 = default, disc = default;
            string complexX1 = null, complexX2 = null;
            disc = b * b - 4 * a * c;
            if (disc > 0)
            {
                x1 = (-b + Math.Sqrt(disc)) / (2 * a);
                x2 = (-b - Math.Sqrt(disc)) / (2 * a);
            }
            else if (disc == 0)
            {
                x1 = -b / (2 * a);
                x2 = x1;
            }
            else
            {
                disc = Math.Abs(disc);
                double complex = Math.Round((Math.Sqrt(disc) / (2 * a)), 3);
                double num = Math.Round(Math.Abs(b) / (2*a), 2);
                complexX1 = $"{num.ToString()} + i·{complex.ToString()}";
                complexX2 = complexX1;
                complexX2 = complexX2.Replace('+', '-');
            }
            return (Math.Round(x1, 3), Math.Round(x2, 3), complexX1, complexX2);
        }
        /// <summary>
        /// MouseClick event of textbox "way1"
        /// </summary>
        /// <param name="sender"> Object. </param>
        /// <param name="e"> Object of class EventArgs. </param>
        private void way1_MouseClick(object sender, MouseEventArgs e)
        {
            if (way2.Checked) way2.Checked = false;
            if (way3.Checked) way3.Checked = false;
        }
        /// <summary>
        /// MouseClick event of textbox "way2"
        /// </summary>
        /// <param name="sender"> Object. </param>
        /// <param name="e"> Object of class EventArgs. </param>
        private void way2_MouseClick(object sender, MouseEventArgs e)
        {
            if (way1.Checked) way1.Checked = false;
            if (way3.Checked) way3.Checked = false;
        }
        /// <summary>
        /// MouseClick event of textbox "way3"
        /// </summary>
        /// <param name="sender"> Object. </param>
        /// <param name="e"> Object of class EventArgs. </param>
        private void way3_MouseClick(object sender, MouseEventArgs e)
        {
            if (way1.Checked) way1.Checked = false;
            if (way2.Checked) way2.Checked = false;
        }
        /// <summary>
        /// Clicking an event of button "Calculate".
        /// </summary>
        /// <param name="sender"> Object. </param>
        /// <param name="e"> Object of class EventArgs. </param>
        private void calculate_Click(object sender, EventArgs e)
        {
            if (isError)
            {
                errorProvider.Clear();
                isError = false;
            }
            if (String.IsNullOrEmpty(coefficientA.Text) || String.IsNullOrEmpty(coefficientB.Text) || String.IsNullOrEmpty(coeficientC.Text))
            {
                if(String.IsNullOrEmpty(coefficientA.Text)) errorProvider.SetError(coefficientA, "Enter a value.");
                if(String.IsNullOrEmpty(coefficientB.Text)) errorProvider.SetError(coefficientB, "Enter a value.");
                if (String.IsNullOrEmpty(coeficientC.Text)) errorProvider.SetError(coeficientC, "Enter a value.");
                isError = true;
            }
            else if (!way1.Checked && !way2.Checked && !way3.Checked)
            {
                errorProvider.SetError(way1, "Choose a way.");
                errorProvider.SetError(way2, "Choose a way.");
                errorProvider.SetError(way3, "Choose a way.");
                isError = true;
            }
            else
            {
                double x1 = default, x2 = default, a = Convert.ToDouble(coefficientA.Text), b = Convert.ToDouble(coefficientB.Text), c = Convert.ToDouble(coeficientC.Text);
                string complexX1 = default, complexX2 = default;
                if (way1.Checked) (x1, x2, complexX1, complexX2) = SQEquation.SearchRoots(a, b, c);
                else if (way2.Checked) (x1, x2, complexX1, complexX2) = SrchRoots(a, b, c);
                else if (way3.Checked)
                {
                    double disc = b * b - 4 * a * c;
                    if (disc > 0)
                    {
                        x1 = Math.Round((-b + Math.Sqrt(disc)) / (2 * a),3);
                        x2 = Math.Round((-b - Math.Sqrt(disc)) / (2 * a),3);
                    }
                    else if (disc == 0)
                    {
                        x1 = Math.Round((-b / (2 * a)),3);
                        x2 = x1;
                    }
                    else
                    {
                        disc = Math.Abs(disc);
                        double complex = Math.Round((Math.Sqrt(disc) / (2 * a)), 3);
                        double num = Math.Round(Math.Abs(b) / (2*a), 2);
                        complexX1 = $"{num.ToString()} + i·{complex.ToString()}";
                        complexX2 = complexX1;
                        complexX2 = complexX2.Replace('+', '-');
                    }
                }
                if (String.IsNullOrEmpty(complexX1) && String.IsNullOrEmpty(complexX2))
                {
                    firstRoot.Text = x1.ToString();
                    secondRoot.Text = x2.ToString();
                }
                else
                {
                    firstRoot.Text = complexX1;
                    secondRoot.Text = complexX2;
                }
            }
        }
    }
}
