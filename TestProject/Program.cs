using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Outputstr = new List<string>();
            List<string> Bufferstr = new List<string>();
            Console.WriteLine("Please enter the input value with comma seperated");
            string str = Console.ReadLine();
            string[] str_array = str.Split(',');

            for (int i = 0; i < str_array.Length; i++)
            {
                string[] A = str_array[i].Split(':');

                if (A.Length > 1 && A[0] != A[1])
                {
                    if (string.IsNullOrEmpty(A[1]) && !Outputstr.Any(a => a == A[0]))
                        Outputstr.Add(A[0]);
                   
                    else if (!string.IsNullOrEmpty(A[1]) && !Bufferstr.Any(a => a == A[0]) && !Outputstr.Any(a => a == A[0]))
                    {
                        Bufferstr.Add(A[0]);
                    }
                    else if (!string.IsNullOrEmpty(A[1]) && !Bufferstr.Any(a => a == A[0]))
                    {
                        Outputstr.Remove(A[0]);
                        Bufferstr.Add(A[0]);
                    }
                    if (!string.IsNullOrEmpty(A[1]) && !Bufferstr.Any(a => a == A[1]) && !Outputstr.Any(a => a == A[1]))
                    {
                        Outputstr.Add(A[1]);
                    }
                }
            }

            if(Outputstr.Count == 0 && Bufferstr.Count > 0)
            {
                Console.WriteLine("Input that should be rejected due to the cycle.");
            }
            else if (Bufferstr.Count == 0)
            {
                Console.WriteLine("Output is: " + string.Join(",", Outputstr));
            }
            else
            {
                Console.WriteLine("Output is: " + string.Join(",", Outputstr) + "," + string.Join(",", Bufferstr));
            }
            Console.ReadKey();
        }
    }
}
