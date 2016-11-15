using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace reimagined_lampu
{
    class Player
    {
        Texture2D texture;  //Texture of the Player
        Vector2 position;   //Position of the Player
        float speed;        //Movementspeed
        float health;       //Playerhealth
        int death;          //deathcounter
        float limitX1, limitX2, limitY1, limitY2;        //Grenzen für Player
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
            limitX1 = (float) 330/1920;
            limitX2 = (float) 1112/1920;
            limitY1 = (float) 18/1080;
            limitY2 = (float) 1061/1080;
            health = 100;
            death = 0;
            scale = 0.12f;
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


            //Bewegung ausführen
            position += move;
            /*
            if (position.X <= limitX1) position.X = limitX1;
            if (position.X + (texture.Width * scale) >= limitX2) position.X = limitX2 - (texture.Width * scale);
            if (position.Y <= limitY1) position.Y = limitY1;
            if (position.Y + (texture.Height * scale) >= limitY2) position.Y = limitY2 - (texture.Height * scale);
            */
        }

        /// <summary>
        /// Zeichnen des Players und was zu ihm gehört
        /// </summary>
        /// <param name="spriteBatch">spriteBatch auf der gezeichnet wird</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, null, new Vector2(0,0), 0.0f, new Vector2((scale * GameStuff.Instance.grScale),(scale * GameStuff.Instance.grScale)), Color.White, 0f);
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
                health = 100;
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
    }
}
