using System;
using System.Collections.Generic;

namespace Find_the_largest_subarray_formed_by_consecutive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 2, 0, 2, 1, 4, 3, 1, 0 };

            findMaxSubarray(A);
        }

        public static void findMaxSubarray(int[] A)
        {
            int longest = 0;
            int len = A.Length;
            int start = 0;
            int end = 0;
            for (int i = 0; i <len ; i++)
            {
                int min = int.MaxValue;
                int max = int.MinValue;
                
                List<int> L = new List<int>();
                for (int j = 0; j < len; j++)
                {
                    max = Math.Max(A[j], max);
                    min = Math.Min(A[j] ,min);

                    if (L.Contains(A[j]))
                    {
                        if(j-i-1>longest)
                        {
                            if (check(A, max, min, i, j-1))
                            {
                                longest =j-i-1;
                                start = i;
                                end = j-1;
                            }
                        }
                        L.Clear();
                    }
                    else
                        L.Add(A[j]);
                }
                
            }
            Console.WriteLine(start + "," + end);
        }

        public static  bool check(int[] arr, int max, int min, int i , int j)
        {
            if (max - min != j-i)
                return false;

            return true;
        }
    }
}
