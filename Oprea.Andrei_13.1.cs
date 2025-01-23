namespace Oprea.Andrei_13._1
{
    public class Calculator : Form
    {
        private TextBox display;
        private double currentValue = 0;
        private string currentOperator = string.Empty;
        private bool isNewEntry = true;

        public Calculator()
        {
            Text = "Calculator";
            Size = new Size(350, 450);
            BackColor = Color.LightGreen;

            display = new TextBox
            {
                Dock = DockStyle.Top,
                Font = new Font("Arial", 32),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                Text = "0",
                Height = 60
            };
            Controls.Add(display);

            var buttonsPanel = new TableLayoutPanel
            {
                Location = new Point(0, 60),
                ColumnCount = 4,
                RowCount = 5,
                AutoSize = true
            };
            Controls.Add(buttonsPanel);

            string[] buttonLabels = {
                "7", "8", "9", "/",
                "4", "5", "6", "*",
                "1", "2", "3", "-",
                "C", "0", "=", "+",
                "^", "log", "%", ","
            };

            foreach (string label in buttonLabels)
            {
                if (string.IsNullOrEmpty(label)) continue;

                var button = new Button
                {
                    Text = label,
                    Font = new Font("Arial", 24),
                    Width = 75,
                    Height = 50,
                    BackColor = Color.LightGreen
                };
                button.Click += Button_Click;
                buttonsPanel.Controls.Add(button);
            }

            var infoLabel = new Label
            {
                Text = "You need to start with + and your number of choice to start with a number",
                Dock = DockStyle.Bottom,
                Font = new Font("Arial", 12),
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 50
            };
            Controls.Add(infoLabel);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button button)
                {
                    string buttonText = button.Text;

                    if (char.IsDigit(buttonText, 0))
                    {
                        if (isNewEntry)
                        {
                            display.Text = buttonText;
                            isNewEntry = false;
                        }
                        else
                        {
                            display.Text += buttonText;
                        }
                    }
                    else if (buttonText == ",")
                    {
                        if (!display.Text.Contains(","))
                        {
                            display.Text += ",";
                        }
                    }
                    else
                    {
                        switch (buttonText)
                        {
                            case "C":
                                currentValue = 0;
                                currentOperator = string.Empty;
                                display.Text = "0";
                                break;
                            case "=":
                                Evaluate();
                                currentOperator = string.Empty;
                                break;
                            case "^":
                            case "log":
                            case "%":
                            case "+":
                            case "-":
                            case "*":
                            case "/":
                                if (!isNewEntry)
                                {
                                    Evaluate();
                                }
                                currentOperator = buttonText;
                                currentValue = double.Parse(display.Text);
                                isNewEntry = true;
                                break;
                            default:
                                throw new NotSupportedException("Unsupported operation");
                        }
                    }
                }
            }
            catch (FormatException)
            {
                display.Text = "Error: Invalid Input";
                isNewEntry = true;
            }
            catch (Exception ex)
            {
                display.Text = $"Error: {ex.Message}";
                isNewEntry = true;
            }
        }

        private void Evaluate()
        {
            try
            {
                double newValue = double.Parse(display.Text);

                switch (currentOperator)
                {
                    case "+":
                        currentValue += newValue;
                        break;
                    case "-":
                        currentValue -= newValue;
                        break;
                    case "*":
                        currentValue *= newValue;
                        break;
                    case "/":
                        if (newValue == 0)
                            throw new DivideByZeroException("Cannot divide by zero");
                        currentValue /= newValue;
                        break;
                    case "^":
                        currentValue = Math.Pow(currentValue, newValue);
                        break;
                    case "log":
                        if (currentValue <= 0 || newValue <= 0)
                            throw new ArgumentException("Logarithm requires positive numbers");
                        currentValue = Math.Log(currentValue, newValue);
                        break;
                    case "%":
                        currentValue %= newValue;
                        break;
                }

                display.Text = currentValue.ToString();
                isNewEntry = true;
            }
            catch (DivideByZeroException ex)
            {
                display.Text = $"Error: {ex.Message}";
                isNewEntry = true;
            }
            catch (FormatException)
            {
                display.Text = "Error: Invalid Input";
                isNewEntry = true;
            }
            catch (Exception ex)
            {
                display.Text = $"Error: {ex.Message}";
                isNewEntry = true;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Calculator());
        }
    }
}
