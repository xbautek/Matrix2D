

namespace Matrix2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Matrix2D a = new(1, 2, 5, 6);

            a.Det();






            int[,] nowa2 = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            // var x = (Matrix2D)nowa2;
            var x = (Matrix2D)nowa2;
            // Console.WriteLine(x);
            Console.WriteLine(nowa2);
            foreach (var v in nowa2)
            {
                Console.Write($"{v} ");
            }

            
        }
    }
}