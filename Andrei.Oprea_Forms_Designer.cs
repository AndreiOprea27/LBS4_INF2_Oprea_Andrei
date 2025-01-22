namespace forms_designer_test
{
    public class MainForm : Form
    {
        private Button testButton;
        private TextBox nameInput;
        private Label nameLabel;
        private TextBox ageInput;
        private Label ageLabel;

        public MainForm()
        {
            nameLabel = new Label();
            nameLabel.Text = "Geben Sie Ihre Name ein:";
            nameLabel.Location = new Point(50, 0);
            nameLabel.AutoSize = true;

            nameInput = new TextBox();
            nameInput.Location = new Point(50, 20);
            nameInput.Width = 200;

            ageLabel = new Label();
            ageLabel.Text = "Geben Sie Ihre Alter ein:";
            ageLabel.Location = new Point(50, 50);
            ageLabel.AutoSize = true;

            ageInput = new TextBox();
            ageInput.Location = new Point(50, 70);
            ageInput.Width = 200;

            testButton = new Button();
            testButton.Text = "Klicken Sie mich";
            testButton.Location = new Point(50, 100);
            testButton.Click += TestButton_Click;

            this.Controls.Add(nameLabel);
            this.Controls.Add(nameInput);
            this.Controls.Add(ageLabel);
            this.Controls.Add(ageInput);
            this.Controls.Add(testButton);

            this.Text = "Button Test";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(300, 200);
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            string name = nameInput.Text;
            string age = ageInput.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Bitte geben Sie einen Namen ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(string.IsNullOrWhiteSpace(age))
            {
                MessageBox.Show("Bitte geben Sie eine Alter ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Name: " + name + "\nAlter: " + age);
            }
        }

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
