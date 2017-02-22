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
        Vector2 cursorPos;

        Texture2D background;

        Texture2D buttonActive;
        Texture2D buttonInactive;
        Texture2D buttonHover;
        Texture2D cursorTexture;

        Button returnToGame;
        Button exit;
        Button returnToMain;
        Button options;
        Button retry;

        public Pause(ContentManager Content)
        {
            LoadContent(Content);
            returnToGame = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(500, 90), text: "Continue", textPosition: new Vector2(85, 40), state: BtnState.active, visibility: true);
            options = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(500, 290), text: "Options", textPosition: new Vector2(90, 40), state: BtnState.inactive, visibility: true, toolTip: "This feature isn't important, is it?");
            returnToMain = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(500, 450), text: "Main Menu", textPosition: new Vector2(80, 40), state: BtnState.active, visibility: true);
            exit = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(500, 550), text: "EXIT", textPosition: new Vector2(100, 40), state: BtnState.active, visibility: true);
            retry = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(500, 190), text: "Retry", textPosition: new Vector2(90, 40), state: BtnState.active, visibility: true);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0), scale: new Vector2(GameStuff.Instance.grScale), color: Color.White);
            returnToGame.Draw(spriteBatch);
            options.Draw(spriteBatch);
            returnToMain.Draw(spriteBatch);
            exit.Draw(spriteBatch);
            retry.Draw(spriteBatch);
            spriteBatch.Draw(cursorTexture, cursorPos, Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("Menu");
            buttonActive = Content.Load<Texture2D>("Button_idle");
            buttonInactive = Content.Load<Texture2D>("Button_pressed");
            buttonHover = Content.Load<Texture2D>("Button_hover");
            cursorTexture = Content.Load<Texture2D>("cursor");
        }

        public EState Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            cursorPos = new Vector2(mouseState.X, mouseState.Y);

            if (returnToGame.Check(mouseState))
            {
                GameStuff.togglePause();
            }
            options.Check(mouseState);
            if (returnToMain.Check(mouseState))
            {
                GameStuff.Instance.currentState = EState.MainMenu;
            }
            if (exit.Check(mouseState))
            {
                Environment.Exit(0);
            }
            if (retry.Check(mouseState))
            {
                GameStuff.setGameState(EState.PlayState);
            }
            return EState.Pause;
        }

        public void reset()
        {

        }
    }
}
