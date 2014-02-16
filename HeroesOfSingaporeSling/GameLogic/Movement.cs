using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GameAssets;
using GameCommon;
using Microsoft.Win32;


namespace GameLogic
{
    public class Movement
    {
        #region Global Vars
        static Timer moveTimer;
        private static int _targettop;
        private static int _targetleft;
        private static IMoveble itemToMove;
        private static List<Tuple<int, int>> Path;
        private static bool hit;
        private static List<Obsticle> obsticlesList;
        #endregion
        /// <summary>
        /// Start moving the passed item by calling this method.
        /// if the item is currently moving it stops and starts moving in the new direction
        /// </summary>
        /// <param name="item">item to move</param>
        /// <param name="targetTop"> Final destination Y </param>
        /// <param name="targetLeft"> Final destination X </param>
        /// <param name="obsList"> List of obsticles on the terrain </param>
        public static void MoveToPosition(IMoveble item, int targetTop, int targetLeft, List<Obsticle> obsList)
        {
            // set global vars
            hit = false;
            obsticlesList = obsList;
            itemToMove = item;
            _targettop = targetTop - (item.ExploreImage.Height / 2);
            _targetleft = targetLeft - (item.ExploreImage.Width / 2);
            // stop if the item is moving
            Stop();
            // drow a new path to follow
            CalculatePath();
            // set the timer
            moveTimer = new Timer(50);
            moveTimer.Elapsed += new ElapsedEventHandler(TimerTick);
            // Go Baby Go
            moveTimer.Start();
        }

        private static void CalculatePath()
        {
            // we set the new position the current one
            int newTop = itemToMove.PositionTop;
            int newLeft = itemToMove.PositionLeft;
            // we create a container for our path X and Y
            Path = new List<Tuple<int, int>>();
            //Start building the path
            Action Build = delegate
            {
                do
                {
                    // We take the Y values of all points arawnd our current position
                    int[] ypos = new[]
                    {
                        newTop - 1,
                        newTop - 1,
                        newTop,  
                        newTop + 1,
                        newTop + 1,
                        newTop + 1,
                        newTop,  
                        newTop - 1
                    };
                    // We take the X values of all points arawnd our current position
                    int[] xpos = new[]
                    {                            
                        newLeft, 
                        newLeft +1,
                        newLeft +1,
                        newLeft +1,
                        newLeft, 
                        newLeft -1,
                        newLeft -1,
                        newLeft -1,
                    };
                    // we calculate the distance between our current position and the final destination
                    double minDistance = CalcDistance(newLeft, newTop, _targetleft, _targettop);
                    // we do the same with all 8 point arawnd our current position
                    for (int i = 0; i < xpos.Length; i++)
                    {
                        // by checking all points arownd us we determin which one is closer to our final destination
                        double distance = CalcDistance(_targetleft, _targettop, xpos[i], ypos[i]);
                        if (distance < minDistance)
                        {
                            // we found a point closer so we set the values
                            minDistance = distance;
                            newTop = ypos[i];
                            newLeft = xpos[i];
                        }
                    }
                    // we add the point to the path
                    Rectangle r = new Rectangle(newLeft, newTop, itemToMove.ExploreImage.Width, itemToMove.ExploreImage.Height);
                    foreach (Obsticle obs in obsticlesList)
                    {
                        hit = HitCheck(r, obs);
                        if (hit)
                        {
                            return;
                        }
                    }
                    Path.Add(new Tuple<int, int>(newLeft, newTop));
                }
                // we are doing it untill we reach the destination.
                while (!(newTop == _targettop && newLeft == _targetleft));
            };
            // we don't want to move on every pixel (we will move very slow)
            // so we take every 5th point in the path and create a new path
            // with less steps
            Build();
            int step = 5;
            Path = Path.Where((x, i) => i % step == 0).ToList();
        }
        /// <summary>
        /// Every time the timer ticks This will happen
        /// in short we will move a step forword on our Path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TimerTick(object sender, ElapsedEventArgs e)
        {
            // do we have a path?
            if (Path.Count > 0)
            {
                try
                {
                    // let's make the step
                    // we call the ChangePosition method in our item because 
                    // it not only changes the position values in our item
                    // but also triggers an event to let anyone listening that we want to move!
                    itemToMove.ChangePosition(Path[0].Item2, Path[0].Item1);
                    // we did this step so we can remove it from the path.
                    Path.RemoveAt(0);
                }
                catch (Exception)
                {
                    Stop();
                }
            }
            else
            {
                // we don't have a path so why move?
                Stop();
            }
        }
        /// <summary>
        /// Stop! Stop! Stop! Moving!
        /// </summary>
        public static void Stop()
        {
            // are we moving?
            if (moveTimer != null)
            {
                // Stop Moving
                moveTimer.Stop();
                moveTimer.Dispose();
            }
        }

        /// <summary>
        /// using Euclideans formula for distance we calculate the distance between our two points
        /// </summary>
        /// <param name="x1"> First point X </param>
        /// <param name="y1"> First point Y </param>
        /// <param name="x2"> Second point X </param>
        /// <param name="y2"> Second point Y </param>
        /// <returns></returns>
        private static double CalcDistance(int x1, int y1, int x2, int y2)
        {
            double result;
            result = Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));
            return result;
        }

        /// <summary>
        /// We take 2 rectangle objects and check if any of the first object angles is inside the second
        /// You had this for Homework if you dont get it check your homework!!! :)
        /// </summary>
        /// <param name="firstObject"></param>
        /// <param name="secondObject"></param>
        /// <returns></returns>
        private static bool HitCheck(Rectangle firstObject, Obsticle secondObject)
        {
            Tuple<int, int>[] points = new Tuple<int, int>[4];
            points[0] = new Tuple<int, int>(firstObject.Y, firstObject.X);
            points[1] = new Tuple<int, int>(firstObject.Y, firstObject.X + firstObject.Width);
            points[2] = new Tuple<int, int>(firstObject.Y + firstObject.Height, firstObject.X + firstObject.Width);
            points[3] = new Tuple<int, int>(firstObject.Y + firstObject.Height, firstObject.X);
            for (int i = 0; i < points.Length; i++)
            {
                if (
                    (points[i].Item1 >= secondObject.PositionTop && points[i].Item1 <= secondObject.PositionTop + secondObject.ExploreImage.Height)
                    &&
                    (points[i].Item2 >= secondObject.PositionLeft && points[i].Item2 <= secondObject.PositionLeft + secondObject.ExploreImage.Width)
                    )
                {
                    return true;
                }
            }
            return false;
        }

    }
}
