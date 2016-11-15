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
    class Patterns
    {
      
        /// <summary>
        /// Patternzustand updaten
        /// </summary>
        public void Update()
        {
            
        }

        public void Draw()
        {

        }
    }
    class PolarPatterns : Patterns
    {
        int PatternID;
        int typeOB;
        int n;
        float accelerationOB;
        float startAngleOS;
        float angleChangeOB;
        float startSpeedOB;
        float angleChangeOS;
        int interval;
        Vector2 spawnPosition;
        float angle;
        List<PolarBullet> Pattern = new List<PolarBullet>();
        int timer;
        int counter;

        public PolarPatterns(int PatternID, int typeOB, int numberOB, int intervalOS, float accelerationOB, float startAngleOS, float angleChangeOB, float startSpeedOB, Vector2 spawnPosition, float angleChangeOS)
        {
            this.PatternID = PatternID;
            this.typeOB = typeOB;
            n = numberOB;
            this.spawnPosition = spawnPosition;
            this.accelerationOB = accelerationOB;
            this.startAngleOS = startAngleOS;
            this.angleChangeOB = angleChangeOB;
            this.startSpeedOB = startSpeedOB;
            this.angleChangeOS = angleChangeOS;
            interval = intervalOS;
        }

        public PolarPatterns(int PatternID, int typeOB, int numberOB, int intervalOS, float accelerationOB, float startAngleOS, float angleChangeOB, float startSpeedOB, Vector2 spawnPosition)
        {
            this.PatternID = PatternID;
            this.typeOB = typeOB;
            n = numberOB;
            this.spawnPosition = spawnPosition;
            this.accelerationOB = accelerationOB;
            this.startAngleOS = startAngleOS;
            this.angleChangeOB = angleChangeOB;
            this.startSpeedOB = startSpeedOB;
            interval = intervalOS;
            angleChangeOS = 360 / n;
        }

        public new void Update()
        {

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
                for (int i = 0; i < n; i++)
                {

                    Pattern.Add(new PolarBullet(typeOB, startSpeedOB, angleChangeOB, accelerationOB, spawnPosition, angle + i * angleChangeOS));
                    counter++;
                }

            }

            //update the pattern
            foreach (PolarBullet i in Pattern)
            {
                i.Update();
            }

            //tick counter
            timer++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (PolarBullet i in Pattern)
            {
                i.Draw(spriteBatch);
            }
        }
    }
}
