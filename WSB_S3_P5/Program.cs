using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_S3_P5
{
    class Program
    {
        static void Main(string[] args)
        {
            Tower<Disk> TestTower = new Tower<Disk>(5);

            TestTower.Print(1);
            Console.CursorTop = 0;
            TestTower.Print(2);
            Console.CursorTop = 0;
            TestTower.Print(3);

            Console.ReadLine();
        }
    }
}
