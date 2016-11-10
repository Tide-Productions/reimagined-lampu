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
       
        int patternStyle;
        Vector2 spawnPosition;
        double radiusChange;
        double angleChange;
        double accel;




        public Patterns(int patternStyle, Vector2 spawnPosition, double radiusChange, double angleChange, double accel)
        {
            this.patternStyle = patternStyle;
            this.spawnPosition = spawnPosition;
            this.radiusChange = radiusChange;
            this.angleChange = angleChange;
            this.accel = accel;
        }


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
        float n;
        float accelerationOB;
        float startAngleOS;
        float angleChangeOB;
        float startSpeedOB;
        float angleChangeOS;
        int timer;




        public PolarPatterns(int PatternID, int typeOB, float numberOB, float accelerationOB, float startAngleOS, float angleChangeOB, float startSpeedOB, float angleChangeOS)
        {
            this.PatternID = PatternID;
            this.typeOB = typeOB;
            n = numberOB;
            this.accelerationOB = accelerationOB;
            this.startAngleOS = startAngleOS;
            this.angleChangeOB = angleChangeOB;
            this.startSpeedOB = startSpeedOB;
            this.angleChangeOS = angleChangeOS;
            Enemy[] testPattern = new Enemy[n];
        }

        public PolarPatterns(int PatternID, int typeOB, float numberOB, float accelerationOB, float startAngleOS, float angleChangeOB, float startSpeedOB)
        {
            this.PatternID = PatternID;
            this.typeOB = typeOB;
            n = numberOB;
            this.accelerationOB = accelerationOB;
            this.startAngleOS = startAngleOS;
            this.angleChangeOB = angleChangeOB;
            this.startSpeedOB = startSpeedOB;
            Enemy[] testPattern = new Enemy[n];
        }

        public new void Update()
        {

            if (timer % interval == 0)
            {
                if (counter < n)
                {
                    for (int i = 0; i < anzahl; i++)
                    {
                        testPattern[counter + i] = new Enemy(enemyTexture, new Vector2(200, 100), speed, Convert.ToSingle(((counter + i) * Math.PI) / 180));
                    }

                    counter += anzahl;
                    //speed = -speed;
                }
            }


            for (int i = 0; i < counter; i++)
            {
                testPattern[i].Update();
            }





            //tick counter
            timer++;

        }

    }
}
