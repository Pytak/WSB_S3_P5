using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_S3_P5
{
    class Tower<T> where T : IPrintable, IComparable<T>
    {
        private List<T> Elements;



        public int Height
        {
            get
            {
                return Elements.Count;
            }
        }

        private int Width
        {
            get
            {
                return ((this.Elements.Capacity * 2) - 1);
            }
        }



        public Tower(int height)
        {
            Elements = new List<T>(height);
        }



        public void Push(T element)
        {
            try
            {
                if (element.CompareTo(Elements.Last()) > 0)
                {
                    Elements.Add(element);
                }
                else
                {
                    throw new LargerOnSmallerElementException();
                }
            }
            catch (InvalidOperationException)
            {
                //tower is empty? any element goes
                Elements.Add(element);
            }
        }

        public T Pop()
        {
            if (Elements.Count == 0)
            {
                throw new EmptyTowerException();
            }

            T TopElement = Elements.Last();
            Elements.Remove(Elements.Last());

            return TopElement;

        }



        public void Print(int TowerID)
        {
            for (int i = Elements.Capacity; i > 0; i--)
            {
                // i = tower height, elements are 0-indexed so we need i-1 to access them

                Console.CursorLeft = (TowerID * (this.Width + 2));

                if ((i - 1) < Elements.Count)
                {
                    //have elements? draw elements
                    Elements[(i - 1)].Print();
                }
                else
                {
                    //no elements here? draw a | inside the tower
                    Console.CursorLeft += Elements.Capacity-1; //center
                    Console.Write("|");
                }

                Console.WriteLine();
            }
        }
    }
}
