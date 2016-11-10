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

            if (position.X <= 250) {
                position.X = 250;
                move.X = 0;
            }
            if (position.X + texture.Width >= 1190)
            {
                position.X = 1190 - texture.Width;
                move.X = 0;
            }
            if (position.Y <= 10) {
                position.Y = 10;
                move.Y = 0;
            }
            if (position.Y + texture.Height >= 1070)
            {
                position.Y = 1070 - texture.Height;
                move.Y = 0;
            }

            //Bewegung ausführen
            position += move;
        }

        /// <summary>
        /// Zeichnen des Players und was zu ihm gehört
        /// </summary>
        /// <param name="spriteBatch">spriteBatch auf der gezeichnet wird</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
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
        /// Position des Players
        /// </summary>
        /// <returns>Position als Vector2</returns>
        public Vector2 getPosition()
        {
            return position;
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
    }
}
