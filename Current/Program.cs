using System;
using System.Diagnostics;
using System.Threading;

namespace Current
{
    class Program
    {
        static  LimitService l = new LimitService(1000, 1);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
             int threadCount = 50;
            while (threadCount >= 0)
            {
                Thread t = new Thread(s =>
                {
                    Limit();
                });
                t.Start();
                threadCount--;
            }           

            Console.Read();
        }

         static void Limit()
        {
            int i = 0;
            int okCount = 0;
            int noCount = 0;
            Stopwatch w = new Stopwatch();
            w.Start();
            while (i < 1000000)
            {
                var ret = l.IsContinue();
                if (ret)
                {
                    okCount++;
                }
                else
                {
                    noCount++;
                }
                i++;
            }
            w.Stop();
            Console.WriteLine($"共用{w.ElapsedMilliseconds},允许：{okCount},  拦截：{noCount}");
        }

    }
}
