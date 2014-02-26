using System;
using System.Linq;
using GameAssets;


namespace GameLogic
{
    public static class Battle
    {
        public static event EventHandler<BattleEventArgs> BattleStart;

        public static void OnBattleStart(BattleEventArgs e)
        {
            //TODO - instead of FIGHT!!! Mesage, ask if user wants to manual or autoBattle
            EventHandler<BattleEventArgs> handler = BattleStart;
            if (handler != null) handler(null, e);
        }

        public static void AutoBattle(Hero hero, Enemy enemy)//TODO implement
        {
            double heroAttackSpeedCoef = hero.AttackSpeed / enemy.AttackSpeed;//TODO make the ratings in Hero and Enemy
            double enemyAttackSpeedCoef = 1 / heroAttackSpeedCoef;

            double heroAttackRatingCoef = (hero.AttackRating - enemy.DefenceRating)/100; //TODO make the funkcion with log
            double enemyAttackRatingCoef = (enemy.AttackRating - hero.DefenceRating)/100;

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
                if (RandomGenerator.GetRandom(0 , 100) > (100 - heroAttackRatingCoef))//if AttRating is 60 you have 60% chance to hit
                {
                    enemy.Healt = enemy.Healt - (hero.MakeDamage() * (int)heroAttackSpeedCoef);//Hero hits Enemy
                }
                if (RandomGenerator.GetRandom(0, 100) > (100 - enemyAttackRatingCoef))
                {
                    hero.Healt = hero.Healt - (enemy.MakeDamage() * (int)enemyAttackSpeedCoef);//Enemy hits Hero
                }
                
                //hero and enemy use magic?

                if (hero.Healt <= hero.MaxHealt/2)//or a logic that says poitonHealing >= maxhealt - healt
                {
                    //TODO auto heal with poiton or magic?
                }
                if (hero.Healt <= 0)
                {
                    break;
                    //TODO throw ne die event? game over menu or respawn?
                }
                if (enemy.Healt <= 0)
                {
                    break;
                    //TODO enemy die event, remove enemy from map and get bonuses
                }
            }
        }
    }
}
