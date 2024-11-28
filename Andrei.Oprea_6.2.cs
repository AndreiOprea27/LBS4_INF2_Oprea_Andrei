namespace Andrei.Oprea_6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie ein Zahl ein:");
            CZahl z = new CZahl();
            z.Spell();
        }
    }

    class CZahl
    {
        public int h {  get; set; }
        public int z {  get; set; }
        public int e {  get; set; }
        public string spell {  get; set; }

        public CZahl()
        {
            int zahl = Convert.ToInt32(Console.ReadLine());
            h = zahl / 100;
            zahl = zahl % 100;
            z = zahl / 10;
            e = zahl % 10;
        }
        public string ZahlInWort(int zahl) //die hunderter und einser verwenden die gleiche Zahlen
        {
            switch (zahl)
            {
                case 1: return "eins";
                case 2: return "zwei";
                case 3: return "drei";
                case 4: return "vier";
                case 5: return "fuenf";
                case 6: return "sechs";
                case 7: return "sieben";
                case 8: return "acht";
                case 9: return "neun";
                
                default: return "unbekannt";
            }
        }
        public string ZehnerInWort(int zahl) //die Zehner brauchen andere Namenmethoden
        {
            switch (zahl)
            {
                case 1: return "zehn";
                case 2: return "zwanzig";
                case 3: return "dreissig";
                case 4: return "vierzig";
                case 5: return "fuenfzig";
                case 6: return "sechzig";
                case 7: return "siebzig";
                case 8: return "achzig";
                case 9: return "neunzig";

                default: return "unbekannt";
            }
        }
        public string ZehnInWort(int zahl) //von 10 bis 19 haben die Zahlen besondere Bennenungen, insbesonders 11 und 12
        {
            switch (e)
            {
                case 1: return "elf";
                case 2: return "zwoelf";
                case 3: return "dreizehn";
                case 4: return "vierzehn";
                case 5: return "fuenfzehn";
                case 6: return "sechzehn";
                case 7: return "siebzehn";
                case 8: return "achzehn";
                case 9: return "neunzehn";

                default: return "unbekannt";
            }
        }

        public string Spell()
        {
            int zahl = h * 100 + z * 10 + e;
            if (zahl < 0 || zahl > 999) Console.WriteLine("Dein Zahl ist zu gross oder zu klein");
            else
            {
                if (h != 0 && h != 1) //checkt die Zahlen, hat Optionen für jede Möglichkeit, die Änderungen verlangt
                {
                    if (z != 1 && z != 0)
                    {
                        if (e != 0) spell = $"{ZahlInWort(h)}hundert {ZahlInWort(e)}und{ZehnerInWort(z)}";
                        else spell = $"{ZahlInWort(h)}hundert {ZehnerInWort(z)}";
                    }
                    else if (z == 1)
                    {
                        if (e != 0) spell = $"{ZahlInWort(h)}hundert {ZehnInWort(e)}";
                        else spell = $"{ZahlInWort(h)}hundert {ZehnerInWort(z)}";
                    }
                    else
                    {
                        if (e != 0) spell = $"{ZahlInWort(h)}hundert {ZahlInWort(e)}";
                        else spell = $"{ZahlInWort(h)}hundert";
                    }
                }
                else if (h == 1)
                {
                    if (z != 1 && z != 0)
                    {
                        if (e != 0) spell = $"hundert {ZahlInWort(e)}und{ZehnerInWort(z)}";
                        else spell = $"hundert {ZehnerInWort(z)}";
                    }
                    else if (z == 1)
                    {
                        if (e != 0) spell = $"hundert {ZehnInWort(e)}";
                        else spell = $"hundert {ZehnerInWort(z)}";
                    }
                    else
                    {
                        if (e != 0) spell = $"hundert {ZahlInWort(e)}";
                        else spell = $"hundert";
                    }
                }
                else
                {
                    if (z != 1 && z != 0)
                    {
                        if (e != 0) spell = $"{ZahlInWort(e)}und{ZehnerInWort(z)}";
                        else spell = $"{ZehnerInWort(z)}";
                    }
                    else if (z == 1)
                    {
                        if (e != 0) spell = $"{ZehnInWort(e)}";
                        else spell = $"{ZehnerInWort(z)}";
                    }
                    else
                    {
                        if (e != 0) spell = $"{ZahlInWort(e)}";
                        else spell = "null";
                    }
                }
                Console.WriteLine(spell);
            }
            return spell;
        }
    }
}
