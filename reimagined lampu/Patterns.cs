using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace reimagined_lampu
{
    abstract class Patterns
    {

        /// <summary>
        /// Patternzustand updaten
        /// </summary>
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
    }
    class PolarPatterns : Patterns
    {
        int typeOB;
        int n;
        float accelerationOB;
        float angleChangeOB;
        float startSpeedOB;
        float angleChangeOS;
        int interval;
        Vector2 spawnPosition;
        float angle;
        List<PolarBullet> Pattern = new List<PolarBullet>();
        int timer;
        int counter;

        public PolarPatterns(int typeOB, int numberOB, int intervalOS, float accelerationOB, float startAngleOS, float angleChangeOB, float startSpeedOB, Vector2 spawnPosition, float angleChangeOS)
        {
            this.typeOB = typeOB;
            n = numberOB;
            this.spawnPosition = spawnPosition;
            this.accelerationOB = accelerationOB;
            this.angleChangeOB = angleChangeOB;
            this.startSpeedOB = startSpeedOB;
            this.angleChangeOS = angleChangeOS;
            interval = intervalOS;
            angle = startAngleOS;
        }

        public PolarPatterns(int typeOB, int numberOB, int intervalOS, float accelerationOB, float startAngleOS, float angleChangeOB, float startSpeedOB, Vector2 spawnPosition)
        {
            this.typeOB = typeOB;
            n = numberOB;
            this.spawnPosition = spawnPosition;
            this.accelerationOB = accelerationOB;
            this.angleChangeOB = angleChangeOB;
            this.startSpeedOB = startSpeedOB;
            interval = intervalOS;
            angleChangeOS = 360.0f / n;
            angle = startAngleOS;
        }

        public override void Update()
        {
            #region Create Pattern
            //initalize the pattern
            if ((interval != 0) && (timer % interval == 0) && (counter <= n))
            {
                //create new bullets one by one
                angle += angleChangeOS;
                Pattern.Add(new PolarBullet(typeOB, startSpeedOB, angleChangeOB, accelerationOB, spawnPosition, angle));
                counter++;
            }
            else if ((counter <= n) && (interval == 0))
            {

                //create n new bullets at once
                for (var i = 0; i < n; i++)
                {

                    Pattern.Add(new PolarBullet(typeOB, startSpeedOB, angleChangeOB, accelerationOB, spawnPosition, angle + i * angleChangeOS));
                    counter++;
                }

            }
            #endregion

            #region Update Pattern

            //update the pattern
            Pattern = Pattern.Where(p => p.alive).ToList();
            foreach (var p in Pattern)
            {
                if (p.position.X > 1000 || p.position.X < -100 ||
                    p.position.Y > 700 || p.position.Y < -100)
                {
                    if (p.position.Y >= 370) GameStuff.Instance.score += 3;
                    p.alive = false;
                }
                else
                {
                    p.Update();
                }

            }
            #endregion

            //tick counter
            timer++;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //List<PolarBullet> work = Pattern.Where(p => p.alive).ToList();
            foreach (var i in Pattern.Where(p => p.alive))
            {
                i.Draw(spriteBatch);
            }
        }
    }
}
