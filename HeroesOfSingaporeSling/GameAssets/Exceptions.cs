using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets
{
    public class HeroPropartieOutOfRange : ApplicationException
    {
        public HeroPropartieOutOfRange()
        {
        }

        public HeroPropartieOutOfRange(string message)
            : base(message)
        {
        }

        public HeroPropartieOutOfRange(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
