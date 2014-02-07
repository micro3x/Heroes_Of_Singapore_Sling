using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace GameAssets
{
    public class Terrain
    {
        #region Vars
        private Background backgroundFile = new Background();
        private Bitmap background;
        private List<IObsticle> terrainObsticles = new List<IObsticle>();
        private int terrainId;
        #endregion

        #region Proparties
        public Bitmap Background
        {
            get { return background; }
            private set { background = value; }
        }

        public List<IObsticle> TerrainObsticles
        {
            get { return terrainObsticles; }
        }

        #endregion

        public Terrain()
        {
            terrainId = 5;
            Background = backgroundFile.BackgroundImage;
            GenerateObsticles(15);
        }

        public Terrain(int nextTerrainId)
        {
            terrainId = nextTerrainId;
            Background = backgroundFile.BackgroundImage;
            GenerateObsticles(15);
        }

        public int TerrainId
        {
            get { return terrainId; }
            set { terrainId = value; }
        }


        private void GenerateObsticles(int count)
        {
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\Map\\" + terrainId + ".mappart");
            using (sr)
            {
                string current = sr.ReadLine();
                while (current != null)
                {
                    int[] thisObsticle =
                        current.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => int.Parse(x))
                            .ToArray();
                    terrainObsticles.Add(new StaticObsticle((StaticObsticleType)thisObsticle[0],thisObsticle[1],thisObsticle[2]));
                    current = sr.ReadLine();
                }
            }
        }
    }
}
