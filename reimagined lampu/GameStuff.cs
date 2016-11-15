using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace reimagined_lampu
{
    class GameStuff
    {

        static GameStuff instance;
        public Player player;
        public float grScale;
        public bool fullscreen;

        public GameStuff()
        {

        }
        public static GameStuff Instance
        {
            get
            {
                if (instance == null) instance = new GameStuff();
                return instance;
            }
            set
            {

            }
        }
        public static void toggleScreen(GraphicsDeviceManager graphics)
        {
            if (!Instance.fullscreen)
            {
                graphics.PreferredBackBufferWidth = 1920;
                graphics.PreferredBackBufferHeight = 1080;
                Instance.grScale = 1f;
                graphics.ApplyChanges();
                Instance.fullscreen = true;
            } else
            {
                graphics.PreferredBackBufferWidth = 1280;
                graphics.PreferredBackBufferHeight = 720;
                Instance.grScale = (float) 2/3;
                graphics.ApplyChanges();
                Instance.fullscreen = false;
            }
           
        }
    }
}
