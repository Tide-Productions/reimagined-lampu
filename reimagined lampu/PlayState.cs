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
        private List<Patterns> patternList;
        private BigInteger time;
        private Texture2D overlay;

        public PlayState(ContentManager Content)
        {
            LoadContent(Content);
            GameStuff.Instance.player = new Player(Content.Load<Texture2D>("player"), new Vector2(600, 350), 3.5f);
            patternList = new List<Patterns>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GameStuff.Instance.player.Draw(spriteBatch);
            foreach (Patterns p in patternList)
            {
                p.Draw(spriteBatch);
            }

            spriteBatch.Draw(texture: overlay, position: new Vector2(0, 0), scale: new Vector2(GameStuff.Instance.grScale, GameStuff.Instance.grScale), color: Color.White);
            spriteBatch.DrawString(GameStuff.Instance.arial, "Score: " + GameStuff.Instance.score, new Vector2(900, 120), Color.White);
            spriteBatch.DrawString(GameStuff.Instance.arial, "Health: " + GameStuff.Instance.player.getHealth(), new Vector2(900, 200), Color.White);
            spriteBatch.DrawString(GameStuff.Instance.arial, "Time: " + time.ToString(), new Vector2(900, 280), Color.White);

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

            foreach (Patterns p in patternList)
            {
                p.Update();
            }

            if (time == 100) { patternList.Add(new PolarPatterns(0, 20, 10, 0, -10, 0, 200, new Vector2(translate(-300), 0), 10)); }
            if (time == 125) { patternList.Add(new PolarPatterns(0, 20, 10, 0, 0, 0, 200, new Vector2(translate(300), 0), 10)); }

            if (time == 675) { patternList.Add(new PolarPatterns(1, 40, 10, -320, -10, 0.5f, 800, new Vector2(translate(-300), 0), 5)); }
            if (time == 750) { patternList.Add(new PolarPatterns(1, 40, 10, -320, -7.5f, 0.5f, 800, new Vector2(translate(-300), 0), 5)); }
            if (time == 825) { patternList.Add(new PolarPatterns(1, 40, 10, -320, -10, 0.5f, 900, new Vector2(translate(300), 0), 5)); }
            if (time == 900) { patternList.Add(new PolarPatterns(1, 40, 10, -320, -7.5f, 0.5f, 900, new Vector2(translate(300), 0), 5)); }

            if (time == 1300) { patternList.Add(new PolarPatterns(0, 20, 10, 0, -10, 0, 200, new Vector2(translate(-300), 0), 15)); }
            if (time == 1325) { patternList.Add(new PolarPatterns(0, 20, 10, 0, -5, 0, 200, new Vector2(translate(-300), 0), 15)); }
            if (time == 1350) { patternList.Add(new PolarPatterns(0, 20, 10, 0, -10, 0, 200, new Vector2(translate(-300), 0), 15)); }
            if (time == 1375) { patternList.Add(new PolarPatterns(0, 20, 10, 0, -5, 0, 200, new Vector2(translate(-300), 0), 15)); }
            if (time == 1400) { patternList.Add(new PolarPatterns(0, 20, 10, 0, -10, 0, 200, new Vector2(translate(-300), 0), 15)); }
            if (time == 1425) { patternList.Add(new PolarPatterns(0, 20, 10, 0, -5, 0, 200, new Vector2(translate(-300), 0), 15)); }
            if (time == 1450) { patternList.Add(new PolarPatterns(0, 20, 10, 0, -10, 0, 200, new Vector2(translate(-300), 0), 15)); }
            if (time == 1475) { patternList.Add(new PolarPatterns(0, 20, 10, 0, -5, 0, 200, new Vector2(translate(-300), 0), 15)); }

            if (time == 1500) { patternList.Add(new PolarPatterns(1, 20, 10, 0, 0, 0, 200, new Vector2(translate(300), 0), 15)); }
            if (time == 1525) { patternList.Add(new PolarPatterns(1, 20, 10, 0, 5, 0, 200, new Vector2(translate(300), 0), 15)); }
            if (time == 1550) { patternList.Add(new PolarPatterns(1, 20, 10, 0, 0, 0, 200, new Vector2(translate(300), 0), 15)); }
            if (time == 1575) { patternList.Add(new PolarPatterns(1, 20, 10, 0, 5, 0, 200, new Vector2(translate(300), 0), 15)); }
            if (time == 1600) { patternList.Add(new PolarPatterns(1, 20, 10, 0, 0, 0, 200, new Vector2(translate(300), 0), 15)); }
            if (time == 1625) { patternList.Add(new PolarPatterns(1, 20, 10, 0, 5, 0, 200, new Vector2(translate(300), 0), 15)); }
            if (time == 1650) { patternList.Add(new PolarPatterns(1, 20, 10, 0, 0, 0, 200, new Vector2(translate(300), 0), 15)); }
            if (time == 1675) { patternList.Add(new PolarPatterns(1, 20, 10, 0, 5, 0, 200, new Vector2(translate(300), 0), 15)); }

            time++;
            return EState.PlayState;
        }

        private float translate(float coordinate) { return coordinate + 480; }
    }
}
