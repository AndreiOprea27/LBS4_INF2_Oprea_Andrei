namespace Andrei.Oprea_7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CElefant e = new CElefant("Elefant", 30);
            e.Name = "Elefant";
            e.Geschwindigkeit = 30;

            CNashorn n = new CNashorn("Nashorn", 20);
            n.Name = "Nashorn";
            n.Geschwindigkeit = 20;

            CDelfin d = new CDelfin("Delfin", 500);
            d.Name = "Delfin";
            d.Tauchzeit = 500;

            CWal w = new CWal("Wal", 800);
            w.Name = "Wal";
            w.Tauchzeit = 800;

            CTier t;
            t = e;
            Console.WriteLine(t.Steckbrief());
            t = n;
            Console.WriteLine(t.Steckbrief());
            t = d;
            Console.WriteLine(t.Steckbrief());
            t = w;
            Console.WriteLine(t.Steckbrief());
        }
    }

    interface Geschwindigkeit
        {
            int Geschwindigkeit { get; set; }
        }
    interface Tauchzeit
    {
        int Tauchzeit { get; set; }
    }
    abstract class CTier : Geschwindigkeit, Tauchzeit
    {
        public string Name { get; set; }

        private int _geschwindigkeit;
        public int Geschwindigkeit
        {
            get { return _geschwindigkeit; }
            set { _geschwindigkeit = value; }
        }

        private int _tauchzeit;
        public int Tauchzeit
        {
            get { return _tauchzeit; }
            set { _tauchzeit = value; }
        }

        
        public CTier(string name, int geschwindigkeit)
        {
            name = this.Name;
            geschwindigkeit = Geschwindigkeit;
        }
        public string Steckbrief()
        {
            string benennung, gsw, tz;
            
            benennung = $"Name des Tieres: {Name}\n";
            if (Geschwindigkeit == 0) gsw = null;
            else gsw = $"Geschwindigkeit: {Geschwindigkeit}\n";
            if (Tauchzeit == 0) tz = null;
            else tz = $"Tauchzeit: {Tauchzeit}\n";
            return benennung + gsw + tz;
        }
    }
    class CElefant : CTier 
    {
        public CElefant(string name, int geschwindigkeit) : base(name, geschwindigkeit) { }
    }
    class CNashorn : CTier
    {
        public CNashorn(string name, int geschwindigkeit) : base(name, geschwindigkeit) { }
    }
    class CDelfin : CTier
    {
        public CDelfin(string name, int tauchzeit) : base(name, tauchzeit) { }
    }
    class CWal : CTier
    {
        public CWal(string name, int tauchzeit) : base(name, tauchzeit) { }
    }

}
