// Yousef Hassan Elsayed Ahmed Eldesoky

using System;
using System.Linq;

namespace ConsoleApp7
{
    internal class Program
    {
        // Outliers
        static bool isOutlier(int[] myArray, int n)
        {
            Array.Sort(myArray);
            int m = myArray.Length;
            int index_of_q1 = (m + 1) * (1 / 4);
            int q1 = myArray[index_of_q1];
            int index_of_q3 = (m * 3 / 4);
            int q3 = myArray[index_of_q3];
            int IQR = q3 - q1;
            double left_limit = (q1) - 1.5 * IQR;
            double right_limit = (q3) + 1.5 * IQR;
            return (n < left_limit || n > right_limit);
        }

        // Mode
        static void PrintMode(int[] values, int n)
        {
            int max = values.Max();
            int[] count = new int[max + 1];
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                count[values[i]]++;
            }
            int mode = 0;
            int maxCount = 0;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > maxCount)
                {
                    maxCount = count[i];
                    mode = i;
                }
            }
            Console.WriteLine("Mode = " + mode);
        }





        static void Main(string[] args)
        {
            Console.Write("Enter the number of items: ");
            int n = int.Parse(Console.ReadLine());
            int[] values = new int[n];
            Console.WriteLine("Enter the items values:");
            for (int i = 0; i < n; i++)
            {
                values[i] = int.Parse(Console.ReadLine());
            }

            // Mode
            PrintMode(values, n);
            Console.ReadKey();

            // Median
            double median = 0;
            if (n % 2 == 0)
            {
                median = (values[n / 2] + values[n / 2 - 1]) / 2.0;
            }
            else
            {
                median = values[n / 2];
            }
            Console.WriteLine("Median: {0}", median);

            // Range  
            double range = values.Last() - values.First();
            Console.WriteLine("Range: {0}", range);

            // Quartiles
            int mid = n / 2;
            double q1 = 0, q3 = 0;
            if (n % 2 == 0)
            {
                q1 = (values[mid / 2] + values[mid / 2 - 1]) / 2;
                q3 = (values[mid + mid / 2] + values[mid + mid / 2 - 1]) / 2;
            }
            else
            {
                q1 = values[mid / 2];
                q3 = values[mid + mid / 2];
            }
            Console.WriteLine("Q1: {0}", q1);
            Console.WriteLine("Q3: {0}", q3);

            // P90
            double p90 = values[(int)(n * 0.9)];
            Console.WriteLine("P90: {0}", p90);

            // Interquartile range
            double iq = q3 - q1;
            Console.WriteLine("Interquartile range: {0}", iq);

            // Outliers
            int num = 85;
            int[] arr = { 25, 29, 3, 32, 85, 33, 27, 28 };
            bool result = isOutlier(arr, num);
            Console.WriteLine($"Is the number {num} an outlier value? {result}");
            Console.ReadKey();




        }
    }
}