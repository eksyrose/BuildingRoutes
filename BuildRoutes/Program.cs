using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildRoutes
{
    class Program
    {
        static void Main(string[] args)
        {
            Path[] paths = new Path[6];
            paths[0] = new Path("Москва", "Тюмень"); 
            paths[1] = new Path("Тюмень", "Сочи");
            paths[2] = new Path("Ростов-на-Дону", "Москва");
            paths[3] = new Path("Сочи", "Махачкала");
            paths[4] = new Path("Азов", "Ростов-на-Дону");
            paths[5] = new Path("Аксай", "Азов");
            RouteBuilder rb = new RouteBuilder();

            foreach (String s in rb.BuildRoute(paths))
                Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
