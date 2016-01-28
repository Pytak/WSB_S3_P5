using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_S3_P5
{
    class Program
    {
        private static Tower<Disk>[] Towers = new Tower<Disk>[3];
        private static int Score = 0;
        private static int UserHeight = 0;

        private static int From, To;
        private static Disk CurrentDisk;


        private static void InitializeTowers(int TowerHeight)
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

        private static void DrawTowers()
        {   
            Console.CursorTop = 0;
            for (int i = 0; i < 3; i++)
            {
                Towers[i].Print(i);
                Console.CursorTop = 0;
            }
        }

        private static void DrawScore()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = UserHeight + 1;
            Console.WriteLine("Ruchy: " + Score);
        }

        private static int CheckRangeFromKB(int Min, int Max)
        {
            int ValidInt;
            while (true)
            {
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out ValidInt))
                {
                    if (ValidInt >= Min && ValidInt <= Max)
                    {
                        break;
                    }
                }
                Console.Write(" (" + Min + "-" + Max + ")  ");
                Console.CursorLeft -= 8;
            }
            return ValidInt;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Zadania05 - Marcin Ptak");


            Console.Write("Podaj wysokość wieży: ");
            UserHeight = CheckRangeFromKB(3, 9);
            Console.Clear();

            InitializeTowers(UserHeight);


            
            while (true)
            {
                DrawTowers();
                DrawScore();

                if (Towers[2].Height == UserHeight)
                {
                    break;
                }

                Console.CursorTop = UserHeight;

                Console.Write("Przenieś z:  ");
                From = CheckRangeFromKB(1, 3);

                try { CurrentDisk = Towers[From - 1].Pop(); }
                catch (EmptyTowerException)
                {
                    Console.Write("(Pusto!)");
                    continue;
                }
                finally
                {
                    Console.Write("        ");
                }

                Console.CursorLeft = 0;

                Console.Write("Przenieś do: ");
                To = CheckRangeFromKB(1, 3);

                try { Towers[To - 1].Push(CurrentDisk); }
                catch (LargerOnSmallerElementException)
                {
                    Console.Write("(Źle!)");
                    Towers[From - 1].Push(CurrentDisk);
                    continue;
                }

                Score++;

                Console.Clear();
            }

            Console.Write("Udało się! Naciśnij dowolny klawisz, by wyjść.");

            Console.ReadKey();

        }

    }
}
