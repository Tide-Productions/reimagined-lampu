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
    class Maths
    {
        /// <summary>
        /// Erzeugt verwendbare Koordinaten für den Positionsvektor
        /// </summary>
        /// <param name="position">referenzierte Position (wird verändert)</param>
        /// <param name="spawnPosition">Rotationszentrum</param>
        /// <param name="angle">Winkel</param>
        /// <param name="radius">Radius</param>
        public static void toCartesian(ref Vector2 position, Vector2 spawnPosition, double angle, double radius)
        {
            angle = ((angle * Math.PI) / 180);
            position.X = Convert.ToSingle(radius * Math.Cos(angle)) + spawnPosition.X;
            position.Y = Convert.ToSingle(radius * Math.Sin(angle)) + spawnPosition.Y;
        }

    }
}
