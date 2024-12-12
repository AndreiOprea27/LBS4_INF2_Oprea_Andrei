namespace Andrei.Oprea_9._3
{
    class Schachspiel
    {
        private const int BoardSize = 8;
        private char[,] board = new char[BoardSize, BoardSize]; // Ein standard Schachbrett ist 8|8
        private int knightRow;
        private int knightCol;

        public Schachspiel()
        {
            InitializeBoard();
            PlaceKnight(0, 0);
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    board[i, j] = '.';
                }
            }
        }

        private void PlaceKnight(int row, int col)
        {
            board[knightRow, knightCol] = '.';
            knightRow = row;
            knightCol = col;
            board[knightRow, knightCol] = 'K'; // aktuelle Position des Pferdes
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write(board[i, j] + " "); // zeigt das Schachbrett
                }
                Console.WriteLine();
            }
        }

        private bool IsValidMove(int newRow, int newCol) // überprüft, ob die Bewegung laut der Regeln erlaubt ist
        {
            if (newRow < 0 || newRow >= BoardSize || newCol < 0 || newCol >= BoardSize)
                return false;

            int rowDiff = Math.Abs(newRow - knightRow);
            int colDiff = Math.Abs(newCol - knightCol);

            return (rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2);
        }

        public void MoveKnight(int newRow, int newCol)
        {
            if (IsValidMove(newRow, newCol))
            {
                PlaceKnight(newRow, newCol);
                Console.WriteLine("Das Pferd wurde bewegt.");
            }
            else
            {
                Console.WriteLine("Ungültiger Zug. Versuchen Sie es erneut.");
            }
        }

        public void RunGame()
        {
            while (true)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("\nGeben Sie die neuen Koordinaten für das Pferd ein:");
                int newRow = -1, newCol = -1;

                while (true)
                {
                    try
                    {
                        Console.Write("Reihe (0-7): ");
                        newRow = int.Parse(Console.ReadLine());
                        if (newRow < 0 || newRow >= BoardSize)
                        {
                            Console.WriteLine("Die Reihe muss zwischen 0 und 7 liegen.");
                            continue;
                        }

                        Console.Write("Spalte (0-7): ");
                        newCol = int.Parse(Console.ReadLine());
                        if (newCol < 0 || newCol >= BoardSize)
                        {
                            Console.WriteLine("Die Spalte muss zwischen 0 und 7 liegen.");
                            continue;
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein.");
                    }
                }

                MoveKnight(newRow, newCol);
            }
        }

        static void Main(string[] args)
        {
            Schachspiel spiel = new Schachspiel();
            spiel.RunGame();
        }
    }
}
