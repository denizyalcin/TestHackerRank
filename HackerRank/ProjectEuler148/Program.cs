using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler148
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(NonDiversibleItemCount(100,50, 7));
            //PrintPascalTriangleItemValue(17);

            Console.ReadLine();
        }

        static int NonDiversibleItemCount(int x, int y, int d)
        {
            int result = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y && j <= i; j++)
                {
                    //int value = (int)CalculatePascalTriangleItemValue(i, j);
                 
                    //if (value < d)
                    //{
                    //    result++;
                    //}
                    //else if (value % d != 0)
                    //{
                    //    result++;
                    //}

                    //if (value % d == 0)
                    //{

                    //}
                    if (!IsDividablePermutation(i, j, d))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        static void PrintPascalTriangleItemValue(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(CalculatePascalTriangleItemValue(i, j) + " ");
                }
                Console.WriteLine("");
            }
        }

        static double CalculatePascalTriangleItemValue(int n, int k)
        {
            if (k == 0)
            {
                return 1;
            }
            return CalculatePermutation(n - 1, k - 1) + CalculatePermutation(n - 1, k);
        }

        static double CalculatePermutation(int n, int k)
        {
            if (k == 0)
            {
                return 1;
            }
            List<int> nList = new List<int>();
            List<int> kList = new List<int>();

            int i = 0;
            for (i = 0; i < k; i++)
            {
                nList.Add(n - i);
                kList.Add(k - i);
            }

            int j = 0;
            i = 0;

            while (j < k)
            {
                if (i >= k)
                {
                    break;
                }

                if (nList[i] % kList[j] == 0)
                {
                    nList[i] = (int)(nList[i] / kList[j]);
                    kList[j] = 1;
                    j++;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            double result = 1;
            nList.ForEach(x => { result *= x; });
            kList.ForEach(x => { result /= x; });

            return result;
        }

        static bool IsDividablePermutation(int n, int k, int d)
        {
            if (k == 0)
            {
                return false;
            }

            int divisiblen = 0;
            int divisiblek = 0;

            for (int i = 0; i < k; i++)
            {
                if ((n - i) % d == 0)
                {
                    divisiblen++;
                }

                if ((k - i) % d == 0)
                {
                    divisiblek++;
                }
            }

            return divisiblen > divisiblek;


        }

    }
}
