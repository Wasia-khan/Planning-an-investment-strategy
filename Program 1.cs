using System;

namespace ConsoleApp2
{
    class Program
    {
        public static void INVEST(int d, int n,Double[,] r)
        {
            Double[] I = new Double[11], R = new Double[11];
            for (int i = 0; i < I.Length; i++)
            {
                I[i] = 0;
                R[i] = 0;
            }            

            for (int k = 9; k >= 0; k--)
            {
                int q = 1;
                for (int i = 1; i <= n; i++)
                {
                    if (r[i, (k + 1)] > r[q, (k + 1)])    // i now holds the investment which looks best for a given year
                    {
                        q = i;
                    }
                }
                
                int[] f = new int[] { 1000, 2000 }; //fees of moving money in same investment and for switching investment in next year
                
                if (R[k + 1] + d * r[(int)I[k + 1], k + 1] - f[0] > R[k + 1] + d * r[q, k + 1] - f[1])  // If revenue is greater when money is not moved
                {
                    R[k] = R[k + 1] + d * r[(int)I[k + 1], k + 1] - f[0];
                    I[k] = I[k + 1];
                }
                else
                {
                    R[k] = R[k + 1] + d * r[q, k + 1] - f[1];
                    I[k] = q;
                }
            }
            Console.WriteLine("optmal strategy is ");
            for (int i = 0; i < I.Length - 1; i++)
            {
                Console.WriteLine(" I" + (i+1) + "= " + I[i]);            
            }
            Console.WriteLine("\nreturn "+R[0]);
            //return I as an optimal stategy with return R[0].

        }
        static void Main(string[] args)
        {
            Double[,] r = new Double[,] //retur rates of investment i in year j
             {
                { 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0} ,
                { 0, 0.14, 0.2,  0.3,  0.15, 0.31, 0.28, 0.5,  0.41, 0.43, 0.33} ,
                { 0, 0.6,  0.53, 0.5,  0.45, 0.9,  0.4,  0.55,  0.41, 0.13, 0.15} ,
                { 0, 0.88, 0.74, 0.78, 0.69, 0.75, 0.69, 0.4,  0.45, 0.79, 0.9} ,
                { 0, 0.3,  0.35, 0.4,  0.6,  0.65, 0.53, 0.4,  0.29, 0.13, 0.5} ,
                { 0, 0.41, 0.5,  0.44, 0.79, 0.34, 0.43, 0.6,  0.38, 0.28, 0.3} ,
                { 0, 0.5,  0.4,  0.6,  0.52, 0.6,  0.75, 0.4,  0.59, 0.7,  0.79} ,
                { 0, 0.6,  0.65, 0.55, 0.39, 0.51, 0.6,  0.52, 0.41, 0.6,  0.63} ,
                { 0, 0.65, 0.5,  0.42, 0.51, 0.7,  0.2,  0.79, 0.71, 0.55, 0.4} ,
                { 0, 0.51, 0.55, 0.65, 0.49, 0.3,  0.41, 0.39, 0.29, 0.13, 0.3} ,
                { 0, 0.75, 0.87, 0.68, 0.71, 0.75, 0.64, 0.4,  0.32, 0.3,  0.4}
             };
            INVEST(10000, 10, r);
            Console.ReadLine();
        }
    }
}