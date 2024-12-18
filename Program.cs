using System.Linq.Expressions;

namespace Oprea.Andrei._10._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ein;
            Console.WriteLine("Bitte den Dateinamen eingeben: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hier ist der Daten-Inhalt: ");

            System.IO.FileStream lesen = new System.IO.FileStream($"{name}.txt", System.IO.FileMode.Open);
                
            do
            {
                ein = lesen.ReadByte();
                if (ein != -1) Console.Write((char)ein);
            }
            while (ein != -1);
            Console.WriteLine();
            lesen.Close();
        }
    }
}
