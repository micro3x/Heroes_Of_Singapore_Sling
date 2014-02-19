using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCommon
{
    public class CannotBeNegative:ApplicationException
    {
        public CannotBeNegative(string msg):base(msg)
        { }
    }
}
