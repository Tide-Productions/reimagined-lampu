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
        Texture2D overlay;
        bool releasedFsT;
        PolarPatterns test;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            GameStuff.Instance.limitX1 = 220;
            GameStuff.Instance.limitX2 = 740;
            GameStuff.Instance.limitY1 = 10;
            GameStuff.Instance.limitX2 = 700;
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
            test = new PolarPatterns(0, 1, 36, 0, 0, 0, 50, 100, new Vector2(300, 300), 8); 
            GameStuff.Instance.arial = Content.Load<SpriteFont>("Arial");
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
            GameStuff.Instance.player = new Player(Content.Load<Texture2D>("player"), new Vector2(600, 350), 5.0f);
            overlay = Content.Load<Texture2D>("overlay");
            GameStuff.Instance.bulletTexture01 = Content.Load<Texture2D>("bullets/Bullet1");
            GameStuff.Instance.bulletTexture02 = Content.Load<Texture2D>("bullets/Bullet2");
            GameStuff.Instance.grScale = (float) 2/3;
            GameStuff.Instance.background = Content.Load<Texture2D>("space");
            GameStuff.Instance.fullscreen = false;
            releasedFsT = true;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            GameStuff.Instance.player.Update();
            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.F11) && releasedFsT)
            {
                GameStuff.toggleScreen(graphics);
                releasedFsT = false;
                graphics.ToggleFullScreen();
            }
            if (Keyboard.GetState().IsKeyUp(Keys.F11)) releasedFsT = true;

            test.Update();
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
            test.Draw(spriteBatch);

            GameStuff.Instance.player.Draw(spriteBatch);

            spriteBatch.Draw(overlay, new Vector2(0, 0), null, null, new Vector2(0, 0), 0.0f, new Vector2(GameStuff.Instance.grScale, GameStuff.Instance.grScale), Color.White, 0f);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
