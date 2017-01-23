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
    class Death : IGameState
    {
        Texture2D background;
        Button goBack;

        Texture2D buttonActive;
        Texture2D buttonInactive;
        Texture2D buttonHover;
        Texture2D cursorTexture;
        Vector2 cursorPos;

        public Death(ContentManager Content)
        {
            LoadContent(Content);
            goBack = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(200, 50), text: "That's sad", textPosition: new Vector2(80, 40), state: BtnState.active, visibility: false);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: background, position: new Vector2(0), scale: new Vector2(GameStuff.Instance.grScale), color: Color.White);
            spriteBatch.DrawString(GameStuff.Instance.arial, "You have died...", new Vector2(30), Color.White);
            spriteBatch.DrawString(GameStuff.Instance.arial, "Press Enter ...", new Vector2(30, 620), Color.White);
            goBack.Draw(spriteBatch);
            //spriteBatch.Draw(cursorTexture, cursorPos, Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("Death");
            buttonActive = Content.Load<Texture2D>("Button_idle");
            buttonInactive = Content.Load<Texture2D>("Button_pressed");
            buttonHover = Content.Load<Texture2D>("Button_hover");
            cursorTexture = Content.Load<Texture2D>("cursor");
        }

        public EState Update(GameTime gameTime)
        {
            cursorPos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) || goBack.Check(Mouse.GetState()))
            {
                GameStuff.Instance.mainMenu.reset();
                GameStuff.setGameState(EState.MainMenu);
            }
            return EState.Death;
        }
    }
}
