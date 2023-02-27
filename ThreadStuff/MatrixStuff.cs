﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadStuff
{
    class MatrixStuff
    {
        static int ROWS = 10000;
        static int COL = 10000;
        static void Main(string[] args)
        {
            Console.WriteLine("Matrix Multiplication App");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            int[,] m1 = new int[ROWS, COL];
            int[,] m2 = new int[ROWS, COL];

            // initialize the matrix
            Console.WriteLine("Initializing the matrix...");
            Random rnd = new Random();

            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COL; c++)
                {
                    m1[r, c] = rnd.Next(1, 99);
                    m2[r, c] = rnd.Next(1, 99);
                }
            }
            Console.WriteLine("done");
            // multiply the matrix
            Console.WriteLine("multiplying the matrix");
            Stopwatch sw = Stopwatch.StartNew();
            var result = Multiply(m1, m2);
            Console.WriteLine($"Multiplying took {sw.ElapsedMilliseconds} ms");

            Console.WriteLine("multiplying the matrix parallelly");
            sw.Restart();
            result = MultiplyParallel(m1, m2);
            Console.WriteLine($"Multiplying Parallel took {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("multiplying the matrix fully parallelly");
            sw.Restart();
            result = MultiplyParallel(m1, m2);
            Console.WriteLine($"Multiplying Parallel took {sw.ElapsedMilliseconds} ms");
        }

        public static int[,] Multiply(int[,] m1, int[,] m2)
        {
            int[,] result = new int[ROWS, COL];
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COL; c++)
                {
                    result[r, c] = m1[r, c] * m2[r, c];
                }
            }
            return result;
        }

        public static int[,] MultiplyParallel(int[,] m1, int[,] m2)
        {
            int[,] result = new int[ROWS, COL];
            //for (int r = 0; r < ROWS; r++)
            Parallel.For(0, ROWS, r =>
            {
                for (int c = 0; c < COL; c++)
                {
                    result[r, c] = m1[r, c] * m2[r, c];
                }
            });
            return result;
        }
        public static int[,] MultiplyParallelDouble(int[,] m1, int[,] m2)
        {
            int[,] result = new int[ROWS, COL];
            //for (int r = 0; r < ROWS; r++)
            Parallel.For(0, ROWS*COL, r =>
            {
                result[r%ROWS, r/ROWS] = m1[r % ROWS, r / ROWS] * m2[r % ROWS, r / ROWS];
            });
            return result;


            // 5*4   0 1 2 4 3 5 6
            //       0
        }
    }
}
