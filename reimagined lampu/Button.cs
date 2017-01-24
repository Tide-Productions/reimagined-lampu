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
    /// <summary>
    /// Possible states of a Button
    /// </summary>
    enum BtnState
    {
        active,
        inactive,
        hover
    } 

    /// <summary>
    /// A Button
    /// </summary>
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

        /// <summary>
        /// Create a new Button
        /// </summary>
        /// <param name="active">Texture for the active state</param>
        /// <param name="inactive">Texture for the inactive state</param>
        /// <param name="hover">Texture for the hover state</param>
        /// <param name="position">Position of the Button (top left corner)</param>
        /// <param name="text">Text inside the Button</param>
        /// <param name="textPosition">Position of the text inside the Button</param>
        /// <param name="state">Startingstate of the Button</param>
        /// <param name="visibility">set if the Button should be inital visible</param>
        /// <param name="color">Color of the Text (standard Color.White)</param>
        /// <param name="toolTip">Text of the Tooltip while hovering over the Button</param>
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

        /// <summary>
        /// Draw Methode for the Button
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch on which will be drawn</param>
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

        /// <summary>
        /// Like an Update-Methode but this returns if clicked
        /// </summary>
        /// <param name="mouseState">MouseState of the used Mouse</param>
        /// <returns>If Button was klicked on</returns>
        public bool Check(MouseState mouseState)
        {
            if (visibility) {
                if (mouseState.X+16 >= position.X && mouseState.X+16 <= (position.X + active.Width) && mouseState.Y >= position.Y && mouseState.Y <= (position.Y + active.Height))
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

        /// <summary>
        /// Changes the current state of the Button
        /// </summary>
        /// <param name="State">state which it will change to</param>
        public void setState(BtnState State)
        {
            current = State;
        }

        /// <summary>
        /// Sets if Button will be drawn
        /// </summary>
        /// <param name="visibility">true - will be drawn | false - will not be drawn</param>
        public void setVisibility(bool visibility)
        {
            this.visibility = visibility;
        }
    }
}
