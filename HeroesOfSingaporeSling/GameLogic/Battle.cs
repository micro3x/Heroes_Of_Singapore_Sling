using System;
using System.Linq;
using System.Net.Configuration;
using GameAssets;


namespace GameLogic
{
    public class Battle
    {
        public static event EventHandler<BattleEventArgs> BattleStart;

        public static void OnBattleStart(BattleEventArgs e)
        {
            //TODO - instead of FIGHT!!! Mesage, ask if user wants to manual or autoBattle
            EventHandler<BattleEventArgs> handler = BattleStart;
            if (handler != null) handler(null, e);
        }

        public static event EventHandler<BattleEndEventArgs> BattleEnded;

        private static void OnBattleEnded(BattleEndEventArgs e)
        {
            EventHandler<BattleEndEventArgs> handler = BattleEnded;
            if (handler != null) handler(null, e);
        }
        private static bool userWin = false;

        public static void AutoBattle(Creature hero, Creature enemy)
        {
            double heroAttackSpeedCoef = hero.AttackSpeed / (double)enemy.AttackSpeed;
            double enemyAttackSpeedCoef = 1 / heroAttackSpeedCoef;

            double heroAttackRatingCoef = (hero.AttackRating - enemy.Defence) / 100D;
            double enemyAttackRatingCoef = (enemy.AttackRating - hero.Defence) / 100D;

            

            if (heroAttackRatingCoef > 80)//TODO remove this when log function is ready
            {
                heroAttackRatingCoef = 80;
            }
            else if (heroAttackRatingCoef < 20)
            {
                heroAttackRatingCoef = 20;
            }
            if (enemyAttackRatingCoef > 80)
            {
                enemyAttackRatingCoef = 80;
            }
            else if (enemyAttackRatingCoef < 20)
            {
                enemyAttackRatingCoef = 20;
            }

            while (hero.Healt > 0 && enemy.Healt > 0)
            {
                if (RandomGenerator.GetRandom(0, 100) > (100 - heroAttackRatingCoef))//if AttRating is 60 you have 60% chance to hit
                {
                    enemy.Healt = enemy.Healt - (hero.MakeDamage() * (int)heroAttackSpeedCoef);//Hero hits Enemy
                }
                if (RandomGenerator.GetRandom(0, 100) > (100 - enemyAttackRatingCoef))
                {
                    hero.Healt = hero.Healt - (enemy.MakeDamage() * (int)enemyAttackSpeedCoef);//Enemy hits Hero
                }

                if (hero.Healt <= hero.MaxHealt / 2)
                {
                    MagicItem potion = (hero as Hero).Inventory.ContainingItems.FirstOrDefault(
                        x => x.TypeOfItem == ItemType.Magical && x.Name == "HP_Potion") as MagicItem;
                    if (potion != null)
                    {
                        potion.UseItem(hero);
                    }

                }
                if (hero.Healt <= 0)
                {

                    OnBattleEnded(new BattleEndEventArgs(false,hero));
                    break;

                }
                if (enemy.Healt <= 0)
                {
                    var hero1 = hero as Hero;
                    if (hero1 != null) hero1.GainedExperiance += enemy.MaxDamage/2;
                    OnBattleEnded(new BattleEndEventArgs(true,enemy));
                    break;

                }
            }


        }

       

    }
}
