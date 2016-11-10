using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using reimagined_lampu;


namespace reimagined_lampu.Patterns
{
    class PolarPatterns
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

        public void Update()
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
