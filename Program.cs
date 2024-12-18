using static System.Net.Mime.MediaTypeNames;

namespace Oprea.Andrei._10_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ausgabe(0);
        }

        static public void Ausgabe(int zaehler)
        {
            string[] verzeichnisse;
            string test = Directory.GetCurrentDirectory();

            verzeichnisse = Directory.GetDirectories(test);

            if(zaehler < 5)
            {
                foreach (string v in verzeichnisse)
                {
                    Console.WriteLine(v);
                    verzeichnisse = Directory.GetDirectories(v);
                    Ausgabe(zaehler + 1);
                }
                
            }
            
        }
    }
}
