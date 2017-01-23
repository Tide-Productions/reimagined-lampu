using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace reimagined_lampu
{
    class Player
    {
        Texture2D texture;  //Texture of the Player
        Vector2 position;   //Position of the Player
        Rectangle hitbox;
        float speed;        //Movementspeed
        float health;       //Playerhealth
        int death;          //deathcounter
        float scale;

        /// <summary>
        /// Initialize new Player
        /// </summary>
        /// <param name="texture">Texture of the Player</param>
        /// <param name="position">Startposition</param>
        /// <param name="speed">Movementspeed</param>
        public Player(Texture2D texture, Vector2 position, float speed)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            health = 100;
            death = 0;
            scale = 0.12f;
            hitbox = new Rectangle((int)position.X + 20 , (int)position.Y + 24, 8, 8);
        }

        /// <summary>
        /// Playerzustand updaten
        /// </summary>
        public void Update()
        {
            //Keyboard State auslesen
            KeyboardState key = Keyboard.GetState();
            //Vector der aktuell auszuführenden Bewegung --> Kann leichter durch Kollision geblockt werden
            Vector2 move = new Vector2(0, 0);
            //Keyboard State auswerten
            if (key.IsKeyDown(Keys.Left) || key.IsKeyDown(Keys.A)) move.X -= speed;
            if (key.IsKeyDown(Keys.Right) || key.IsKeyDown(Keys.D)) move.X += speed;
            if (key.IsKeyDown(Keys.Up) || key.IsKeyDown(Keys.W)) move.Y -= speed;
            if (key.IsKeyDown(Keys.Down) || key.IsKeyDown(Keys.S)) move.Y += speed;

            if ((position.X <= GameStuff.Instance.limitX1) && (move.X < 0))
            {
                move.X = 0;
            }
            if ((position.X >= GameStuff.Instance.limitX2) && (move.X > 0))
            {
                move.X = 0;
            }
            if ((position.Y <= GameStuff.Instance.limitY1) && (move.Y < 0))
            {
                move.Y = 0;
            }
            if ((position.Y >= GameStuff.Instance.limitY2) && (move.Y > 0))
            {
                move.Y = 0;
            }

            hitbox.X = (int)position.X + 20;
            hitbox.Y = (int)position.Y + 20;


            //Bewegung ausführen
            position += move;
            
           
        }

        /// <summary>
        /// Zeichnen des Players und was zu ihm gehört
        /// </summary>
        /// <param name="spriteBatch">spriteBatch auf der gezeichnet wird</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: texture,position: position,scale: new Vector2((scale * GameStuff.Instance.grScale),(scale * GameStuff.Instance.grScale)),color: Color.White);
            //spriteBatch.DrawString(GameStuff.Instance.arial,"" + position.X,new Vector2(500,20),Color.White);
            //spriteBatch.DrawString(GameStuff.Instance.arial, "" + position.Y, new Vector2(500, 35), Color.White);
        }

        /// <summary>
        /// Player Schaden zufügen
        /// </summary>
        /// <param name="damage">Menge an Schaden</param>
        public void applyDamage(float damage)
        {
            health -= damage;
            
            if (health <= 0)
            {
                death++;
                //health = 100;
            }
        }

        /// <summary>
        /// Texture des Players
        /// </summary>
        /// <returns>Texture als Texture2D</returns>
        public Texture2D getTexture()
        {
            return texture;
        }

        /// <summary>
        /// Health des Players
        /// </summary>
        /// <returns>Health als float</returns>
        public float getHealth()
        {
            return health;
        }

        public Vector2 getPosition()
        {
            return position;
        }
        public void setPosition(Vector2 position)
        {
            this.position = position;
        }

        public bool checkHit(Rectangle ObjectHitRectangle)
        {
            if (((ObjectHitRectangle.X+ObjectHitRectangle.Width)>= hitbox.X) && (ObjectHitRectangle.X <= (hitbox.X+hitbox.Width)) && ((ObjectHitRectangle.Y + ObjectHitRectangle.Height) >= hitbox.Y) &&
                (ObjectHitRectangle.Y <= (hitbox.Y + hitbox.Height)))
            {
                return true;
            }
            return false;
        }
    }
}
