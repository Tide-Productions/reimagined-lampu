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
    abstract class Bullet
    {
        //bullet type attributes
        protected int type;
        protected Texture2D texture;
        protected Color color;

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
    }

    class PolarBullet : Bullet
    {        
        //behaviour?

        //graphic attributes
        private float rotation;
        private float grScale;

        //movement attributes
        private float speed;
        private float angleChange;
        private float acceleration;

        //position attributes
        private Vector2 centrePosition;
        private float radius;
        private float angle;
        Vector2 position = new Vector2();

        public bool alive { get; private set; }
        //constructor
        public PolarBullet(int bulletType, float bulletSpeed, float bulletAngleChange, float bulletAcceleration, Vector2 bulletCentrePosition, float bulletStartAngle)
        {
            type = bulletType;
            rotation = bulletStartAngle;
            grScale = 1.0f; 
            speed = bulletSpeed;
            angleChange = bulletAngleChange;
            acceleration = bulletAcceleration;
            centrePosition = bulletCentrePosition;
            radius = 0;
            angle = bulletStartAngle;
            alive = true;
            
            //bullet type settings
            switch (type)
            {
                case 0:
                    texture = GameStuff.Instance.bulletTexture01;
                    color = Color.White;
                    break;
                case 1:
                    texture = GameStuff.Instance.bulletTexture02;
                    color = Color.White;
                    break;
                default:
                    break;
            }
        }

        //update
        public override void Update()
        {
            radius += speed/100f;
            angle += angleChange/100f;
            speed += acceleration/100f;
            Maths.toCartesian(ref position, centrePosition, angle, radius);
            Rectangle hitbox = new Rectangle((int) position.X + 5, (int) position.Y + 5, (int) (texture.Width*grScale*GameStuff.Instance.grScale - 5), (int) (texture.Height*grScale* GameStuff.Instance.grScale - 5));

            if (GameStuff.Instance.player.checkHit(hitbox) != true) return;
            GameStuff.Instance.player.applyDamage(5); alive = false;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public bool getAlive()
        {
            return alive;
        }

        //draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: texture, position: position, origin: null, rotation: 0.0f,scale: new Vector2((grScale * GameStuff.Instance.grScale), (grScale * GameStuff.Instance.grScale)),color: color);
        }
    }
}
