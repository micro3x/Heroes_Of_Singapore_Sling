using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCommon
{
    public static class ImagePaths
    {
        public static Dictionary<StaticObsticleType, string> StaticObsticleImagePathDict =
            new Dictionary<StaticObsticleType, string>()
        {
            { StaticObsticleType.Tree, "\\Images\\Tree\\small80x100.png" },
            { StaticObsticleType.Rock, "\\Images\\Stone\\small70x70.png" },
            { StaticObsticleType.Fence, "\\Images\\Fence\\small60x60.png" },
            { StaticObsticleType.BorderVertical, "\\Images\\Borders\\BorderVertical.png" },
            { StaticObsticleType.BorderHorizontal, "\\Images\\Borders\\BorderHorizontal.png" }
        };
    }
}