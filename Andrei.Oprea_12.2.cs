namespace Andrei.Oprea_12._2
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Welche Datei einlesen?");
            string datei = Console.ReadLine();

            Console.WriteLine("Geben Sie die gewünschte Schriftart ein (z. B. Arial):");
            string fontName = Console.ReadLine();

            try
            {
                if (string.IsNullOrWhiteSpace(datei))
                {
                    throw new ArgumentException("Der Dateiname darf nicht leer sein.");
                }

                if (!File.Exists(datei))
                {
                    throw new FileNotFoundException("Die angegebene Datei wurde nicht gefunden.", datei);
                }

                ApplicationConfiguration.Initialize();
                Application.Run(new CForm(datei, fontName));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ungültiger Eingang: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}");
            }
        }
    }

    class CForm : Form
    {
        private readonly string[] fileLines;
        private readonly Font displayFont;

        public CForm(string fileName, string fontName)
        {
            try
            {
                this.Text = "Datei Inhalt";
                this.ResizeRedraw = true;
                this.AutoScroll = true;

                // Read all lines from the file
                fileLines = File.ReadAllLines(fileName);

                // Attempt to set the desired font
                if (!string.IsNullOrWhiteSpace(fontName) && FontFamily.Families.Any(f => f.Name.Equals(fontName, StringComparison.OrdinalIgnoreCase)))
                {
                    displayFont = new Font(fontName, 12); // Default size: 12
                }
                else
                {
                    displayFont = this.Font; // Fallback to default form font
                    MessageBox.Show("Die angegebene Schriftart wurde nicht gefunden. Es wird die Standardschriftart verwendet.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Set the AutoScrollMinSize to accommodate the total content height
                int totalHeight = fileLines.Length * (int)displayFont.GetHeight();
                this.AutoScrollMinSize = new Size(0, totalHeight);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Fehler beim Lesen der Datei: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fileLines = Array.Empty<string>(); // Avoid null reference issues
                displayFont = this.Font;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fileLines = Array.Empty<string>(); // Avoid null reference issues
                displayFont = this.Font;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            try
            {
                Graphics g = e.Graphics;
                int lineHeight = (int)displayFont.GetHeight();
                int visibleStartY = this.AutoScrollPosition.Y * -1; // The topmost visible Y coordinate
                int visibleEndY = visibleStartY + this.ClientSize.Height; // The bottommost visible Y coordinate

                // Calculate the range of lines to render
                int firstVisibleLine = Math.Max(0, visibleStartY / lineHeight);
                int lastVisibleLine = Math.Min(fileLines.Length - 1, visibleEndY / lineHeight);

                // Draw only the visible lines
                for (int i = firstVisibleLine; i <= lastVisibleLine; i++)
                {
                    int yOffset = (i * lineHeight) + this.AutoScrollPosition.Y;
                    g.DrawString(fileLines[i], displayFont, Brushes.Black, 0, yOffset);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ein Fehler ist beim Zeichnen aufgetreten: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                displayFont?.Dispose(); // Dispose of the custom font if created
            }
            base.Dispose(disposing);
        }
    }
}
