using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets.Structures
{
    public struct GridSize
    {
        private int rows;
        private int cols;

        public GridSize(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
        }

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }

    }
}
