using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace reimagined_lampu
{
    class Enemy
    {
        Texture2D texture;  //Texture of the Player
        Vector2 position;   //Position of the Player
        float speed;        //Movementspeed
        float health;       //Playerhealth
        int death;          //deathcounter

        /// <summary>
        /// Initialize new Enemy
        /// </summary>
        /// <param name="texture">Texture of the Player</param>
        /// <param name="position">Startposition</param>
        /// <param name="speed">Movementspeed</param>
 
        public Enemy(Texture2D texture, Vector2 position, float speed)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            health = 100;
            death = 0;
        }

        /// <summary>
        /// Enemyzustand updaten
        /// </summary>
        public void Update()
        {

        }

        /// <summary>
        /// Zeichnen des Enemies und was zu ihm gehört
        /// </summary>
        /// <param name="spriteBatch">spriteBatch auf der gezeichnet wird</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        /// <summary>
        /// Enemy Schaden zufügen
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
        /// Position des Enemies
        /// </summary>
        /// <returns>Position als Vector2</returns>
        public Vector2 getPosition()
        {
            return position;
        }

        /// <summary>
        /// Texture des Enemies
        /// </summary>
        /// <returns>Texture als Texture2D</returns>
        public Texture2D getTexture()
        {
            return texture;
        }
        /// <summary>
        /// Health des Enemies
        /// </summary>
        /// <returns>Health als float</returns>
        public float getHealth()
        {
            return health;
        }
    }
}
