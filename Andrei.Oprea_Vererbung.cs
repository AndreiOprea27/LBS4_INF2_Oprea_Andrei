using System.Runtime.CompilerServices;

namespace UMLFahrzeug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fahrzeug a = new Fahrzeug(1, "S 100 IN", 1550, false); // die Werte von die Testfahrzeuge werden angegeben und dann weitergegeben
            a.ID = 1;
            a.kennzeichen = "S 100 IN";
            a.HZG = 1550;
            a.motorAn = false;
            Console.WriteLine(a.ShowFahrzeug());

            Fahrzeug.PKW b = new Fahrzeug.PKW(1, "S 100 IN", 1550, false); // die Funktion Fahrzeug braucht Anfangswerte, aber diese Werte müssen definiert sein, falls man sie verweden will
            b.ID = 1;
            b.kennzeichen = "S 100 IN";
            b.HZG = 1550;
            b.motorAn = false;
            b.tuere = 2;
            Console.WriteLine (b.ShowTuere());

            Fahrzeug.Motorrad c = new Fahrzeug.Motorrad(2, "S 200 IN", 550, false);
            c.ID = 2;
            c.kennzeichen = "S 200 IN";
            c.HZG = 550;
            c.motorAn = false;
            c.helm = true;
            Console.WriteLine(c.ShowHelm());

            Fahrzeug.Anhaenger d = new Fahrzeug.Anhaenger(3, "S 300 IN", 550, false);
            d.ID = 3;
            d.kennzeichen = "S 300 IN";
            d.HZG = 550;
            d.bremse = false;
            Console.WriteLine(d.ShowBremse());
        }
    }

    class Fahrzeug //jede Fahrzeug hat ein ID, Kennzeichen, Marke und ein Motor, der starten soll
    {
        public int ID { get; set; }
        public string kennzeichen { get; set; }
        public float HZG { get; set; }
        public bool motorAn { get; set; }
        public void Start() { motorAn = true; }
        public void Fahren() { }
        public void Stopp() { motorAn = false; }

        public Fahrzeug(int id, string kennzeichen, float hzg, bool motoran)
        {
            ID = id;
            kennzeichen = this.kennzeichen;
            hzg = this.HZG;
            motoran = this.motorAn;
        }

        public string ShowFahrzeug()
        {
            string auto = $"Ein Fahrzeug mit die Kennzeichen {kennzeichen} und die HZG {HZG}";
            return auto;
        }

        public class PKW : Fahrzeug //ein PKW erbt alles, was jeden Fahrzeug hat
        {
            public int tuere { get; set; }

            public PKW(int id, string kennzeichen, float hzg, bool motoran) : base(id, kennzeichen, hzg, motoran) // hier wird es definiert, was ein Objekt von der Klasse erbt
            {
                tuere = this.tuere;
            }
            
            public int Tueroeffnen() { return tuere++; } //bei ein geöffneten Tür steigt den Anzahl von Türe
            public int Tuerschliessen() { return tuere--; } //bei ein geschlossenen Tür sinkt den Anzahl von Türe

            public string ShowTuere()
            {
                string showtuere = $"Das Fahrzeug mit die Kennzeichen {kennzeichen} hat {tuere} Türe geöffnet";
                return showtuere;
            }
        }

        public class Motorrad : Fahrzeug
        {
            public bool helm { get; set; }

            public Motorrad(int id, string kennzeichen, float hzg, bool motoran) : base(id, kennzeichen, hzg, motoran)
            {
                helm = this.helm;
            }
            public void HelmAn() { helm = true; }
            public string ShowHelm()
            {
                string showhelm;
                if (helm == true) showhelm = $"Der Fahrer des Motorrads mit die Kennzeichen {kennzeichen} hat sein Helm an, deswegen darf er fahren";
                else showhelm = $"Der Fahrer des Motorrads mit die Kennzeichen {kennzeichen} hat sein Helm nicht an, deswegen darf er nicht fahren";
                return showhelm;
            }
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

            public string ShowBremse()
            {
                string showbremse;
                if (bremse == true) showbremse = $"Der Anhänger mit die Kennzeichen {kennzeichen} ist ein schweren Anhänger";
                else showbremse = $"Der Anhänger mit die Kennzeichen {kennzeichen} ist ein leichten Anhänger";
                return showbremse;
            }
        }
    }
}
