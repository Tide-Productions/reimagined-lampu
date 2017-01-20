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
        Texture2D buttonActive;
        Texture2D buttonInactive;
        Texture2D buttonHover;

        Button play;

        public MainMenu(ContentManager Content)
        {
            LoadContent(Content);
            play = new Button(buttonActive, buttonInactive, buttonHover, new Vector2(200, 200),"PLAY", ButtonSta.active, true);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: background,position: new Vector2(0, 0),scale: new Vector2(2.0f/3.0f,2.0f/3.0f),color: Color.White);
            play.Draw(spriteBatch);
            spriteBatch.Draw(cursorTexture, cursorPos, Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("Menu");
            buttonActive = Content.Load<Texture2D>("bt_active");
            buttonInactive = Content.Load<Texture2D>("bt_inactive");
            buttonHover = Content.Load<Texture2D>("bt_hover");
            cursorTexture = Content.Load<Texture2D>("cursor");
        }

        public EState Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            cursorPos = new Vector2(mouseState.X, mouseState.Y);
            if (play.Check(mouseState))
            {
                GameStuff.setGameState(EState.PlayState);
            }
            return EState.MainMenu;
        }
    }
}
