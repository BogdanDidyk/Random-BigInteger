using System.Numerics;

namespace RandomBigInteger
{
    public class RandomBigInteger : Random
    {
        public RandomBigInteger() : base()
        {

        }

        public RandomBigInteger(int seed) : base(seed)
        {

        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("There is no \"Hello, World!\"");

            Console.ReadLine();
        }
    }
}