namespace GameAssets
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Media;
    using System.Text;
    using System.Threading.Tasks;

     public class BaseHeroTwo : Hero
      {
          //defining dicts with different images and sounds for didfferent heroes 
           private static Dictionary<BattaleImageType, string> BaseHeroTwoImgaeTypeDict =
              new Dictionary<BattaleImageType, string>()
          {
              { BattaleImageType.ExploreImage, Environment.CurrentDirectory + "\\Images\\Hero\\HeroTwo.jpg" },
              { BattaleImageType.BattleImageStandLeftFootInFront, Environment.CurrentDirectory + "SomeImage" }
              //Add other images
          };

           public static Dictionary<CreatureSoundType, string> BaseHeroTwoSoundTypeDict =
              new Dictionary<CreatureSoundType, string>()
          {
              { CreatureSoundType.HitSound, "SomeSoundWav" },
              //Add other images
          };
          public BaseHeroTwo(string chooseName)
          {
              MoveSound = new SoundPlayer(Environment.CurrentDirectory + "\\Sounds\\Hero\\BaseHeroTwo\\beep-01a.wav");
              ExploreImage = new Bitmap(Environment.CurrentDirectory + "\\Images\\Hero\\HeroTwo.png", true);//ExploreImage
              Name = chooseName;
              Height = 50;
              Width = 45;
              PositionTop = 200;
              PositionLeft = 200;
              ObsticleType = ObsticleType.Creature;
              //making starting properties for different heroes
              Healt = "16//16";
              Defence = "30%";
              Speed = "1";
              Mana = "10";
              Damage= "10-15";
              Experiance = "1/100";//100 for nex level
              Level = "Level 1";
          }
      }
}
