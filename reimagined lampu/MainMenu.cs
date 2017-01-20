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
    class MainMenu : IGameState
    {
        Vector2 cursorPos;

        Texture2D background;
        Texture2D cursorTexture;

        Texture2D splashScreen;
        Texture2D choice;
        Texture2D buttonActive;
        Texture2D buttonInactive;
        Texture2D buttonHover;

        bool onSplash;
        Button splash;

        public MainMenu(ContentManager Content, bool toSplash = true)
        {
            onSplash = toSplash;
            LoadContent(Content);
            splash = new Button(buttonActive, buttonInactive, buttonHover, new Vector2(500, 400),"PLAY", new Vector2(100,40), BtnState.active, true);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: background, position: new Vector2(0, 0), scale: new Vector2(2.0f / 3.0f, 2.0f / 3.0f), color: Color.White);

            splash.Draw(spriteBatch);

            spriteBatch.Draw(cursorTexture, cursorPos, Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            splashScreen = Content.Load<Texture2D>("Menu");
            //choice = ;
            if (onSplash)
                background = splashScreen;
            else
                background = splashScreen;
            buttonActive = Content.Load<Texture2D>("Button_idle");
            buttonInactive = Content.Load<Texture2D>("Button_pressed");
            buttonHover = Content.Load<Texture2D>("Button_hover");
            cursorTexture = Content.Load<Texture2D>("cursor");
        }

        public EState Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            cursorPos = new Vector2(mouseState.X, mouseState.Y);
            if (splash.Check(mouseState))
            {
                //splash.setVisibility(false);
                GameStuff.setGameState(EState.PlayState);
            }
            return EState.MainMenu;
        }
    }
}
