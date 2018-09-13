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

namespace Path_Finder
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Control
        MouseState mouse, mouseOld;
        Point mousePoint;
        KeyboardState keyboard, keyboardOld;

        //Gamestates
        enum GameState
        {
            titleScreen, mainGame, endScreen
        }
        GameState state = GameState.titleScreen;

        //Main Game
        Texture2D grid, gridSafe, gridBomb, gridHealth;
        List<Rectangle> gridRect = new List<Rectangle>();
        List<Texture2D> gridType = new List<Texture2D>();
        List<int> gridTypeAt = new List<int>();
        List<bool> gridClickable = new List<bool>();
        int xBoard, yBoard;
        bool loadingDone = false;
        bool mouseLeftDown;
        int safeAmount, bombAmount, healthAmount;
        int timer, gridLeft;

        //End Screen
        bool endScreenSenario;
        Texture2D youWon, youLost, playAgainButton, mouseOverButton;
        Rectangle endScreenTitleRect, playAgainButtonRect, quitButtonEndScreenRect; 

        //Functions
        Random rnd = new Random();
        int score, level, health;

        //Font
        SpriteFont font;

        //Title Screen
        Texture2D title, playButton, playButtonClicked, difficultyButton, difficultyMouseOver,  quitButton, quitButtonClicked;
        Rectangle titleRect, playButtonRect, difficultyButtonRect, quitButtonRect;
        int difficulty;

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
            IsMouseVisible = true;
            
            //Font
            font = Content.Load<SpriteFont>("Font1");

            //TitleScreen
            playButton = Content.Load<Texture2D>("Play Button");
            playButtonClicked = Content.Load<Texture2D>("Play Button Clicked");
            playButtonRect = new Rectangle(300, (graphics.GraphicsDevice.Viewport.Height / 2)-150, 200, 100);
            difficultyButton = Content.Load<Texture2D>("Easy Button");
            difficultyMouseOver = Content.Load<Texture2D>("Mouse Over Button");
            difficultyButtonRect = new Rectangle(300, (graphics.GraphicsDevice.Viewport.Height / 2)-25, 200, 100);
            quitButton = Content.Load<Texture2D>("Quit Button");
            quitButtonClicked = Content.Load<Texture2D>("Quit Button Clicked");
            quitButtonRect = new Rectangle(300, (graphics.GraphicsDevice.Viewport.Height / 2) + 100, 200, 100);
            
            difficulty = 1;

            //MainGame
            grid = Content.Load<Texture2D>("UnknownGrid"); gridBomb = Content.Load<Texture2D>("BombGrid");
            gridSafe = Content.Load<Texture2D>("ClearGrid"); gridHealth = Content.Load<Texture2D>("HealGrid");
            gridType.Add(gridSafe); gridType.Add(gridBomb); gridType.Add(gridHealth); gridType.Add(grid);
            mouseLeftDown = false;

            //EndScreen
            youWon = Content.Load<Texture2D>("You Won");
            endScreenTitleRect = new Rectangle(150, 0, 500, 300);
            youLost = Content.Load<Texture2D>("You Lost");
            playAgainButton = Content.Load<Texture2D>("Play Again Button");
            mouseOverButton = Content.Load<Texture2D>("Mouse over");
            quitButtonEndScreenRect = new Rectangle(500, (graphics.GraphicsDevice.Viewport.Height / 2) + 100, 200, 100);
            playAgainButtonRect = new Rectangle(quitButtonEndScreenRect.X - 400, quitButtonEndScreenRect.Y, quitButtonEndScreenRect.Width, quitButtonEndScreenRect.Height);

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
            if(mouse.LeftButton == ButtonState.Pressed && mouseOld.LeftButton == ButtonState.Released)
            {
                if (playButtonRect.Contains(mousePoint))
                    state = GameState.mainGame;
                if(difficultyButtonRect.Contains(mousePoint))
                {
                    difficulty++;
                    if (difficulty > 3)
                        difficulty = 1;
                }
                if (quitButtonRect.Contains(mousePoint))
                    this.Exit();
            }
        }
        void DrawTitleScreen()
        {
            //spriteBatch.DrawString(font, "Hi", new Vector2(150, 30), Color.White);
            switch(difficulty)
            {
                case 1:
                    difficultyButton = Content.Load<Texture2D>("Easy Button");
                    break;
                case 2:
                    difficultyButton = Content.Load<Texture2D>("Medium Button");
                    break;
                case 3:
                    difficultyButton = Content.Load<Texture2D>("Hard Button");
                    break;
            }
            spriteBatch.Draw(difficultyButton, difficultyButtonRect, Color.White);
            if (difficultyButtonRect.Contains(mousePoint))
                spriteBatch.Draw(difficultyMouseOver, difficultyButtonRect, Color.White);

            if (playButtonRect.Contains(mousePoint))
                spriteBatch.Draw(playButtonClicked, playButtonRect, Color.White);
            else
                spriteBatch.Draw(playButton, playButtonRect, Color.White);

            if (quitButtonRect.Contains(mousePoint))
                spriteBatch.Draw(quitButtonClicked, quitButtonRect, Color.White);
            else
                spriteBatch.Draw(quitButton, quitButtonRect, Color.White);
        }
        void UpdateMainGame()
        {
            if (loadingDone == false)
            {
                switch (difficulty)
                {
                    case 1:
                        xBoard = 200;
                        yBoard = 100;
                        health = 3;
                        for (int i = 0; i < 30; i++)
                        {
                            if (xBoard > 450)
                            {
                                yBoard += 50;
                                xBoard = 200;
                            }

                            gridRect.Add(new Rectangle(xBoard += 50, yBoard, 50, 50));
                            gridClickable.Add(true);
                            gridTypeAt.Add(rnd.Next(0, 3));
                            
                            if (gridTypeAt[i] == 0)
                            {
                                //Safe Spot
                                safeAmount++;
                            }
                            if (gridTypeAt[i] == 1)
                            {
                                //Bomb Spot
                                bombAmount++;
                            }
                            if (gridTypeAt[i] == 2)
                            {
                                //Heal Spot
                                healthAmount++;
                            }

                            if (healthAmount > 3 && gridTypeAt[i] == 2)
                            {
                                gridTypeAt[i] = 0;
                                
                            }
                            if (bombAmount > 4 && gridTypeAt[i] == 1)
                            {
                                gridTypeAt[i] = 0;
                                
                            }
                            if (safeAmount > 23 && gridTypeAt[i] == 0)
                            {
                                gridTypeAt[i] = rnd.Next(0, 3);
                                
                            }
                            if (i == 29)
                                loadingDone = true;
                        }
                        healthAmount = 0;
                        bombAmount = 0;
                        safeAmount = 0;
                        for(int i = 0; i < gridRect.Count(); i++)
                        {
                            if (gridTypeAt[i] == 0)
                                safeAmount++;
                            if (gridTypeAt[i] == 1)
                                bombAmount++;
                            if (gridTypeAt[i] == 2)
                                healthAmount++;
                        }
                        break;

                    case 2:
                        xBoard = 100;
                        yBoard = 100;
                        health = 2;
                        for (int i = 0; i < 50; i++)
                        {
                            if (xBoard > 550)
                            {
                                yBoard += 50;
                                xBoard = 100;
                            }

                            gridRect.Add(new Rectangle(xBoard += 50, yBoard, 50, 50));
                            gridClickable.Add(true);
                            gridTypeAt.Add(rnd.Next(0, 3));
                            
                            if (gridTypeAt[i] == 0)
                            {
                                //Safe Spot
                                safeAmount++;
                            }
                            if (gridTypeAt[i] == 1)
                            {
                                //Bomb Spot
                                bombAmount++;
                            }
                            if (gridTypeAt[i] == 2)
                            {
                                //Heal Spot
                                healthAmount++;
                            }

                            if (healthAmount > 4 && gridTypeAt[i] == 2)
                            {
                                gridTypeAt[i] = 0;

                            }
                            if (bombAmount > 8 && gridTypeAt[i] == 1)
                            {
                                gridTypeAt[i] = 0;

                            }
                            if (safeAmount > 38 && gridTypeAt[i] == 0)
                            {
                                gridTypeAt[i] = rnd.Next(0, 3);

                            }
                            if (i == 49)
                                loadingDone = true;
                        }
                        healthAmount = 0;
                        bombAmount = 0;
                        safeAmount = 0;
                        for(int i = 0; i < gridRect.Count(); i++)
                        {
                            if (gridTypeAt[i] == 0)
                                safeAmount++;
                            if (gridTypeAt[i] == 1)
                                bombAmount++;
                            if (gridTypeAt[i] == 2)
                                healthAmount++;
                        }
                        break;

                    case 3:
                        xBoard = 100;
                        yBoard = 100;
                        health = 1;
                        for (int i = 0; i < 70; i++)
                        {
                            if (xBoard > 550)
                            {
                                yBoard += 50;
                                xBoard = 100;
                            }

                            gridRect.Add(new Rectangle(xBoard += 50, yBoard, 50, 50));
                            gridClickable.Add(true);
                            gridTypeAt.Add(rnd.Next(0, 3));

                            

                            if (gridTypeAt[i] == 0)
                            {
                                //Safe Spot
                                safeAmount++;
                            }
                            if (gridTypeAt[i] == 1)
                            {
                                //Bomb Spot
                                bombAmount++;
                            }
                            if (gridTypeAt[i] == 2)
                            {
                                //Heal Spot
                                healthAmount++;
                            }

                            if (healthAmount > 7 && gridTypeAt[i] == 2)
                            {
                                gridTypeAt[i] = 0;

                            }
                            if (bombAmount > 11 && gridTypeAt[i] == 1)
                            {
                                gridTypeAt[i] = 0;

                            }
                            if (safeAmount > 52 && gridTypeAt[i] == 0)
                            {
                                gridTypeAt[i] = rnd.Next(0, 3);

                            }
                            if (i == 69)
                                loadingDone = true;
                        }
                        break;
                }
                gridLeft = gridRect.Count();
            }
            if(loadingDone == true)
            {
                timer++;
            }
            if (mouse.LeftButton == ButtonState.Pressed && mouseOld.LeftButton == ButtonState.Released)
            {
                for(int i = 0; i < gridTypeAt.Count(); i++)
                {
                    if(gridRect[i].Contains(mousePoint) && gridClickable[i]==true)
                    {
                        switch (gridTypeAt[i])
                        {
                            case 0:
                                score += 100;
                                gridClickable[i] = false;
                                gridLeft--;
                                safeAmount--;
                                break;
                            case 1:
                                health--;
                                score -= 200;
                                gridClickable[i] = false;
                                gridLeft--;
                                bombAmount--;
                                break;
                            case 2:
                                health++;
                                score += 200;
                                gridClickable[i] = false;
                                gridLeft--;
                                healthAmount--;
                                break;

                        }
                        
                    }
                }
                
            }

            if (bombAmount == 0)
            {
                endScreenSenario = false;
                state = GameState.endScreen;
            }
            if(safeAmount==0)
            {
                endScreenSenario = true;
                state = GameState.endScreen;
            }

        }
        void DrawMainGame()
        {
            if (loadingDone == true)
            {
                for (int i = 0; i < gridRect.Count(); i++)
                {
                    spriteBatch.Draw(gridType[3], gridRect[i], Color.White);
                }
            }//End of initial rectangle
            
            for (int i = 0; i < gridRect.Count(); i++)
            {
                if(gridClickable[i] == false)
                {
                    switch (gridTypeAt[i])
                    {
                        case 0:
                            spriteBatch.Draw(gridType[0], gridRect[i], Color.White);
                            break;
                        case 1:
                            spriteBatch.Draw(gridType[1], gridRect[i], Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(gridType[2], gridRect[i], Color.White);
                            break;
                    }
                }

                
            }


            String information = "Score: " + score.ToString() + "\nHealth: " + health + "\nGrid left: " + gridLeft
                + "\nSafe Amount: " + safeAmount.ToString() + "\nBomb Amount: " + bombAmount.ToString() + "\nHealth Amount: " + healthAmount.ToString() ;

            spriteBatch.DrawString(font, information, new Vector2(0, 0), Color.Black);
            
            



        }

        void UpdateEndScreen()
        {
            //Add play again button function
            if (mouse.LeftButton == ButtonState.Pressed && mouseOld.LeftButton == ButtonState.Released)
            {
                if (quitButtonEndScreenRect.Contains(mousePoint))
                    this.Exit();
            }
        }
        void DrawEndScreen()
        {
            if(endScreenSenario)
            {
                //Add You won title
                //spriteBatch.DrawString(font, "You Won", new Vector2(200, 200), Color.White);
                spriteBatch.Draw(youWon, endScreenTitleRect, Color.White);
            }
            if(!endScreenSenario)
            {
                //spriteBatch.DrawString(font, "You Lost", new Vector2(200, 200), Color.White);
                //Add You lost title
                spriteBatch.Draw(youLost, endScreenTitleRect, Color.White);
            }

            spriteBatch.Draw(quitButton, quitButtonEndScreenRect, Color.White);
            spriteBatch.Draw(playAgainButton, playAgainButtonRect, Color.White);
            spriteBatch.DrawString(font, "You Score was: " + score+"\nIt took you: "+ (timer/60).ToString()+ " Seconds", new Vector2(graphics.GraphicsDevice.Viewport.Width / 3, graphics.GraphicsDevice.Viewport.Height / 2), Color.Black);
            if (playAgainButtonRect.Contains(mousePoint))
                spriteBatch.Draw(mouseOverButton, playAgainButtonRect, Color.White);
            
            if (quitButtonRect.Contains(mousePoint))
                spriteBatch.Draw(mouseOverButton, quitButtonEndScreenRect, Color.White);
            
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
            mousePoint = new Point(mouse.X, mouse.Y);

            switch(state)
            {
                case GameState.titleScreen:
                    UpdateTitleScreen();
                    break;
                case GameState.mainGame:
                    UpdateMainGame();
                    break;
                case GameState.endScreen:
                    UpdateEndScreen();
                    break;
            }

            keyboardOld = keyboard;
            mouseOld = mouse;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            switch (state)
            {
                case GameState.titleScreen:
                    DrawTitleScreen();
                    break;
                case GameState.mainGame:
                    DrawMainGame();
                    break;
                case GameState.endScreen:
                    DrawEndScreen();
                    break;
            }

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
