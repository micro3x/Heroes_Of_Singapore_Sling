using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;


namespace GameAssets
{
    /// <summary>
    /// Used to generate a terrain to be displayed on the MainScreen
    /// </summary>
    [Serializable]
    public class Terrain
    {
        #region Vars
        private readonly Background backgroundFile = new Background((BackgroundType)0);
        private readonly List<Obsticle> terrainObsticles = new List<Obsticle>();
        private int terrainId;

        #endregion

        #region Proparties
        /// <summary>
        /// image for background
        /// </summary>
        public Bitmap Background
        {
            get { return backgroundFile.ExploreImage; }
        }
        /// <summary>
        /// returns the list of IObsticles to be created on the terrain
        /// </summary>
        public List<Obsticle> TerrainObsticles
        {
            get { return terrainObsticles; }
        }
        /// <summary>
        /// Id of the current terrain used to identify from which map file to read
        /// </summary>
        public int TerrainId
        {
            get { return terrainId; }
            set { terrainId = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Start from center terrain ID=5
        /// </summary>
        public Terrain()
        {
            terrainId = 5;
            GenerateObsticles();
            GenerateEnemies();
            GenerateItems();
        }
        /// <summary>
        /// Overload of the constructor for creating a terrain with specific ID
        /// </summary>
        /// <param name="nextTerrainId"></param>
        public Terrain(int nextTerrainId)
        {
            terrainId = nextTerrainId;
            GenerateObsticles();
            GenerateEnemies();
            GenerateItems();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reads the map file and adds the obsticles in the list of obsticles
        /// Currently adds only Static Obsticles but will be extended to add all types of obsticles
        /// </summary>
        private void GenerateObsticles()
        {
            //Reading the file in Map directory
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\Map\\" + terrainId + ".mappart");
            using (sr)
            {
                string current = sr.ReadLine();
                while (current != null)
                {
                    // each line holds the basic values for a obsticle separated with comma
                    // here we split, parse and put the values in an array
                    // first value is Type, second is Position Top, thirth is Position Left
                    int[] thisObsticle =
                        current.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => int.Parse(x))
                            .ToArray();
                    // here we create and put the obsticle in the list
                    terrainObsticles.Add(new StaticObsticle((StaticObsticleType)thisObsticle[0],thisObsticle[1],thisObsticle[2]));
                    current = sr.ReadLine();
                }
            }
        }
        private void GenerateEnemies()
        {
            //Reading the file in Map directory
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\Map\\e" + terrainId + ".mappart");
            using (sr)
            {
                string current = sr.ReadLine();
                while (current != null)
                {
                    // each line holds the basic values for a obsticle separated with comma
                    // here we split, parse and put the values in an array
                    // first value is Type, second is Position Top, thirth is Position Left
                    string[] thisObsticle =
                        current.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                            
                    // here we create and put the obsticle in the list
                    switch (thisObsticle[2])
                    {
                        case "zombie":
                            terrainObsticles.Add(Enemy.Zombie(int.Parse(thisObsticle[0]), int.Parse(thisObsticle[1])));
                            break;
                        case "monster":
                            terrainObsticles.Add(Enemy.Monster(int.Parse(thisObsticle[0]), int.Parse(thisObsticle[1])));
                            break;
                    }
                    //terrainObsticles.Add(Enemy.Monster(thisObsticle[0], thisObsticle[1]));
                    current = sr.ReadLine();
                }
            }
        }
        private void GenerateItems()
        {
            //Reading the file in Map directory
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\Map\\i" + terrainId + ".mappart");
            using (sr)
            {
                string current = sr.ReadLine();
                while (current != null)
                {
                    // each line holds the basic values for a obsticle separated with comma
                    // here we split, parse and put the values in an array
                    // first value is Type, second is Position Top, thirth is Position Left
                    string[] thisObsticle =
                        current.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                            
                    // here we create and put the obsticle in the list
                    switch (thisObsticle[2])
                    {
                        case "weaponarmor":
                            terrainObsticles.Add(WeaponArmor.GetRandomWeaponArmor(int.Parse(thisObsticle[0]), int.Parse(thisObsticle[1])));
                            break;
                        case "potion":
                            terrainObsticles.Add(new MagicItem("HP_Potion",PotionType.Heal, 30){PositionTop = int.Parse(thisObsticle[0]),PositionLeft = int.Parse(thisObsticle[1])} );

                            break;    
                    }
                    current = sr.ReadLine();
                }
            }
        }
        #endregion
    }
}
