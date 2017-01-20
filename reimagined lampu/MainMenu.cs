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
    /// MainMenu of the Game
    /// </summary>
    class MainMenu : IGameState
    {
        Vector2 cursorPos;

        Texture2D background;
        Texture2D cursorTexture;

        Texture2D splashScreen;
        Texture2D choice;
        Texture2D buttonActive;
        Texture2D buttonInactive;
        Texture2D buttonHover;

        bool onSplash;
        Button splash;
        Button play, stageOne, stageTwo, stageThree;
        Button options;
        Button about, exit;
        bool drawAbout;

        /// <summary>
        /// Make a new MainMenu
        /// </summary>
        /// <param name="Content">ContentManager of the Game. Used to load Content</param>
        /// <param name="toSplash">Set if MainMenu should start on Splash Screen</param>
        public MainMenu(ContentManager Content, bool toSplash = true)
        {
            onSplash = toSplash;
            LoadContent(Content);

            splash = new Button(active: buttonActive,inactive: buttonInactive,hover: buttonHover,position: new Vector2(500, 550),text: "START",textPosition: new Vector2(100,40),state: BtnState.active,visibility: onSplash);

            play = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(100, 100), text: "PLAY", textPosition: new Vector2(100, 40), state: BtnState.active, visibility: false, toolTip: "Let's play a game!");
            stageOne = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(370, 100), text: "Stage 1", textPosition: new Vector2(100, 40), state: BtnState.active, visibility: false, toolTip: "Are you ready for the first stage?");
            stageTwo = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(370, 200), text: "Stage 2", textPosition: new Vector2(100, 40), state: BtnState.inactive, visibility: false, toolTip: "You have to clear Stage 1 first!");
            stageThree = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(370, 300), text: "Stage 3", textPosition: new Vector2(100, 40), state: BtnState.inactive, visibility: false, toolTip: "You have to clear Stage 2 first!");

            options = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(950, 100), text: "Options", textPosition: new Vector2(100, 40), state: BtnState.inactive, visibility: false, toolTip: "This function isn't important, isn't it?");
            about = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(950, 250), text: "About", textPosition: new Vector2(100, 40), state: BtnState.active, visibility: false, toolTip: "You want to now more?");
            exit = new Button(active: buttonActive, inactive: buttonInactive, hover: buttonHover, position: new Vector2(950, 550), text: "EXIT", textPosition: new Vector2(100, 40), state: BtnState.active, visibility: false);
            drawAbout = false;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: background, position: new Vector2(0, 0), scale: new Vector2(2.0f / 3.0f, 2.0f / 3.0f), color: Color.White);

            splash.Draw(spriteBatch);
            play.Draw(spriteBatch);
            stageOne.Draw(spriteBatch);
            stageTwo.Draw(spriteBatch);
            stageThree.Draw(spriteBatch);
            options.Draw(spriteBatch);
            about.Draw(spriteBatch);
            exit.Draw(spriteBatch);
            if (drawAbout)
            {
                spriteBatch.DrawString(GameStuff.Instance.arial, "Let's write something here", new Vector2(370, 130), Color.White);
            }
            
            spriteBatch.Draw(cursorTexture, cursorPos, Color.White);
        }

        public void LoadContent(ContentManager Content)
        {
            splashScreen = Content.Load<Texture2D>("Splash");
            choice = Content.Load<Texture2D>("Menu");
            if (onSplash)
                background = splashScreen;
            else
                background = choice;

            buttonActive = Content.Load<Texture2D>("Button_idle");
            buttonInactive = Content.Load<Texture2D>("Button_pressed");
            buttonHover = Content.Load<Texture2D>("Button_hover");
            cursorTexture = Content.Load<Texture2D>("cursor");
        }

        public EState Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            cursorPos = new Vector2(mouseState.X, mouseState.Y);
            if (splash.Check(mouseState))
                changeButtons(0);

            if (play.Check(mouseState))
                changeButtons(1);

            if (stageOne.Check(mouseState))
                GameStuff.setGameState(EState.PlayState);
            stageTwo.Check(mouseState);
            stageThree.Check(mouseState);
            options.Check(mouseState);
            if (about.Check(mouseState))
            {
                changeButtons(3);
                //TODO: Print some Shit
            }
            if (exit.Check(mouseState))
                Environment.Exit(0);

            return EState.MainMenu;
        }

        private void changeButtons(int id)
        {
            switch (id)
            {
                case 0: //START
                    splash.setVisibility(false);
                    background = choice;
                    onSplash = false;

                    play.setVisibility(true);
                    options.setVisibility(true);
                    about.setVisibility(true);
                    exit.setVisibility(true);
                    break;
                case 1: //Play
                    stageOne.setVisibility(true);
                    stageTwo.setVisibility(true);
                    stageThree.setVisibility(true);
                    drawAbout = false;
                    break;
                case 2: //Options
                    break;
                case 3: //About
                    stageOne.setVisibility(false);
                    stageTwo.setVisibility(false);
                    stageThree.setVisibility(false);
                    drawAbout = true;
                    break;

            }
        }
    }
}
