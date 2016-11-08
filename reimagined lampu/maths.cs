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
    class maths
    {

        public static void polarCoordinates(Vector2 position, Vector2 spawnPosition, double angle, double radius)
        {
            position.X = Convert.ToSingle(radius * Math.Cos(angle)) + spawnPosition.X;
            position.Y = Convert.ToSingle(radius * Math.Sin(angle)) + spawnPosition.Y;
        }


    }
}
