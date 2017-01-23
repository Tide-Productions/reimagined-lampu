using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Numerics;

namespace reimagined_lampu
{
    /// <summary>
    /// PlayState of the Game
    /// </summary>
    class PlayState : IGameState
    {
        private BigInteger time;
        private Texture2D overlay;
        PolarPatterns test;

        public PlayState(ContentManager Content)
        {
            LoadContent(Content);
            GameStuff.Instance.player = new Player(Content.Load<Texture2D>("player"), new Vector2(600, 350), 3.5f);
            test = new PolarPatterns(0, 1, 36, 0, 0, 0, 50, 100, new Vector2(300, 300), 8);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GameStuff.Instance.player.Draw(spriteBatch);
            test.Draw(spriteBatch);
            spriteBatch.Draw(texture: overlay,position: new Vector2(0, 0),scale: new Vector2(GameStuff.Instance.grScale, GameStuff.Instance.grScale),color: Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            time = 0;
            overlay = Content.Load<Texture2D>("overlay");
            GameStuff.Instance.bulletTexture01 = Content.Load<Texture2D>("bullets/Bullet1");
            GameStuff.Instance.bulletTexture02 = Content.Load<Texture2D>("bullets/Bullet2");
            GameStuff.Instance.grScale = 2.0f / 3.0f;
        }

        public EState Update(GameTime gameTime)
        {

            GameStuff.Instance.player.Update();

            //example
            //if (time >= 90) { test.Update(); }

            time++;
            return EState.PlayState;
        }
    }
}
