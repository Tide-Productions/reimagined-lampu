using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace reimagined_lampu
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        bool releasedFsT;
        bool releasedEsc;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GameStuff.Instance.arial = Content.Load<SpriteFont>("Arial");
            GameStuff.Instance.Content = Content;
            GameStuff.Instance.limitX1 = 202.9f;
            GameStuff.Instance.limitX2 = 718;
            GameStuff.Instance.limitY1 = -4;
            GameStuff.Instance.limitY2 = 680;
            GameStuff.Instance.currentState = EState.MainMenu;
            GameStuff.Instance.grScale = 2.0f / 3.0f;
            GameStuff.Instance.mainMenu = new MainMenu(Content);
            GameStuff.Instance.score = 0;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameStuff.Instance.background = Content.Load<Texture2D>("space");
            //GameStuff.Instance.fullscreen = true;
            //GameStuff.toggleScreen(graphics);
            GameStuff.Instance.pause = new Pause(Content);
            GameStuff.Instance.death = new Death(Content);
            releasedFsT = true;
            releasedEsc = true;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Debug-Stuff
            if (Keyboard.GetState().IsKeyDown(Keys.K))
                GameStuff.setGameState(EState.Death);


            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.F11) && releasedFsT)
            {
                //GameStuff.toggleScreen(graphics);
                releasedFsT = false;
                graphics.ToggleFullScreen();
            }
            if (Keyboard.GetState().IsKeyUp(Keys.F11)) releasedFsT = true;

            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && releasedEsc && ((GameStuff.Instance.currentState == EState.PlayState) || GameStuff.Instance.currentState == EState.Pause))
            {
                GameStuff.togglePause();
                releasedEsc = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Escape)) releasedEsc = true;

            if (GameStuff.Instance.currentState == EState.PlayState)
            {
                GameStuff.Instance.currentState = GameStuff.Instance.stage.Update(gameTime);
            }
            if (GameStuff.Instance.currentState == EState.MainMenu)
            {
                GameStuff.Instance.mainMenu.Update(gameTime);
            }
            if (GameStuff.Instance.currentState == EState.Death)
            {
                GameStuff.Instance.death.Update(gameTime);
            }
            if (GameStuff.Instance.currentState == EState.Pause)
            {
                GameStuff.Instance.pause.Update(gameTime);
            }


            if (GameStuff.Instance.player != null && GameStuff.Instance.player.getHealth() <= 0)
            {
                GameStuff.setGameState(EState.Death);
                GameStuff.Instance.player.applyDamage(-100);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(GameStuff.Instance.background, new Vector2(200, 0), null, null, new Vector2(0, 0), 0.0f, new Vector2(GameStuff.Instance.grScale, GameStuff.Instance.grScale), Color.White, 0f);
            
            if (GameStuff.Instance.currentState == EState.PlayState)
            {
                GameStuff.Instance.stage.Draw(spriteBatch);
            }
            if (GameStuff.Instance.currentState == EState.MainMenu)
            {
                GameStuff.Instance.mainMenu.Draw(spriteBatch);
            }
            if (GameStuff.Instance.currentState == EState.Death)
            {
                GameStuff.Instance.death.Draw(spriteBatch);
            }
            if (GameStuff.Instance.currentState == EState.Pause)
            {
                GameStuff.Instance.pause.Draw(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
