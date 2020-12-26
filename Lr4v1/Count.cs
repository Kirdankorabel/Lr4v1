using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr4v1
{
    public class Count
    {
        public static int counter { get; set; }
        private static int LastNumber = 0;

        public static void CountSequences(string line)
        {
            foreach (char i in line)
            {                
                try
                {
                    int input = Int32.Parse(i.ToString());
                    if (input != LastNumber)
                    {
                        counter += 1;
                    }
                    LastNumber = input;
                }
                catch
                {
                }
            }
        }

        public static string CreatrRandomNumbers()
        {
            string st = "";
            Random random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                st += random.Next(0, 1).ToString();
            }
            return st;
        }
    }
}
