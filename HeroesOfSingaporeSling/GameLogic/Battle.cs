using System;
using System.Linq;
using System.Timers;
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

        public static event EventHandler<EventArgs> BattleEnded;

        private static void OnBattleEnded()
        {
            EventHandler<EventArgs> handler = BattleEnded;
            if (handler != null) handler(null, EventArgs.Empty);
        }

        //private Timer hitTimer = new Timer(1000);

        //private void initTimer()
        //{
        //    hitTimer.Elapsed += HitTimerOnElapsed;
        //}

        //private void HitTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        //{
        //    // ti udari 
        //}


        // 1. zashto tova e staticen method?
        // 2. ako e taka ... trqbva da hvurlq statichni eventi za koito geroqt trqbva da e zakachen ?!?!
        // 3. zashto karash da ti se podava Hero i Enemy pri polojenie che i dvete sa Creature i ti ne izpolzvash
        // nikude neshto specifichno za Hero?
        public static void AutoBattle(Creature hero, Creature enemy)//TODO implement
        {
            // tuka delish 2 celochisleni stoinosti bez cast i ochakvash da poluchish double ???
            double heroAttackSpeedCoef = hero.AttackSpeed / (double) enemy.AttackSpeed ;//TODO make the ratings in Hero and Enemy
            double enemyAttackSpeedCoef = 1 / heroAttackSpeedCoef;

            // tuka delish 2 celochisleni stoinosti bez cast i ochakvash da poluchish double ???
            double heroAttackRatingCoef = (hero.AttackRating - enemy.DefenceRating)/100D; //TODO make the funkcion with log
            // tuka delish 2 celochisleni stoinosti bez cast i ochakvash da poluchish double ???
            double enemyAttackRatingCoef = (enemy.AttackRating - hero.DefenceRating)/100D;
            


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
                // Geroq udrq - drugiq umira!
                if (RandomGenerator.GetRandom(0 , 100) > (100 - heroAttackRatingCoef))//if AttRating is 60 you have 60% chance to hit
                {
                    enemy.Healt = enemy.Healt - (hero.MakeDamage() * (int)heroAttackSpeedCoef);//Hero hits Enemy
                }
                // Drugiq udrq vupreki che e umrql :) -  geroq Umira!
                if (RandomGenerator.GetRandom(0, 100) > (100 - enemyAttackRatingCoef))
                {
                    hero.Healt = hero.Healt - (enemy.MakeDamage() * (int)enemyAttackSpeedCoef);//Enemy hits Hero
                }
                
                // koi pecheli ako i dvamata sa umrqli????
                // proverkata e purvo na geroq znachi gubi bitkata ot umrqla gadina!


                //hero and enemy use magic?

                if (hero.Healt <= hero.MaxHealt/2)//or a logic that says poitonHealing >= maxhealt - healt
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
                    OnBattleEnded();
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
