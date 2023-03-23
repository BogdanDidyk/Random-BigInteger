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

        // Generates BigInteger from [start] to [end]
        public BigInteger NextBigInteger(BigInteger start, BigInteger end)
        {
            if (start == end) return start;

            BigInteger res = end;

            if (start > end)
            {
                end = start;
                start = res;
                res = end - start;
            }
            else
                res -= start;

            byte[] bs = res.ToByteArray();

            int bits = 8;
            byte mask = 0x7F;
            while ((bs[bs.Length - 1] & mask) == bs[bs.Length - 1])
            {
                bits--;
                mask >>= 1;
            }
            bits += 8 * bs.Length;

            return ((NextBigInteger(bits + 1) * res) / BigInteger.Pow(2, bits + 1)) + start;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            RandomBigInteger random = new RandomBigInteger();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(random.NextBigInteger(4));
            }

            Console.WriteLine();
            BigInteger big = random.NextBigInteger(BigInteger.Parse("111111111111111"), BigInteger.Parse("999999999999999"));
            Console.WriteLine(big);

            Console.ReadLine();
        }
    }
}