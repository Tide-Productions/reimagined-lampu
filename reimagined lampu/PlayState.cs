using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
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
        private Song bg;

        public PlayState(ContentManager Content)
        {
            LoadContent(Content);
            GameStuff.Instance.player = new Player(Content.Load<Texture2D>("player"), new Vector2(translate(0), 500), 3.5f);
            patternList = new List<Patterns>();
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.01f;
            MediaPlayer.Play(bg);
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
            //spriteBatch.DrawString(GameStuff.Instance.arial, "Time: " + time.ToString(), new Vector2(900, 280), Color.White);

        }

        public void LoadContent(ContentManager Content)
        {
            time = 0;
            overlay = Content.Load<Texture2D>("overlay");
            GameStuff.Instance.score = 0;
            GameStuff.Instance.bulletTexture01 = Content.Load<Texture2D>("bullets/Bullet1");
            GameStuff.Instance.bulletTexture02 = Content.Load<Texture2D>("bullets/Bullet2");
            bg = Content.Load<Song>("bg");
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

            if (time == 675) { patternList.Add(new PolarPatterns(1, 40, 10, -300, -10, 0.5f, 800, new Vector2(translate(-300), 0), 5)); }
            if (time == 750) { patternList.Add(new PolarPatterns(1, 40, 10, -300, -7.5f, 0.5f, 800, new Vector2(translate(-300), 0), 5)); }
            if (time == 825) { patternList.Add(new PolarPatterns(1, 40, 10, -300, -10, 0.5f, 900, new Vector2(translate(300), 0), 5)); }
            if (time == 900) { patternList.Add(new PolarPatterns(1, 40, 10, -300, -7.5f, 0.5f, 900, new Vector2(translate(300), 0), 5)); }

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

            if (time == 2000) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 50, new Vector2(translate(-300), 0))); }
            if (time == 2030) { patternList.Add(new PolarPatterns(1, 36, 0, 300, -10, 0, 50, new Vector2(translate(-250), 0))); }
            if (time == 2060) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 50, new Vector2(translate(-200), 0))); }
            if (time == 2090) { patternList.Add(new PolarPatterns(1, 36, 0, 300, -10, 0, 50, new Vector2(translate(-150), 0))); }
            if (time == 2120) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 50, new Vector2(translate(-100), 0))); }
            if (time == 2150) { patternList.Add(new PolarPatterns(1, 36, 0, 300, -10, 0, 50, new Vector2(translate(-50), 0))); }
            if (time == 2180) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 50, new Vector2(translate(0), 0))); }
            if (time == 2210) { patternList.Add(new PolarPatterns(1, 36, 0, 300, -10, 0, 50, new Vector2(translate(50), 0))); }
            if (time == 2240) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 50, new Vector2(translate(100), 0))); }
            if (time == 2270) { patternList.Add(new PolarPatterns(1, 36, 0, 300, -10, 0, 50, new Vector2(translate(150), 0))); }
            if (time == 2300) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 50, new Vector2(translate(200), 0))); }
            if (time == 2330) { patternList.Add(new PolarPatterns(1, 36, 0, 300, -10, 0, 50, new Vector2(translate(250), 0))); }
            if (time == 2360) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 50, new Vector2(translate(300), 0))); }

            if (time == 2600) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(-300), 0))); }
            if (time == 2600) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(300), 500))); }
            if (time == 2625) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(-300), 0))); }
            if (time == 2625) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(300), 500))); }
            if (time == 2650) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(-300), 0))); }
            if (time == 2650) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(300), 500))); }
            if (time == 2675) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(-300), 0))); }
            if (time == 2675) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(300), 500))); }
            if (time == 2700) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(-300), 0))); }
            if (time == 2700) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(300), 500))); }
            if (time == 2725) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(-300), 0))); }
            if (time == 2725) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(300), 500))); }
            if (time == 2750) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(-300), 0))); }
            if (time == 2750) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(300), 500))); }
            if (time == 2775) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(-300), 0))); }
            if (time == 2775) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(300), 500))); }
            if (time == 2800) { patternList.Add(new PolarPatterns(1, 30, 0, 0, 0, 15, 250, new Vector2(translate(-300), 0))); }

            if (time == 3000) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 100, new Vector2(translate(75), 0))); }
            if (time == 3000) { patternList.Add(new PolarPatterns(1, 36, 0, 250, -10, 0, 100, new Vector2(translate(75), 0))); }
            if (time == 3025) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 100, new Vector2(translate(-75), 0))); }
            if (time == 3025) { patternList.Add(new PolarPatterns(1, 36, 0, 250, -10, 0, 100, new Vector2(translate(-75), 0))); }
            if (time == 3050) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 100, new Vector2(translate(75), 0))); }
            if (time == 3050) { patternList.Add(new PolarPatterns(1, 36, 0, 250, -10, 0, 100, new Vector2(translate(75), 0))); }
            if (time == 3075) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 100, new Vector2(translate(-75), 0))); }
            if (time == 3075) { patternList.Add(new PolarPatterns(1, 36, 0, 250, -10, 0, 100, new Vector2(translate(-75), 0))); }
            if (time == 3100) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 100, new Vector2(translate(75), 0))); }
            if (time == 3100) { patternList.Add(new PolarPatterns(1, 36, 0, 250, -10, 0, 100, new Vector2(translate(75), 0))); }
            if (time == 3125) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 100, new Vector2(translate(-75), 0))); }
            if (time == 3125) { patternList.Add(new PolarPatterns(1, 36, 0, 250, -10, 0, 100, new Vector2(translate(-75), 0))); }
            if (time == 3150) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 100, new Vector2(translate(75), 0))); }
            if (time == 3150) { patternList.Add(new PolarPatterns(1, 36, 0, 250, -10, 0, 100, new Vector2(translate(75), 0))); }
            if (time == 3175) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 100, new Vector2(translate(-75), 0))); }
            if (time == 3175) { patternList.Add(new PolarPatterns(1, 36, 0, 250, -10, 0, 100, new Vector2(translate(-75), 0))); }
            if (time == 3200) { patternList.Add(new PolarPatterns(0, 36, 0, 300, -10, 0, 100, new Vector2(translate(75), 0))); }
            if (time == 3200) { patternList.Add(new PolarPatterns(1, 36, 0, 250, -10, 0, 100, new Vector2(translate(75), 0))); }

            if (time == 3300)
            {
                for (int i = 0; i < 20; i++)
                {
                    patternList.Add(new PolarPatterns(0, 1, 0, 0, 70, 0, 300, new Vector2(translate(-500 + i*60), -(i % 2) * 20)));
                }
            }
            if (time == 3340)
            {
                for (int i = 0; i < 20; i++)
                {
                    patternList.Add(new PolarPatterns(0, 1, 0, 0, 110, 0, 300, new Vector2(translate(-500 + i * 60), -(i % 2) * 20)));
                }
            }
            if (time == 3380)
            {
                for (int i = 0; i < 20; i++)
                {
                    patternList.Add(new PolarPatterns(0, 1, 0, 0, 70, 0, 300, new Vector2(translate(-500 + i * 60), -(i % 2) * 20)));
                }
            }
            if (time == 3420)
            {
                for (int i = 0; i < 20; i++)
                {
                    patternList.Add(new PolarPatterns(0, 1, 0, 0, 110, 0, 300, new Vector2(translate(-500 + i * 60), -(i % 2) * 20)));
                }
            }

            if (time == 3550)
            {
                for (int i = 0; i < 80; i++)
                {
                    if (i < 15 || i > 17) patternList.Add(new PolarPatterns(1, 1, 0, 0, 70, 0, 350, new Vector2(translate(-500 + i * 25), -(i % 2) * 5)));
                }
            }
            if (time == 3600)
            {
                for (int i = 0; i < 80; i++)
                {
                    if (i < 8 || i > 10) patternList.Add(new PolarPatterns(1, 1, 0, 0, 70, 0, 350, new Vector2(translate(-500 + i * 25), -(i % 2) * 5)));
                }
            }
            if (time == 3650)
            {
                for (int i = 0; i < 80; i++)
                {
                    if (i < 15 || i > 17) patternList.Add(new PolarPatterns(1, 1, 0, 0, 70, 0, 350, new Vector2(translate(-500 + i * 25), -(i % 2) * 5)));
                }
            }
            if (time == 3700)
            {
                for (int i = 0; i < 80; i++)
                {
                    if (i < 6 || i > 8) patternList.Add(new PolarPatterns(1, 1, 0, 0, 70, 0, 350, new Vector2(translate(-500 + i * 25), -(i % 2) * 5)));
                }
            }

            if (time == 3805) { patternList.Add(new PolarPatterns(0, 50, 10, 0, 0, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3800) { patternList.Add(new PolarPatterns(1, 50, 10, 0, 15, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3805) { patternList.Add(new PolarPatterns(0, 50, 10, 0, 40, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3800) { patternList.Add(new PolarPatterns(1, 50, 10, 0, 55, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3805) { patternList.Add(new PolarPatterns(0, 50, 10, 0, 80, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3800) { patternList.Add(new PolarPatterns(1, 50, 10, 0, 95, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3805) { patternList.Add(new PolarPatterns(0, 50, 10, 0, 120, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3800) { patternList.Add(new PolarPatterns(1, 50, 10, 0, 135, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3805) { patternList.Add(new PolarPatterns(0, 50, 10, 0, 160, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3800) { patternList.Add(new PolarPatterns(1, 50, 10, 0, 175, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3805) { patternList.Add(new PolarPatterns(0, 50, 10, 0, 200, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3800) { patternList.Add(new PolarPatterns(1, 50, 10, 0, 215, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3805) { patternList.Add(new PolarPatterns(0, 50, 10, 0, 240, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3800) { patternList.Add(new PolarPatterns(1, 50, 10, 0, 255, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3805) { patternList.Add(new PolarPatterns(0, 50, 10, 0, 280, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3800) { patternList.Add(new PolarPatterns(1, 50, 10, 0, 295, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3805) { patternList.Add(new PolarPatterns(0, 50, 10, 0, 320, 30, 500, new Vector2(translate(0), -25), 10)); }
            if (time == 3800) { patternList.Add(new PolarPatterns(1, 50, 10, 0, 335, 30, 500, new Vector2(translate(0), -25), 10)); }

            if (time == 4450) { patternList.Add(new PolarPatterns(0, 200, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4500) { patternList.Add(new PolarPatterns(1, 190, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4550) { patternList.Add(new PolarPatterns(0, 180, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4600) { patternList.Add(new PolarPatterns(1, 170, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4650) { patternList.Add(new PolarPatterns(0, 160, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4700) { patternList.Add(new PolarPatterns(1, 150, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4750) { patternList.Add(new PolarPatterns(0, 140, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4800) { patternList.Add(new PolarPatterns(1, 130, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4850) { patternList.Add(new PolarPatterns(0, 120, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4900) { patternList.Add(new PolarPatterns(1, 110, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }
            if (time == 4950) { patternList.Add(new PolarPatterns(0, 100, 5, 0, 150, 0, 800, new Vector2(translate(0), 170), 3)); }

            time++;

            if (time == 5500) time = 1300;

            return EState.PlayState;
        }

        private float translate(float coordinate) { return coordinate + 480; }
    }
}
