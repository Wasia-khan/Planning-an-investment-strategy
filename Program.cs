using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        double[] invest = new double[11];
        double[] returnrate = new double[11];
        public void initialization()
        {

            for (int i = 0; i < 11; i++)
            {
                invest[i] = 0;
            }

            for (int i = 0; i < 11; i++)
            {
                returnrate[i] = 0;
            }
        }
        int q;


        public double[] investment(int dollar)
        {
            double[,] r = {
            {3.92,10,32,40,51,40,45,50,51,55},
            {-2.2,-2.5,3.7,4.9,5.9,7.4,8.3,9.8,9.2,10},
            {-3.3,8.8,-9.1,14.5,15.9,18,18.9,20.3,21.5,22},
            {6,7,8,1.8,20,21,22,22.9,27,40},
            {5.5,9,14,-17,19,22,22.6,22.9,33.9,34},
        };
            double[,] dr = {
            {3000,900,3000,5500,5500,7950,9570,9550,7533,1000},
            {1000,1500,3700,5393,5393,7355,9337,9397,9339,10910},
            {1500,700,5100,1535,1539,19950,5939,3033,3135,7530},
            {3500,990,1100,1900,30100,31500,3350,3339,3700,5000},
            {5500,1900,1300,1570,1790,5500,33700,33370,3330,9000},
            };
            /* double[,] drI = {
             {2000,800,3000,4500,5500,7850,8570,9450,6532,1000},
             {1000,1500,3700,4292,5293,7245,8236,9287,9228,10910},
             {1500,600,4100,1425,1529,18950,5829,2023,2125,7530},
             {2500,980,1100,1800,20100,21400,2240,2229,2700,4000},
             {4500,1800,1200,1470,1790,5500,22600,22260,3220,8000},
             };*/



            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    dr[i, j] = dollar * r[i, j];
                    Console.WriteLine(dr[i, j]);
                }
                Console.WriteLine("\n");
            }


            int[] f = new int[] { 1200, 3200 };
            for (int k = 9; k > 1; k--)
            {
                int q = 1;
                for (int i = 1; i < 4; i++)
                {
                    if (r[i, k] > r[q, k])
                    {
                        q = i;
                    }

                }
                if (returnrate[k] + (dr[k, k] * invest[k]) - f[1] > returnrate[k] + dr[q, k] - f[2])
                {
                    returnrate[k] = returnrate[k] + dr[k, k] * invest[k] - f[1];
                    invest[k] = invest[k];
                }
                else
                {
                    returnrate[k] = returnrate[k] + dr[q, k] - f[2];
                    invest[k] = q;
                }

            }
            return invest;

        }
        static void Main(string[] args)
        {
            Program p1=new Program();
            double[] temp;
         temp= p1.investment(3500);
            Console.WriteLine(temp);
            

        }
    }
}
