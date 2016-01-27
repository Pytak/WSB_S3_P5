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
            throw new NotImplementedException();
        }

        public int CompareTo(Disk o)
        {
            return (o.Width -this.Width);
        }
    }
}
