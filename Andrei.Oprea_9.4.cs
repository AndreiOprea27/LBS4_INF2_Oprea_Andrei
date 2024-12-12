namespace Andrei.Oprea_9._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CStatistik Array = new CStatistik();
            Array.werte = [3, 7, 2, 9, 1];
            //Array.werte = [3, 7, 2, 3, 6, 2, 7, 3, 2, 3];
            
            Array.Wahl();
        }
    }

    class CStatistik
    {
        public int[] werte = new int[100];
        int eingabe;
        int min, max, mid, sw, ma;
        int[] h = new int[100];

        public int[] Wahl()
        {
            Console.WriteLine("Wählen Sie zwischen folgende Funktionen");
            Console.WriteLine("1. Minimum");
            Console.WriteLine("2. Maximum");
            Console.WriteLine("3. Median");
            Console.WriteLine("4. Abstand");
            Console.WriteLine("5. Mittlere Abweichung");
            eingabe = Convert.ToInt32(Console.ReadLine());

            if (eingabe < 0 || eingabe > 5)
            {
                Console.WriteLine("Bitte wählen Sie erneut von die 6 Optionen");
                eingabe = Convert.ToInt32(Console.ReadLine());
            }
            else if (eingabe == 1) Console.WriteLine($"Das Minimum lautet {Minimum()}");
            else if (eingabe == 2) Console.WriteLine($"Das Maximum lautet {Maximum()}");
            else if (eingabe == 3) Console.WriteLine($"Das Median lautet {Median()}");
            else if (eingabe == 4) Console.WriteLine($"Die Spannweite lautet {Spannweite()}");
            else if (eingabe == 5) Console.WriteLine($"Die mittlere Abweichung lautet {MittlereAbweichung()}");

            return werte;
        }

        public int Minimum()
        {
            min = werte[0];
            for (int i = 0; i < werte.Length; i++)
            {
                if(min > werte[i])
                {
                    min = werte[i];
                }
            }
            return min;
        }
        public int Maximum()
        {
            max = werte[0];
            for (int i = 0; i < werte.Length; i++)
            {
                if (max < werte[i])
                {
                    max = werte[i];
                }
            }
            return max;
        }
        public int Median()
        {
            Array.Sort(werte); // Die Werte müssen sortiert sein
            mid = werte[werte.Length / 2];
            return mid;
        }

        public int Spannweite()
        {
            Minimum();
            Maximum();
            sw = max - min;
            return sw;
        }
        public int MittlereAbweichung()
        {
            int sum = 0; //speichert die Summe für den Mittelwert
            int sum2 = 0; // speichert die Summe für die mittlere Abweichung

            for (int i = 0; i < werte.Length; i++)
            {
                sum += werte[i];
            }
            int mw = sum / werte.Length; // Mittelwert Berechnung

            for (int j = 0; j < werte.Length; j++)
            {
                sum2 += werte[j]-mw;
            }
            ma = sum2/werte.Length; // mittlere Abweichung Berechnung

            return ma;
        }
    }
}
