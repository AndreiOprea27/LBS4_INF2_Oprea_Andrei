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
            Console.WriteLine(t.Landtier());
            Console.WriteLine(t.Kamera());
            Console.WriteLine();
            t = n;
            Console.WriteLine(t.Steckbrief());
            Console.WriteLine(t.Landtier());
            Console.WriteLine(t.Kamera());
            Console.WriteLine();
            t = d;
            Console.WriteLine(t.Steckbrief());
            Console.WriteLine(t.Wassertier());
            Console.WriteLine(t.Kamera());
            Console.WriteLine();
            t = w;
            Console.WriteLine(t.Steckbrief());
            Console.WriteLine(t.Wassertier());
            Console.WriteLine(t.Kamera());
            Console.WriteLine();
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
            string benennung;
            
            benennung = $"Name des Tieres: {Name}";
            return benennung;
        }

        public string Landtier()
        {
            string gsw;
            if (Geschwindigkeit == 0) gsw = null;
            else gsw = $"Geschwindigkeit: {Geschwindigkeit}";
            return gsw;
        }
        public string Wassertier()
        {
            string tz;
            if (Tauchzeit == 0) tz = null;
            else tz = $"Tauchzeit: {Tauchzeit}";
            return tz;
        }
        virtual public string Kamera()
        {
            return "*schaut in die Kamera*";
        }
    }
    class CElefant : CTier 
    {
        public CElefant(string name, int geschwindigkeit) : base(name, geschwindigkeit) { }
        /// <summary>
        /// Was die Kamera Methode für den Elefant macht
        /// </summary>
        /// <returns>spezielle Text des Elefantes</returns>
        public override string Kamera()
        {
            return "*badet sich im Sicht der Kamera*";
        }
    }
    class CNashorn : CTier
    {
        public CNashorn(string name, int geschwindigkeit) : base(name, geschwindigkeit) { }
        /// <summary>
        /// Was die Kamera für den Nashorn macht
        /// </summary>
        /// <returns>spezielle Text des Nashorns</returns>
        public override string Kamera()
        {
            return "*läuft zur Kamera*";
        }

    }
    class CDelfin : CTier
    {
        public CDelfin(string name, int tauchzeit) : base(name, tauchzeit) { }
        /// <summary>
        /// Was die Kamera für den Delfin macht
        /// </summary>
        /// <returns>spezielle Text des Delfins</returns>
        public override string Kamera()
        {
            return "*spielt mit die Kamera*";
        }
    }
    class CWal : CTier
    {
        public CWal(string name, int tauchzeit) : base(name, tauchzeit) { }
        /// <summary>
        /// Was die Kamera für die Wal macht
        /// </summary>
        /// <returns>spezielle Text der Wal</returns>
        public override string Kamera()
        {
            return "*ignoriert die Kamera*";
        }
    }

}
