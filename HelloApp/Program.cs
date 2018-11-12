using System;
using System.Threading.Tasks;

namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr1 = new int[100,100] ;
            int[,] arr2 = new int[100,100] ;

            Task<int[,]> task1 = Task.Factory.StartNew(() => FullArray(arr1));
            Task<int[,]> task2 = Task.Factory.StartNew(() => FullArray(arr2));

            //Run(() => FullArray(arr1));
            //Task<int[,]> task2 = Task.Run(() => FullArray(arr2));

            Task.WaitAny(task1, task2);
            MultiplyArray(arr1, arr2);
            Console.ReadKey();    
            
            
        }


        static int [,] FullArray(int[,] arr)
        {
            Random rnd = new Random();
            for(int i =0;i<arr.GetLength(0);i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++) arr[i, j] = rnd.Next(0, 10);
            }
            return arr;
        }

        static void MultiplyArray (int [,] arr1, int [,] arr2)
        {
            if (arr1.GetLength(1) != arr2.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] result = new int[arr1.GetLength(0), arr2.GetLength(1)];
            for (int i = 0; i<arr1.GetLength(0); i++)
            {
                for (int j=0; j<arr1.GetLength(1);j++)
                {
                    for(int k=0;k<arr1.GetLength(0);k++)
                    {
                        result[i, j] += arr1[i, k] * arr2[k, j];
                    }
                }
            }

            Print(result);
        }

        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}