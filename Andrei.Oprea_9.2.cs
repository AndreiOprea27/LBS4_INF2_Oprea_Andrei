namespace Andrei.Oprea_9._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bubble Array = new Bubble();
            Array.werte = [5, 6, 2, 3, 1];
            
            Array.Bubblesort();
            
        }
    }

    class Bubble
    {
        public int[] werte = new int[5];
        int help; //Hilfsvariable, die beim Ersetzen nötig ist
        public int[] Bubblesort()
        {
            for(int i = 0; i < werte.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (werte[i] > werte[j])
                    {
                        help = werte[j];
                        werte[j] = werte[i];
                        werte[i] = help;
                    }
                }
            }
            foreach(int z in werte) // Die Werte in ein Array müssen einzeln ausgegeben werden
            {
                Console.WriteLine(z);
            }
            return werte;
        }
    }
}
