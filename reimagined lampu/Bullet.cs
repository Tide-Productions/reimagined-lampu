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
    class Bullet
    {
    }

    class PolarBullet : Bullet
    {
        //bullet type attributes
        private int type;
        private Texture2D texture;
        private Color color;
        //behaviour?

        //graphic attributes
        private float rotation;

        //movement attributes
        private float speed;
        private float angleChange;
        private float acceleration;

        //position attributes
        private Vector2 centrePosition;
        private float radius;
        private float angle;

        //constructor
        public PolarBullet(int bulletType, float bulletSpeed, float bulletAngleChange, float bulletAcceleration, Vector2 bulletCentrePosition, float bulletStartAngle)
        {
            type = bulletType;
            rotation = bulletStartAngle;
            speed = bulletSpeed;
            angleChange = bulletAngleChange;
            acceleration = bulletAcceleration;
            centrePosition = bulletCentrePosition;
            radius = 0;
            angle = bulletStartAngle;
           
            switch (type)
            {
                case 0:
                    texture = GameStuff.Instance.bulletTexture01;
                    break;
                default:
                    break;
            }
        }
    }
}
