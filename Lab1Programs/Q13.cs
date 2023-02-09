using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q13
    {
        static bool[] Sieve(int n)
        {
            bool[] isPrime = new bool[n + 1];
            for(int i = 0; i <= n; i++)
            {
                isPrime[i] = true;
            }
            isPrime[0] = false; isPrime[1] = false;
            for(int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    for(int j = i + i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
                
            }
            return isPrime;
        }
        static void Main()
        {
            // Sum of prime numbers from n to m

            //Get input
            Console.WriteLine("Enter first number: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int m = int.Parse(Console.ReadLine());

            //Sieve algo
            bool[] primes = Sieve(m);
            int sum = 0;
            for(int i=n;i<=m;i++)
            {
                if (primes[i]) Console.Write(i + ", ");
                sum += i;
            }
            Console.WriteLine("\b\b  ");
            Console.WriteLine("Sum : "+sum);
        }
    }
}
