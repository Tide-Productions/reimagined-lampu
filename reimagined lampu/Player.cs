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
        int limitX1;        //Grenzen für Player
        int limitX2;
        int limitY1;
        int limitY2;

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
            limitX1 = 330;
            limitX2 = 1110;
            limitY1 = 20;
            limitY2 = 1060;
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


            //Bewegung ausführen
            position += move;

            if (position.X <= limitX1) position.X = limitX1;
            if (position.X + texture.Width >= limitX2) position.X = limitX2 - texture.Width;
            if (position.Y <= limitY1) position.Y = limitY1;
            if (position.Y + texture.Height >= limitY2) position.Y = limitY2 - texture.Height;

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

        /// <summary>
        /// Bewegungs-X-Grenzen neu setzen
        /// </summary>
        /// <param name="left">linke Grenze als Pixel</param>
        /// <param name="right">rechte Grenze als Pixel</param>
        public void setLimitX(int left, int right)
        {
            limitX1 = left;
            limitX2 = right;
        }

        /// <summary>
        /// Bewegungs-Y-Grenzen neu setzen
        /// </summary>
        /// <param name="top">obere Grenze als Pixel</param>
        /// <param name="bottom">untere Grenze als Pixel</param>
        public void setLimitY(int top, int bottom)
        {
            limitY1 = top;
            limitY2 = bottom;
        }

        /// <summary>
        /// Zurücksetzen der Bewegungsgrenzen zum Standart
        /// </summary>
        public void resetLimit()
        {
            limitX1 = 330;
            limitX2 = 1110;
            limitY1 = 20;
            limitY2 = 1060;
        }
    }
}
