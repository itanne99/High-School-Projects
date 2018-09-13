using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Multi_Level
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game World
        enum GameState
        {
            titleScreen, playingGame, endScreen
        }
        bool endGameSenario;

        GameState state = GameState.titleScreen;

        //Game Controls
        MouseState mouse, oldMouse;
        Point mousePoint;
        KeyboardState keyboard, oldKeyboard;

        //Sound Effects
        SoundEffect coinDing;
        List<Song> gameMusic = new List<Song>();
        Song mario1, mario2, mario3, mario4;
        int currentSong;

        //Board
        IList<Rectangle> tileRect = new List<Rectangle>();
        Texture2D tileTexture;
        int tileAmount, tileAmountOld, level;
        Random rnd = new Random();
        
        //Custom Mouse
        Texture2D marioMouse;
        Rectangle marioMouseRect;

        //Main Menu Picture
        Texture2D marioFace, marioCoinAdventure, playButton, playButtonMouseOver;
        Rectangle marioFaceRect, marioCoinAdventureRect, playButtonRect, playButtonMouseOverRect;

        //In Game Background
        Texture2D marioBackground1;
        Rectangle marioBackgroundRect;

        //Game Over
        Texture2D gameOver, tryAgain, yesButton, yesButtonMouseOver, noButton, noButtonMouseOver;
        Rectangle gameOverRect, tryAgainRect, yesButtonRect, noButtonRect;
        SoundEffect gameOverSound;

        //Level Complete
        Texture2D levelComplete, nextButton, nextButtonMoveOver;
        Rectangle levelCompleteRect, nextButtonRect;
        SoundEffect levelComleteSound;
        SoundEffectInstance Sound1Instance;

        //Timer
        float Timer;
        Boolean timerStart;

        //Display font
        SpriteFont font, titleFont;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Music
            mario1 = Content.Load<Song>("Overworld Theme");
            mario2 = Content.Load<Song>("Underwater Theme");
            mario3 = Content.Load<Song>("Mario Kart 8 Theme Song");
            mario4 = Content.Load<Song>("Super Mario Odyssey Theme");
            gameMusic.Add(mario1);
            gameMusic.Add(mario2);
            gameMusic.Add(mario3);
            gameMusic.Add(mario4);
            currentSong = rnd.Next(0, gameMusic.Count());
            MediaPlayer.Play(gameMusic.ElementAt(currentSong));
            coinDing = Content.Load<SoundEffect>("Coin Sound Effect");
            levelComleteSound = Content.Load<SoundEffect>("Super Mario Level Complete");
            Sound1Instance = levelComleteSound.CreateInstance();
            gameOverSound = Content.Load<SoundEffect>("Super Mario Game Over");
            //Textures
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //IsMouseVisible = true;
            font = Content.Load<SpriteFont>("Font1");
            state = GameState.titleScreen;
            tileTexture = Content.Load<Texture2D>("Tile");
            marioFace = Content.Load<Texture2D>("supermariohair");
            marioFaceRect = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            marioCoinAdventure = Content.Load<Texture2D>("Marios coin adventure");
            marioCoinAdventureRect = new Rectangle(275, 0, 250, 200);
            playButton = Content.Load<Texture2D>("marioPlay");
            playButtonRect = new Rectangle(250, 220, 300, 100);
            playButtonMouseOver = Content.Load<Texture2D>("marioPlayMouseOver");
            playButtonMouseOverRect = playButtonRect;
            marioBackground1 = Content.Load<Texture2D>("MarioBackground1");
            marioBackgroundRect = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            gameOver = Content.Load<Texture2D>("Mario Game Over");
            gameOverRect = new Rectangle(150, 0, 500, 100);
            tryAgain = Content.Load<Texture2D>("Mario Try Again");
            tryAgainRect = new Rectangle(215, 100, 400, 100);
            yesButton = Content.Load<Texture2D>("Mario Yea");
            yesButtonMouseOver = Content.Load<Texture2D>("Mario Yea Mouse OVer");
            yesButtonRect = new Rectangle(185, 300, 150, 50);
            noButton = Content.Load<Texture2D>("Mario Nah");
            noButtonMouseOver = Content.Load<Texture2D>("Mario Nah Mouse OVer");
            noButtonRect = new Rectangle((yesButtonRect.X+300), yesButtonRect.Y, 150, 50);
            levelComplete = Content.Load<Texture2D>("Mario Level Complete");
            levelCompleteRect = new Rectangle(150, 0, 500, 200);
            nextButton = Content.Load<Texture2D>("Mario Next");
            nextButtonMoveOver = Content.Load<Texture2D>("Mario Next Mouse Over");
            nextButtonRect = new Rectangle(275, 250, 250, 100);
            marioMouse = Content.Load<Texture2D>("mario mouse");
            
            //Functions
            timerStart = true;
            tileAmount = 10;
            level = 1;
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        void UpdateTitleScreen()
        {
            
            //Debug Menu
            if (keyboard.IsKeyDown(Keys.F1) && oldKeyboard.IsKeyUp(Keys.F1))
                state = GameState.titleScreen;
            if (keyboard.IsKeyDown(Keys.F2) && oldKeyboard.IsKeyUp(Keys.F2))
                state = GameState.playingGame;
            if (keyboard.IsKeyDown(Keys.F3) && oldKeyboard.IsKeyUp(Keys.F3))
            {
                endGameSenario = false;
                state = GameState.endScreen;
            }
            if (keyboard.IsKeyDown(Keys.F4) && oldKeyboard.IsKeyUp(Keys.F4))
            {
                endGameSenario = true;
                state = GameState.endScreen;
            }
            //Main User Control
            if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
                if (playButtonMouseOverRect.Contains(mousePoint))
                {
                    state = GameState.playingGame;
                }

        }
        void DrawTitleScreen()
        {
            
            spriteBatch.Draw(marioFace, marioFaceRect, Color.White);
            //spriteBatch.DrawString(font,"MultiLevel",new Vector2((graphics.GraphicsDevice.Viewport.Width/2 - font.MeasureString("MultiLevel").Length()),0), Color.Beige);
            //spriteBatch.DrawString(font, "To Start Press Enter", new Vector2(300, 150), Color.Green);
            spriteBatch.Draw(marioCoinAdventure, marioCoinAdventureRect, Color.White);
            if (playButtonMouseOverRect.Contains(mousePoint))
                spriteBatch.Draw(playButtonMouseOver, playButtonMouseOverRect, Color.White);
            else
                spriteBatch.Draw(playButton, playButtonRect, Color.White);
            
            spriteBatch.DrawString(font, "Note: All Music was retreived from Youtube", new Vector2((graphics.GraphicsDevice.Viewport.Width - font.MeasureString("Note: All Music was retreived from Youtube").Length()), graphics.GraphicsDevice.Viewport.Height-20), Color.White);
            
        }
        void UpdateGamePlay()
        {
            
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(gameMusic.ElementAt(rnd.Next(0, gameMusic.Count())));
            }
            if (timerStart)
            {
                Timer = 60 * 30;
                if (level == 1)
                {
                    tileAmount = 10;
                }
                if (level > 1)
                {
                    tileAmountOld = tileAmount;
                    tileAmount = 10 + (((level/2)*tileAmountOld)/2);
                }
                if (level > 6)
                {
                    tileAmountOld = tileAmount;
                    tileAmount = 10 + (((level / 3) * tileAmountOld) / 3);
                }
                if (level > 9)
                {
                    tileAmountOld = tileAmount;
                    tileAmount = 10 + (((level / 4) * tileAmountOld) / 4);
                }
                if (level > 12)
                {
                    tileAmountOld = tileAmount;
                    tileAmount = 10 + (((level / 5) * tileAmountOld) / 5);
                }

                for (int i = 0; i < tileAmount; i++)
                {
                    tileRect.Add(new Rectangle(rnd.Next(0, GraphicsDevice.Viewport.Width-35), rnd.Next(45, GraphicsDevice.Viewport.Height-35), 35, 35));   
                }

                
                timerStart = false;
            }
            
            if(mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
            {
                for (int i = 0; i < tileRect.Count(); i++)
                {
                    if (tileRect[i].Contains(mousePoint))
                    {
                        tileRect.RemoveAt(i);
                        coinDing.Play();
                    }
                }
            }
            if (!timerStart)
            {
                Timer--;
            }
            if (Timer == 0 || tileRect.Count()==0)
            {
                MediaPlayer.Pause();
                if (Timer == 0)
                {
                    
                    gameOverSound.Play();
                    endGameSenario = false;
                }
                if (tileRect.Count() == 0)
                {
                    Sound1Instance.Play();
                    endGameSenario = true;
                }
                state = GameState.endScreen;
            }
            
            
            
        }
        
        void DrawGamePlay()
        {
            
            spriteBatch.Draw(marioBackground1, marioBackgroundRect, Color.White);
            spriteBatch.DrawString(font, "Timer: " + (Timer/60).ToString("0"), new Vector2(0, 0), Color.Black);
            spriteBatch.DrawString(font, "Tiles Left: " + tileRect.Count(), new Vector2(0, 20), Color.Black);
            spriteBatch.DrawString(font, "Level : " + level, new Vector2(0, 40), Color.Black);
            foreach(Rectangle rect in tileRect)
                spriteBatch.Draw(tileTexture, rect, Color.White);
            
        }
        void UpdateEndScreen()
        {
            
            if (endGameSenario == false)
            {
                for (int i = 0; i < tileRect.Count(); i++)
                    tileRect.RemoveAt(i);
                if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
                {
                    if(yesButtonRect.Contains(mousePoint))
                    {
                        level=1;
                        timerStart = true;
                        MediaPlayer.Resume();
                        state = GameState.playingGame;
                    }
                }
                if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
                    if(noButtonRect.Contains(mousePoint))
                        this.Exit();
            }
            if (endGameSenario == true)
            {
                if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
                {
                    if (nextButtonRect.Contains(mousePoint))
                    {
                        Sound1Instance.Stop();
                        level++;
                        timerStart = true;
                        state = GameState.playingGame;
                        MediaPlayer.Resume();
                        
                    }
                }
            }
        }
        void DrawEndScreen()
        {
            
            spriteBatch.Draw(marioBackground1, marioBackgroundRect, Color.White);
            if (endGameSenario == false)
            {
                spriteBatch.Draw(gameOver, gameOverRect, Color.White);
                spriteBatch.Draw(tryAgain, tryAgainRect, Color.White);
                if (yesButtonRect.Contains(mousePoint))
                    spriteBatch.Draw(yesButtonMouseOver, yesButtonRect, Color.White);
                else
                    spriteBatch.Draw(yesButton, yesButtonRect, Color.White);
                if (noButtonRect.Contains(mousePoint))
                    spriteBatch.Draw(noButtonMouseOver, noButtonRect, Color.White);
                else
                    spriteBatch.Draw(noButton, noButtonRect, Color.White);
                //spriteBatch.DrawString(font, "Look's like you didn't get all the tiles in time\nTry Again??\nPress 'Enter' to restrart\nPress 'Esc' to Quit", new Vector2(GraphicsDevice.Viewport.Width / 3, GraphicsDevice.Viewport.Height / 2), Color.White);
            }
            if (endGameSenario == true)
            {
                spriteBatch.Draw(levelComplete, levelCompleteRect, Color.White);
                if (nextButtonRect.Contains(mousePoint))
                    spriteBatch.Draw(nextButtonMoveOver, nextButtonRect, Color.White);
                else
                    spriteBatch.Draw(nextButton, nextButtonRect, Color.White);
                //spriteBatch.DrawString(font, "Level Complete!!\nPress Enter to go to the next Level!!", new Vector2(GraphicsDevice.Viewport.Width / 3, GraphicsDevice.Viewport.Height / 2), Color.White);
            } 
            
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();

            mousePoint = new Point(mouse.X, mouse.Y);

            marioMouseRect = new Rectangle(mousePoint.X, mousePoint.Y, 25, 25);

            switch (state)
            {
                case GameState.titleScreen:
                    UpdateTitleScreen();
                    break;
                case GameState.playingGame:
                    UpdateGamePlay();
                    break;
                case GameState.endScreen:
                    UpdateEndScreen();
                    break;

            }

            oldMouse = mouse;
            oldKeyboard = keyboard;
            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            switch (state)
            {
                case GameState.titleScreen:
                    DrawTitleScreen();
                    break;
                case GameState.playingGame:
                    DrawGamePlay();
                    break;
                case GameState.endScreen:
                    DrawEndScreen();
                    break;

            }
            //spriteBatch.DrawString(font, currentSong.ToString(), new Vector2(0, graphics.GraphicsDevice.Viewport.Height - 40), Color.Black);
            switch (currentSong)
            {
                case 0:
                    spriteBatch.DrawString(font, "Mario Super Bros. Overworld Theme", new Vector2(0, graphics.GraphicsDevice.Viewport.Height-20), Color.Black);
                    break;
                case 1:
                    spriteBatch.DrawString(font, "Mario Super Bros. Underwater Theme", new Vector2(0, graphics.GraphicsDevice.Viewport.Height - 20), Color.Black);
                    break;
                case 2:
                    spriteBatch.DrawString(font, "Mario Kart 8 Theme", new Vector2(0, graphics.GraphicsDevice.Viewport.Height - 20), Color.Black);
                    break;
                case 3:
                    spriteBatch.DrawString(font, "Super Mario Odyssey Theme", new Vector2(0, graphics.GraphicsDevice.Viewport.Height - 20), Color.Black);
                    break;
            }
            spriteBatch.Draw(marioMouse, marioMouseRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
