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

namespace moodLight
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class moodLight : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //text
        SpriteFont Title;
        Vector2 TitleFontPos;
        string titleText;
       

        
        

        #region Color Variables
        byte redIntensity = 0;
        byte greenIntensity = 0;
        byte blueIntensity = 0;
        #endregion

        bool gameActive;
        bool gameOver;
        

        #region Future input control variables
       
        GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
        GamePadState pad2 = GamePad.GetState(PlayerIndex.Two);
        KeyboardState keys = Keyboard.GetState();
        #endregion

        public moodLight()
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
            Title = Content.Load<SpriteFont>("Title");

            // TODO: use this.Content to load your game content here
            TitleFontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2);
            titleText = "Color Nerve\nPress 'A' or 'Enter' to begin playing...";
            gameActive = false;
            
            gameOver = false;

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            
            // Allows the game to exit
            

            // TODO: Add your update logic here
            keys = Keyboard.GetState();
            pad1 = GamePad.GetState(PlayerIndex.One);
            
            

            #region multiplayer
            #region Amount of players
            if (gameActive==false)
            {
                titleText = "Color Nerve\nPress 'A' or 'Enter' to begin playing...";
                GamePad.SetVibration(PlayerIndex.One, 0, 0);

                if ((pad1.Buttons.A == ButtonState.Pressed)||keys.IsKeyDown(Keys.Enter))
                {
                    
                    gameActive = true;
                    titleText = "";
                    
                }

            }
            #endregion
            
            
            #region Manual Changes
            
            if (gameActive==true)
            {
                  
                    #region Player 1 Controls

                    if (pad1.IsConnected)
                    {
                        if (keys.IsKeyDown(Keys.R) && keys.IsKeyDown(Keys.Up)|| (pad1.Buttons.B == ButtonState.Pressed && pad1.Triggers.Right > 0))
                        {
                            redIntensity++;
                        }
                        if (keys.IsKeyDown(Keys.G) && keys.IsKeyDown(Keys.Up) || (pad1.Buttons.A == ButtonState.Pressed && pad1.Triggers.Right > 0))
                        {
                            greenIntensity++;
                        }
                        if (keys.IsKeyDown(Keys.B) && keys.IsKeyDown(Keys.Up) || (pad1.Buttons.X == ButtonState.Pressed && pad1.Triggers.Right > 0))
                        {
                            blueIntensity++;
                        }
                        if (keys.IsKeyDown(Keys.Y) && keys.IsKeyDown(Keys.Up) || (pad1.Buttons.Y == ButtonState.Pressed && pad1.Triggers.Right > 0))
                        {
                            greenIntensity++;
                            redIntensity++;
                        }
                        if (keys.IsKeyDown(Keys.R) && keys.IsKeyDown(Keys.Down) || (pad1.Buttons.B == ButtonState.Pressed && pad1.Triggers.Left > 0))
                        {
                            redIntensity--;
                        }
                        if (keys.IsKeyDown(Keys.G) && keys.IsKeyDown(Keys.Down) || (pad1.Buttons.A == ButtonState.Pressed && pad1.Triggers.Left > 0))
                        {
                            greenIntensity--;
                        }
                        if (keys.IsKeyDown(Keys.B) && keys.IsKeyDown(Keys.Down) || (pad1.Buttons.X == ButtonState.Pressed && pad1.Triggers.Left > 0))
                        {
                            blueIntensity--;
                        }
                        if (keys.IsKeyDown(Keys.Y) && keys.IsKeyDown(Keys.Down) || (pad1.Buttons.Y == ButtonState.Pressed && pad1.Triggers.Left > 0))
                        {
                            greenIntensity--;
                            redIntensity--;
                        }
                    
                    #endregion
                    
                    
                }
                
                
                if (redIntensity == 255 || greenIntensity == 255 || blueIntensity == 255)
                {
                    gameOver = true;
                }
                if (gameOver == true)
                {
                    redIntensity = 0;
                    greenIntensity = 0;
                    blueIntensity = 0;
                    GamePad.SetVibration(PlayerIndex.One, 1, 1);
                    titleText = "Game Over!\nPress 'Start' or 'Space' to restart game...\nPress 'Back' or 'Escape' to exit game...";
                    if ((pad1.Buttons.Start == ButtonState.Pressed)||keys.IsKeyDown(Keys.Space))
                    {
                        gameActive = false;
                        gameOver = false;
                        redIntensity = 0; greenIntensity = 0;  blueIntensity = 0;
                    }
                    if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)||keys.IsKeyDown(Keys.Escape))
                        this.Exit();

                }
            }
            
            
            
            #endregion 
            #endregion
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            #region Change color to one based on intensity variables
            Color backgroundColor = new Color(redIntensity, greenIntensity, blueIntensity);
            GraphicsDevice.Clear(backgroundColor);
            #endregion 
            //GraphicsDevice.Clear(Color.Wheat);
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            string output = titleText;
            Vector2 FontOrigin = Title.MeasureString(output) / 2;
            spriteBatch.DrawString(Title, output, TitleFontPos, Color.Tomato, 0.0f,FontOrigin,1.0f,SpriteEffects.None,0.5f);
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
