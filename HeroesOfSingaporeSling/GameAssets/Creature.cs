using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Media;

namespace GameAssets
{
    public enum BattaleImageType 
    {
        MapImage, ExploreImage, BattleImageStandLeftFootInFront, BattleImageStandRightFootInFront, BattleImageHit, BattleImageTakeHit, BattleImageJump, BattleImageDuck
    }
    public enum CreatureSoundType
    {
        HitSound, TakeHitSound, JumpSound, DuckSound, 
    }
    public class Creature : Obsticle
    {

        public static SoundPlayer HeroSounds = new SoundPlayer("C:\\Users\\daniel\\Desktop\\HeroesOfSingaporeSling\\Sounds\\Hero\\SampleHero\\SuchkiSubiram.wav");

        private string name;
        private string healt;
        private string defence;
        private string speed;
        private string mana;
        private string damage;
        private List<Bitmap> creatureBattleImages;
        private List<SoundPlayer> creatureSounds;
        

        public List<SoundPlayer> CreatureSounds
        {
            get { return this.creatureSounds; }
            set
            {
                this.creatureSounds = value;
            }
        }
        public SoundPlayer MoveSound { get; set; }
        public List<Bitmap> CreatureBattleImages
        {
            get { return this.creatureBattleImages; }
            set 
            {
                this.creatureBattleImages = value;
            }
        }


       

        public string Name
            {
                get { return this.name; }
                set // could validate in game manu for choosing hero
                {
                    this.name = value;
                }
            }

            public string Healt
            {
                get { return healt; }
                set
                {
                    healt = value;
                }

            }

            public string Defence
            {
                get { return defence; }
                set
                {
                    defence = value;
                }
            }

            public string Speed
            {
                get { return speed; }
                set
                {
                    speed = value;
                }
            }

            public string Mana
            {
                get { return mana; }
                set
                {
                    mana = value;
                }
            }

            public string Damage
            {
                get { return damage; }
                set
                {
                    damage = value;
                }
            }

            //in battle:
            //if(enemyHitUs){ 
            //player.TakeDamage(enemy.MakeDamage());}
            //if(weHitEnemy){enemy1.TakeDamage(playr.MakeDamageA());
            public void TakeDamage(int DamageTaken)
            {
                this.Healt = ((Convert.ToInt32(this.Healt) - DamageTaken)).ToString();   //ToDODefence
            }

            public int MakeDamage()
            {
                return Convert.ToInt32(this.Damage);//+ item[1] (sword) and some bonuses to damage or magic bonus to dmg
            }
        
    }
}
