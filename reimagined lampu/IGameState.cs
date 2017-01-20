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
    /// <summary>
    /// Possible states of the Game
    /// </summary>
    enum EState
    {
        None,
        MainMenu,
        PlayState,
        Exit
    }
    /// <summary>
    /// Interface to standardize the states of the Game
    /// </summary>
    interface IGameState
    {
        /// <summary>
        /// Load the Content for the state
        /// </summary>
        /// <param name="Content">used ContentManager</param>
        void LoadContent(ContentManager Content);

        /// <summary>
        /// Draw Methode to draw Stuff
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch on which will be drawn</param>
        void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Update of the current state
        /// </summary>
        /// <param name="gameTime">GameTime of the Game</param>
        /// <returns></returns>
        EState Update(GameTime gameTime);
    }
}
