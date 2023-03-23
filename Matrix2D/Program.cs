namespace Matrix2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Matrix2D a = new(1, 2, 5, 6);

            a.Det();
            
            var b = Matrix2D.Determinant(a);
            Console.WriteLine(b);
        }
    }
}