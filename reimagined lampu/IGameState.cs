using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace reimagined_lampu
{
    enum EState
    {
        None,
        MainMenu,
        PlayState,
        Exit
    }
    interface IGameState
    {
        void LoadContent(ContentManager Content);
        void Draw(SpriteBatch spriteBatch);
        EState Update(GameTime gameTime);
    }
}
