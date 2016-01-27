using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_S3_P5
{
    class Program
    {
        static Tower<Disk>[] Towers = new Tower<Disk>[3];


        static void InitializeTowers(int TowerHeight)
        {
            for (int i = 0; i < 3; i++)
            {
                Towers[i] = new Tower<Disk>(TowerHeight);
            }

            for (int i = TowerHeight; i > 0; i--)
            {
                Towers[0].Push(new Disk(i, TowerHeight));
            }
        }

        static void DrawTowers()
        {
            Console.CursorTop = 0;
            for (int i = 0; i < 3; i++)
            {
                Towers[i].Print(i);
                Console.CursorTop = 0;
            }
        }

        private static int CheckRangeFromKB(int Min, int Max)
        {
            int ValidInt;
            while (true)
            {
                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out ValidInt))
                {
                    if (ValidInt >= Min && ValidInt <= Max)
                    {
                        break;
                    }
                }
                Console.Write(" (" + Min + "-" + Max + ")  ");
                Console.CursorLeft -= 9;
            }
            return ValidInt;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Zadania05 - Marcin Ptak");


            Console.Write("Podaj wysokość wieży: ");
            int UserHeight = CheckRangeFromKB(3, 9);


            InitializeTowers(UserHeight);


            int Next;
            Disk CurrentDisk;
            while (true)
            {
                Console.Clear();
                DrawTowers();

                Console.CursorTop = UserHeight;

                Console.Write("Przenieś z:  ");
                Next = CheckRangeFromKB(1, 3);

                CurrentDisk = Towers[Next - 1].Pop();

                Console.CursorLeft = 0;

                Console.Write("Przenieś do: ");
                Next = CheckRangeFromKB(1, 3);

                Towers[Next - 1].Push(CurrentDisk);
            }


            Console.ReadLine();
        
        }

    }
}
