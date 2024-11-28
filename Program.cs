namespace Andrei.Oprea_6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CPunkt a = new CPunkt(10, 20);
            CPunkt b = new CPunkt(a);
            CPunkt c = new CPunkt();

            c.X = 30;
            c.Y = 40;

            Console.WriteLine($"Punkt B<{b.ReturnX()}|{b.ReturnY()}>");
            Console.WriteLine($"Abstand von Punkt zu <0|0>:{b.Abstand()}");
        }
    }

    class CPunkt
    {
        public double X { get; set; }
        public double Y { get; set; }
        
        public CPunkt()
        {
            
        }
        public CPunkt(CPunkt a)
        {
            X = a.X;
            Y = a.Y;
        }
        public CPunkt(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double ReturnX()
        {
            return X;
        }
        public double ReturnY()
        {
            return Y;
        }

        public double Abstand()
        {
            double a;
            a = Math.Sqrt(X * X + Y * Y);
            return a;
        }
    }

}
