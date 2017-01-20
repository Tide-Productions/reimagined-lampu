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
    enum BtnState
    {
        active,
        inactive,
        hover
    } 
    class Button
    {
        BtnState current;
        Texture2D active;
        Texture2D inactive;
        Texture2D hover;
        Vector2 position;
        Vector2 textPosition;
        string text;
        bool visibility;
        bool drawToolTip;
        string toolTipText;
        Color? writingColor;

        public Button(Texture2D active, Texture2D inactive, Texture2D hover, Vector2 position, string text , Vector2 textPosition, BtnState state, bool visibility, Color? color = null, string toolTip = "")
        {
            this.active = active;
            this.inactive = inactive;
            this.hover = hover;
            this.position = position;
            this.text = text;
            this.textPosition = textPosition;
            current = state;
            this.visibility = visibility;
            if (color == null)
                writingColor = Color.White;
            else
                writingColor = color;
            this.toolTipText = toolTip;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visibility)
            {
                switch (current)
                {
                    case BtnState.active:
                        spriteBatch.Draw(active, position, (Color) writingColor);
                        spriteBatch.DrawString(spriteFont: GameStuff.Instance.arial, text: text, position: position + textPosition, color: Color.White);
                        break;
                    case BtnState.inactive:
                        spriteBatch.Draw(inactive, position, Color.White);
                        spriteBatch.DrawString(spriteFont: GameStuff.Instance.arial, text: text, position: position + textPosition, color: Color.Gray);
                        break;
                    case BtnState.hover:
                        spriteBatch.Draw(hover, position, (Color) writingColor);
                        spriteBatch.DrawString(spriteFont: GameStuff.Instance.arial, text: text, position: position + textPosition, color: Color.White);
                        break;
                }
                if (drawToolTip)
                    spriteBatch.DrawString(spriteFont: GameStuff.Instance.arial,text: toolTipText,position: new Vector2(500, 50),color: (Color) writingColor);
            }
        }

        public bool Check(MouseState mouseState)
        {
            if (visibility) {
                if (mouseState.X >= position.X && mouseState.X <= (position.X + active.Width) && mouseState.Y >= position.Y && mouseState.Y <= (position.Y + active.Height))
                {
                    drawToolTip = true;
                    if (current == BtnState.active || current == BtnState.hover)
                    {
                        current = BtnState.hover;

                        if (mouseState.LeftButton == ButtonState.Pressed && visibility)
                        {
                            return true;
                        }
                    }

                } else
                {
                    if (current == BtnState.hover)
                        current = BtnState.active;
                    drawToolTip = false;
                }
            }
            return false;
        }
        public void setState(BtnState State)
        {
            current = State;
        }
        public void setVisibility(bool visibility)
        {
            this.visibility = visibility;
        }
    }
}
