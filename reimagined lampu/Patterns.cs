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
            switch (patternStyle)
            {
                case 0:
                    
                default:
                    break;
            }
        }

        public void Draw()
        {

        }
    }
}
