using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace reimagined_lampu
{
    class Pause : IGameState
    {
        Texture2D background;
        public Pause(ContentManager Content)
        {
            LoadContent(Content);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0), scale: new Vector2(2.0f / 3.0f), color: Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("Menu");
        }

        public EState Update(GameTime gameTime)
        {
            return EState.Pause;
        }

        public void reset()
        {

        }
    }
}
