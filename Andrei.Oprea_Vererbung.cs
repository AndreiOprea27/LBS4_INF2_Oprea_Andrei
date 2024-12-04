using System.Runtime.CompilerServices;

namespace UMLFahrzeug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    class Fahrzeug //jede Fahrzeug hat ein ID, Kennzeichen, Marke und ein Motor, der starten soll
    {
        public int ID { get; set; }
        public string kennzeichen { get; set; }
        public float HZG { get; set; }
        public bool motorAn { get; set; }
        public void start() { motorAn = true; }
        public void fahren() { }
        public void stopp() { motorAn = false; }

        public Fahrzeug(int id, string kennzeichen, float hzg, bool motoran)
        {
            ID = id;
            kennzeichen = this.kennzeichen;
            hzg = this.HZG;
            motoran = this.motorAn;
        }

        public class PKW : Fahrzeug //ein PKW erbt alles, was jeden Fahrzeug hat
        {
            public int tuere { get; set; }

            public PKW(int id, string kennzeichen, float hzg, bool motoran) : base(id, kennzeichen, hzg, motoran)
            {
                tuere = this.tuere;
            }
            
            public int Tueroeffnen() { return tuere++; } //bei ein geöffneten Tür steigt den Anzahl von Türe
            public int Tuerschliessen() { return tuere--; } //bei ein geschlossenen Tür sinkt den Anzahl von Türe
        }

        public class Motorrad : Fahrzeug
        {
            public bool helm { get; set; }

            public Motorrad(int id, string kennzeichen, float hzg, bool motoran) : base(id, kennzeichen, hzg, motoran)
            {
                helm = this.helm;
            }
            public void HelmAn() { helm = true; }
        }

        public class Anhaenger : Fahrzeug
        {
            public bool bremse { get; set; }

            public Anhaenger(int id, string kennzeichen, float hzg, bool motoran) : base(id, kennzeichen, hzg, motoran)
            {
                motorAn = false;
                bremse = this.bremse;
            }
            public void Anhaengen() { }
            public void Laden() { }
        }
    }
}
