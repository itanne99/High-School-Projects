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

namespace DinoRun
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //PlayerControl
        KeyboardState keyboard, keyboardOld;
        //Gamestates
        enum GameState
        {
            titleScreen, mainGame, endScreen
        }
        GameState state = GameState.titleScreen;
        //Dino
        Texture2D dinoTexture;
        Rectangle dinoRect;
        Vector2 dinoPos;
        double jumpHeight = .15, timeInAir, maxAirTime = 3;
        int speed, score;
        Vector2 positon, velocity;
        bool dinoJump;
        //Obsticals
        Texture2D cactus, cactusLong, cactusTall, birdGround, birdMiddle, birdHigh;
        Rectangle cactusRect, cactusLongRect, cactusTallRect, birdGroundRect, birdMiddleRect, birdHighRect;
        Texture2D[] listObsticals = new Texture2D[6];
        List<Rectangle> currentObsticals = new List<Rectangle>();
        List<Vector2> currentObsticalsVector = new List<Vector2>();
        Random rnd = new Random();
        //Background
        Texture2D ground, clouds;
        Rectangle groundRect, cloudsRect;
        double cloudSpeed = .25;
        //Font
        SpriteFont mainFont, debugFont;
        //Title
        Texture2D title;
        Rectangle titleRect;
        
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
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
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

            //Dino
            dinoTexture = Content.Load<Texture2D>("Dino");
            dinoRect = new Rectangle(50, 300, 50, 100);
            dinoPos.Y = dinoRect.Y;
            //Font
            mainFont = Content.Load<SpriteFont>("Font1");
            debugFont = Content.Load<SpriteFont>("DebugFont");
            //Title
            title = Content.Load<Texture2D>("Dino Run Title");
            titleRect = new Rectangle(150, 25, 500, 200);

            //List Of Obsticals
            #region List Of Obsticals
            listObsticals[0] = cactus;
            cactusRect = new Rectangle(0, 0, 35, 40);
            listObsticals[1] = cactusLong;
            cactusLongRect = new Rectangle(0, 0, 60, 40);
            listObsticals[2] = cactusTall;
            cactusTallRect = new Rectangle(0, 0, 35, 50);
            listObsticals[3] = birdGround;
            cactusTallRect = new Rectangle(0, 0, 40, 35);
            listObsticals[4] = birdMiddle;
            birdMiddleRect = new Rectangle(0, 0, 40, 35);
            listObsticals[5] = birdHigh;
            birdHighRect = new Rectangle(0, 0, 40, 35);
            #endregion

        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        void UpdateTitleScreen()
        {
            if(keyboard.IsKeyDown(Keys.Enter) && keyboardOld.IsKeyDown(Keys.Enter))
            {
                state = GameState.mainGame;
            }
        }
        
        void DrawTitleScreen()
        {
            spriteBatch.Draw(title, titleRect, Color.White);
            spriteBatch.DrawString(mainFont, "Press 'Enter' to start playing!", new Vector2(150, (graphics.GraphicsDevice.Viewport.Height / 2)), Color.Black);
            spriteBatch.DrawString(mainFont, "Made by Ido Tanne", new Vector2((graphics.GraphicsDevice.Viewport.Width - mainFont.MeasureString("Made by Ido Tanne").X), (graphics.GraphicsDevice.Viewport.Height - mainFont.MeasureString("Made by Ido Tanne").Y)), Color.Black);
        }

        void UpdateMainGame()
        {
            score++;

            

            if(keyboard.IsKeyDown(Keys.Space) && keyboardOld.IsKeyUp(Keys.Space) && !dinoJump)
            {
                    dinoPos.Y -= 10f;
                    velocity.Y = -5f;
                    dinoJump = true;
                
            }
            if(dinoJump)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }

            if(positon.X >= 300)
            {
                dinoJump = false;
            }

            if(!dinoJump)
            {
                velocity.Y = 0f;
            }
        }

        

        
        void DrawMainGame()
        {
            //Score
            spriteBatch.DrawString(mainFont, "Score:\n" + score.ToString("00000000"), new Vector2((graphics.GraphicsDevice.Viewport.Width - mainFont.MeasureString("00000000").X), 10), Color.Black);
            //Debug Text
            spriteBatch.DrawString(debugFont, "Dino Y: " + dinoPos.Y, Vector2.Zero, Color.Black);
            //Cloud 1
            //spriteBatch.Draw(clouds, cloudsRect, Color.White);
            //Cloud 2

            //Cloud 3

            //Cloud 4

            //Player
            spriteBatch.Draw(dinoTexture, dinoPos, Color.Black);
        }

        void UpdateEndScreen()
        {
            
        }

        void DrawEndScreen()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            keyboard = Keyboard.GetState();

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
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);
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
