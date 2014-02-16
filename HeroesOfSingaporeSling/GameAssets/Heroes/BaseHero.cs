using GameAssets.Heroes;
namespace GameAssets
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Media;
    using System.Text;
    using System.Threading.Tasks;

    public class BaseHero : Hero
    {
        //defining dicts with different images and sounds for didfferent heroes
       public static List<string> BaseHeroImageTypeList =
            new List<string>()
        {
            {"SomeImage" }
            //Add other images
        };

       public static List<string> BaseHeroSoundTypeList =
            new List<string>()
        {
            {Environment.CurrentDirectory + "\\Sounds\\Hero\\BaseHero\\SuchkiSubiram.wav" }
            //Add other images
        };
        public BaseHero(string chooseName)
        {
            ExploreImage = new Bitmap(Environment.CurrentDirectory + "\\Images\\Hero\\hero.png", true);//ExploreImage

            //foreach (var imagePath in BaseHeroImageTypeList)
            //{

            //   CreatureBattleImages.Add(new Bitmap(imagePath));

            //}
           /* foreach (var soundPath in BaseHeroSoundTypeList)
            {
                SoundPlayer baseHeroSound = new SoundPlayer();
                try
                {
                    baseHeroSound.SoundLocation = soundPath;
                }
                
                catch (NullReferenceException)
                {
                    
                    throw;
                }
                CreatureSounds.Add(baseHeroSound);
            }*/
            MoveSound = new SoundPlayer(BaseHeroSoundTypeList[0]);
            Name = chooseName;
            Height = 50;
            Width = 45;
            PositionTop = 200;
            PositionLeft = 200;
            ObsticleType = ObsticleType.Creature;
            //making default starting properties for different heroes
            Healt = "23//23";
            Defence = "30%";
            Speed = "1";
            Mana = "10";
            Damage= "5-10";
            Experiance = "1/100";//100 for nex level
            Level = "Level 1";
        }
    }
}
