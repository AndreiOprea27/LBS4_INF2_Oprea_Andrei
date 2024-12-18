namespace Oprea.Andrei._10._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte Dateinamen der zu kopierenden Datei eingeben: ");
            string copy = Console.ReadLine();
            Console.WriteLine("Bitte Dateinamen der Kopie eingeben: ");
            string paste = Console.ReadLine();

            File.Copy(copy, paste);
        }
    }
}
