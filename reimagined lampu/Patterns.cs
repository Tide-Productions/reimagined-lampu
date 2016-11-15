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
        int timer;
        int interval;


        public PolarPatterns(int PatternID, int typeOB, int numberOB, int intervalOS, float accelerationOB, float startAngleOS, float angleChangeOB, float startSpeedOB, float angleChangeOS)
        {
            this.PatternID = PatternID;
            this.typeOB = typeOB;
            n = numberOB;
            this.accelerationOB = accelerationOB;
            this.startAngleOS = startAngleOS;
            this.angleChangeOB = angleChangeOB;
            this.startSpeedOB = startSpeedOB;
            this.angleChangeOS = angleChangeOS;
            interval = intervalOS;
        }

        public PolarPatterns(int PatternID, int typeOB, int numberOB, int intervalOS, float accelerationOB, float startAngleOS, float angleChangeOB, float startSpeedOB)
        {
            this.PatternID = PatternID;
            this.typeOB = typeOB;
            n = numberOB;
            this.accelerationOB = accelerationOB;
            this.startAngleOS = startAngleOS;
            this.angleChangeOB = angleChangeOB;
            this.startSpeedOB = startSpeedOB;
        }

        public new void Update()
        {
            List<Enemy> Pattern = new List<Enemy>();
            //initalize the pattern
            if (timer % interval == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    //
                }
            }

            //update the pattern
            for (int i = 0; i < Pattern.Count; i++)
            {
                Pattern[i].Update();
            }

            //tick counter
            timer++;

        }

    }
}
