namespace Oprea.Andrei._10_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ausgabe("net8.0");
        }

        static public void Ausgabe(string folder)
        {
            string[] verzeichnisse;
            folder = Directory.GetCurrentDirectory();

            verzeichnisse = Directory.GetDirectories(folder);

            foreach (string v in verzeichnisse)
            {
                Console.WriteLine(v);
                verzeichnisse = Directory.GetDirectories(folder);
                Ausgabe(v);
            }
        }
    }
}
