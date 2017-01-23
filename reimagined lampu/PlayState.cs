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
        private List<PolarPatterns> patternList = new List<PolarPatterns>();
        private BigInteger time;
        private Texture2D overlay;

        public PlayState(ContentManager Content)
        {
            LoadContent(Content);
            GameStuff.Instance.player = new Player(Content.Load<Texture2D>("player"), new Vector2(600, 350), 3.5f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GameStuff.Instance.player.Draw(spriteBatch);
            spriteBatch.Draw(texture: overlay,position: new Vector2(0, 0),scale: new Vector2(GameStuff.Instance.grScale, GameStuff.Instance.grScale),color: Color.White);
            spriteBatch.DrawString(GameStuff.Instance.arial, "Score: " + GameStuff.Instance.score, new Vector2(900, 120), Color.White);
            spriteBatch.DrawString(GameStuff.Instance.arial, "Health: " + GameStuff.Instance.player.getHealth(), new Vector2(900, 200), Color.White);

            foreach (Patterns p in patternList)
            {
                p.Draw();
            }
        }

        public void LoadContent(ContentManager Content)
        {
            time = 0;
            overlay = Content.Load<Texture2D>("overlay");
            GameStuff.Instance.bulletTexture01 = Content.Load<Texture2D>("bullets/Bullet1");
            GameStuff.Instance.bulletTexture02 = Content.Load<Texture2D>("bullets/Bullet2");
        }

        public EState Update(GameTime gameTime)
        {

            GameStuff.Instance.player.Update();

            foreach (PolarPatterns p in patternList)
            {
                p.Update();
            }

            if (time.Equals(100)) { patternList.Add(new PolarPatterns(1,36,0,0,0,50,100,new Vector2(300,300),8)); }

            time++;
            return EState.PlayState;
        }
    }
}
