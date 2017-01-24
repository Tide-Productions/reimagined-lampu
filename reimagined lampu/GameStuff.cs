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

namespace reimagined_lampu
{
    class GameStuff
    {
        static GameStuff instance;
        public Player player;
        public float grScale;
        public bool fullscreen;
        public float limitX1, limitX2, limitY1, limitY2; //Spielfeldgrenzen
        public SpriteFont arial;
        public Texture2D background;
        public Texture2D bulletTexture01;
        public Texture2D bulletTexture02;
        public EState currentState;
        public MainMenu mainMenu;
        public PlayState stage;
        public ContentManager Content;
        public Pause pause;
        public Death death;
        public ulong score;
        public Song mmgb;

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
                Instance.grScale = 1.0f;
                Instance.player.setPosition(new Vector2((Instance.player.getPosition().X*1920)/1280,(Instance.player.getPosition().Y*1080)/720));
                Instance.limitX1 = 330;
                Instance.limitX2 = 680;
                Instance.limitY1 = -5;
                Instance.limitY2 = 1060;
                graphics.ApplyChanges();
                Instance.fullscreen = true;
            }
            else
            {
                graphics.PreferredBackBufferWidth = 1280;
                graphics.PreferredBackBufferHeight = 720;
                Instance.grScale = (float) 2.0f/3.0f;
                Instance.player.setPosition(new Vector2((Instance.player.getPosition().X * 1280) / 1920, (Instance.player.getPosition().Y * 720) / 1080));
                Instance.limitX1 = 204.9f;
                Instance.limitX2 = 718;
                Instance.limitY1 = -4;
                Instance.limitY2 = 680;
                graphics.ApplyChanges();
                Instance.fullscreen = false;
            }
           
        }

        public static void setGameState(EState State, int id = 0)
        {
            if (State == EState.PlayState)
            {
                Instance.stage = new PlayState(Instance.Content);
                Instance.currentState = EState.PlayState;
            } if (State == EState.MainMenu)
            {
                Instance.currentState = EState.MainMenu;
            }
            if (State == EState.Death)
            {
                Instance.currentState = EState.Death;
            }
        }
        public static void togglePause()
        {
            if (Instance.currentState == EState.Pause){
                MediaPlayer.Resume();
                instance.currentState = EState.PlayState;
            } else
            {
                MediaPlayer.Pause();
                instance.pause.reset();
                instance.currentState = EState.Pause;
            }
        }
        public static void playmmbg()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.4f;
            MediaPlayer.Play(Instance.mmgb);
        }
    }
}
