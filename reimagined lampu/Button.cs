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
    enum ButtonSta
    {
        active,
        inactive,
        hover
    } 
    class Button
    {
        ButtonSta current;
        Texture2D active;
        Texture2D inactive;
        Texture2D hover;
        Vector2 position;
        string text;
        bool visibility;

        public Button(Texture2D active, Texture2D inactive, Texture2D hover, Vector2 position, string text , ButtonSta state, bool visibility)
        {
            this.active = active;
            this.inactive = inactive;
            this.hover = hover;
            this.position = position;
            this.text = text;
            current = state;
            this.visibility = visibility;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visibility)
            {
                switch (current)
                {
                    case ButtonSta.active:
                        spriteBatch.Draw(active, position, Color.White);
                        break;
                    case ButtonSta.inactive:
                        spriteBatch.Draw(inactive, position, Color.White);
                        break;
                    case ButtonSta.hover:
                        spriteBatch.Draw(hover, position, Color.White);
                        break;
                }
                spriteBatch.DrawString(GameStuff.Instance.arial, text, position + new Vector2(20, 13), Color.White);
            }
        }

        public bool Check(MouseState mouseState)
        {
            if ((current == ButtonSta.active || current == ButtonSta.hover) && visibility) {
                if (mouseState.X >= position.X && mouseState.X <= (position.X + active.Width) && mouseState.Y >= position.Y && mouseState.Y <= (position.Y + active.Height))
                {
                    current = ButtonSta.hover;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        current = ButtonSta.inactive;
                        return true;
                    }
                }
                else
                {
                    current = ButtonSta.active;
                }
            }
            return false;
        }
        public void setState(ButtonSta State)
        {
            current = State;
        }
        public void setVisibility(bool visibility)
        {
            this.visibility = visibility;
        }
    }
}
