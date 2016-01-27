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

        static void DrawTowers(){
            for (int i = 0; i < 3; i++)
            {
                Towers[i].Print(i);
                Console.CursorTop = 0;
            }   
        }
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Zadania05 - Marcin Ptak");


            Console.Write("Podaj wysokość wieży: ");
            int UserHeight;
            while (!int.TryParse(Console.ReadLine(), out UserHeight))
            {
                if (UserHeight < 3)
                {
                    Console.Clear();
                    Console.Write("Wysokość musi być liczbą większą od 3: ");
                }
            };


            Console.Clear();


            InitializeTowers(UserHeight);



            DrawTowers();
            

                Console.ReadLine();
        }
    }
}
