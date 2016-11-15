﻿using System;
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
        public float limitX1, limitX2, limitY1, limitY2; //Spielfeldgrenzen

        public Texture2D bulletTexture01;
        public Texture2D bulletTexture02;

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
                Instance.player.setPosition(new Vector2((Instance.player.getPosition().X*1920)/1280,(Instance.player.getPosition().Y*1080)/720));
                graphics.ApplyChanges();
                Instance.fullscreen = true;
            } else
            {
                graphics.PreferredBackBufferWidth = 1280;
                graphics.PreferredBackBufferHeight = 720;
                Instance.grScale = (float) 2/3;
                Instance.player.setPosition(new Vector2((Instance.player.getPosition().X * 1280) / 1920, (Instance.player.getPosition().Y * 720) / 1080));
                Instance.limitX1 = 330;
                Instance.limitX2 = 1000;
                Instance.limitY1 = 0;
                Instance.limitX2 = 900;
                graphics.ApplyChanges();
                Instance.fullscreen = false;
            }
           
        }
    }
}
