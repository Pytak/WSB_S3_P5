using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_S3_P5
{
    class Disk : IPrintable, IComparable<Disk>
    {
        private int Width;
        private int TowerHeight;

        public Disk(int Width, int TowerHeight)
        {
            this.Width = Width;
            this.TowerHeight = TowerHeight;
        }

        public void Print()
        {
            Console.CursorLeft += (this.TowerHeight - this.Width);
            for (int i = 0; i < (this.Width*2 - 1); i++)
            {
                
                if (i > (this.Width - 2))
                {
                    Console.Write("▓");
                }
                else
                {
                    Console.Write("▒");
                }
            }
            
        }

        public int CompareTo(Disk o)
        {
            return (o.Width -this.Width);
        }
    }
}
