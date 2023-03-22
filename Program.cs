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

        // Generates BigInteger from 0 to 2^bitLength
        public BigInteger NextBigInteger(int bitLength)
        {
            if (bitLength < 1) return BigInteger.Zero;

            int bytes = bitLength / 8;
            int bits = bitLength % 8;

            byte[] bs = new byte[bytes + 1];
            NextBytes(bs);

            byte mask = (byte)(0xFF >> (8 - bits));
            bs[bs.Length - 1] &= mask;

            return new BigInteger(bs);
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