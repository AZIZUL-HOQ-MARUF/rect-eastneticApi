using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace SizeSampleApi
{
    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Size() {
            
        }

        public Size(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
        }
    }
}
