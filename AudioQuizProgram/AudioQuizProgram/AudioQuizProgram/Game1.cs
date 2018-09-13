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

namespace AudioQuizProgram
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background;
        Rectangle backgroundRect;

        Texture2D youWon;
        Rectangle youWonRect;

        Texture2D youLost;
        Rectangle youLostRect;

        int catagory;

        Texture2D tileMemeCentral;
        Rectangle tileMemeCentralRect;
        
        bool tileMemeCentralVisible = true;

        Texture2D tileTodaysPop;
        Rectangle tileTodaysPopRect;
        
        bool tileTodaysPopVisible = true;

        Texture2D tile2000sPop;
        Rectangle tile2000sPopRect;
        
        bool tile2000sPopVisible = true;

        Texture2D googlyEyesChr;
        Rectangle googlyEyesChrRect;
        Vector2 characterPos;

        Song mainMenu;

        Song correctSound;
        Song incorrectSound;
        
        Song dejaVu;
        Song epicSaxGdalf;
        Song jurrasicParkHarmon;
        Song ussrAnthem;

        Song hereWithOutYou;
        Texture2D hereWithOutYouTile;
        Rectangle hereWithOutYouTileRect;
        bool hereWithOutYouTileVisible = false;
        Texture2D lookAfterYouTile;
        Rectangle lookAfterYouTileRect;
        bool lookAfterYouTileVisible = false;
        Texture2D lonliestTile;
        Rectangle lonliestTileRect;
        bool lonliestTileVisible = false;
        Song overMyHead;
        Song storyOfAGirl;

        Song weDontTalkAnymore;

        Vector2 left;
        Vector2 right;
        Vector2 middle;
        int totalScore;
        int currentScore;

        int stage;
        
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Window.Title = "Sound Of Wonder By: Ido T.";
            graphics.ApplyChanges();
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

            left = new Vector2(50, 400);
            middle = new Vector2(300, 400);
            right = new Vector2(550, 400);
            
            background = Content.Load<Texture2D>("Music Backround");
            backgroundRect = new Rectangle(0, 0, 800, 600);

            googlyEyesChr = Content.Load<Texture2D>("Googly Eyes");
            characterPos = new Vector2(350, 200);
            googlyEyesChrRect = new Rectangle(((int)characterPos.X), ((int)characterPos.Y), 100, 100);
            
            
            #region Tiles
            tile2000sPop = Content.Load<Texture2D>("2000's Pop");
            
            tile2000sPopRect = new Rectangle(((int)left.X), ((int)left.Y), 180, 180);


            tileMemeCentral = Content.Load<Texture2D>("Meme central");
            tileMemeCentralRect = new Rectangle(((int)middle.X),((int)middle.Y), 180, 180);

            tileTodaysPop = Content.Load<Texture2D>("Today's Pop");
            tileTodaysPopRect = new Rectangle(((int)right.X), ((int)right.Y), 180, 180);

            hereWithOutYouTile = Content.Load<Texture2D>("Here without you pic");
            hereWithOutYouTileRect = new Rectangle(((int)middle.X), ((int)middle.Y), 180, 180);

            lonliestTile = Content.Load<Texture2D>("Lonliest");
            lonliestTileRect = new Rectangle(((int)right.X), ((int)right.Y), 180, 180);

            lookAfterYouTile = Content.Load<Texture2D>("Look After you");
            lookAfterYouTileRect = new Rectangle(((int)left.X), ((int)left.Y), 180, 180);

            #endregion
            #region Songs
            //Main Menu Song
            mainMenu = Content.Load<Song>("Main Music");
            MediaPlayer.Play(mainMenu);
            //Meme Central
            dejaVu = Content.Load<Song>("Deja Vu");
            epicSaxGdalf = Content.Load<Song>("Epic Sax Gdalf");
            jurrasicParkHarmon = Content.Load<Song>("Jarrasic Park Harmonica");
            ussrAnthem = Content.Load<Song>("USSR Anthem");
            //2000's Pop
            hereWithOutYou = Content.Load<Song>("Here without you");
            overMyHead = Content.Load<Song>("Over My Head");
            storyOfAGirl = Content.Load<Song>("Story of a Girl");
            //Today's Pop
            weDontTalkAnymore = Content.Load<Song>("We Don't Talk anymore");
            #endregion
            #region Sound Effects
            correctSound = Content.Load<Song>("Correct Sound");
            incorrectSound = Content.Load<Song>("Incorrect Sound");
            #endregion
            catagory = 0;
            stage = 0;
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed||Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift)&& Keyboard.GetState().IsKeyDown(Keys.M))
                MediaPlayer.Stop();
            // TODO: Add your update logic here

            //keyboard.IsKeyDown();
            
                #region Character Movement
                if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)))
                    characterPos.Y -= 3;

                if ((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)) && characterPos.Y < 300)
                    characterPos.Y += 3;

                if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                    characterPos.X += 3;

                if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                    characterPos.X -= 3;
                googlyEyesChrRect = new Rectangle(((int)characterPos.X), ((int)characterPos.Y), 100, 100);
                #endregion

                #region Catagory selection
                if (catagory == 0)
                {
                    if (googlyEyesChrRect.Intersects(tile2000sPopRect))
                    {
                        MediaPlayer.Stop();
                        //MediaPlayer.Play(dejaVu);
                        catagory = 1;
                        
                        tile2000sPopVisible = false;
                        tileMemeCentralVisible = false;
                        tileTodaysPopVisible = false;
                        characterPos = new Vector2(350, 200);
                    }

                    if (googlyEyesChrRect.Intersects(tileMemeCentralRect))
                    {
                        MediaPlayer.Stop();
                        
                        catagory = 2;
                        tile2000sPopVisible = false;
                        tileMemeCentralVisible = false;
                        tileTodaysPopVisible = false;
                        characterPos = new Vector2(350, 200);
                    }

                    if (googlyEyesChrRect.Intersects(tileTodaysPopRect))
                    {
                        MediaPlayer.Stop();
                        
                        catagory = 3;
                        tile2000sPopVisible = false;
                        tileMemeCentralVisible = false;
                        tileTodaysPopVisible = false;
                        characterPos = new Vector2(350, 200);
                    }
                }
                #endregion

                #region 2000's Pop
                if (catagory == 1)
                {
                    //input picture with stage1. Gray backround

                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        stage = 1;
                    
                    if (stage == 1)
                    {
                        
                        MediaPlayer.Play(hereWithOutYou);
                        hereWithOutYouTileVisible = true;
                        lonliestTileVisible = true;
                        lookAfterYouTileVisible = true;
                        

                    }
                }
                #endregion
            



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundRect, Color.White);
            spriteBatch.Draw(googlyEyesChr, googlyEyesChrRect, Color.White);
            if(tileMemeCentralVisible==true)
                spriteBatch.Draw(tileMemeCentral, tileMemeCentralRect, Color.White);
            
            if (tileTodaysPopVisible == true) 
                spriteBatch.Draw(tileTodaysPop, tileTodaysPopRect, Color.White);
            
            if(tile2000sPopVisible == true)
                spriteBatch.Draw(tile2000sPop, tile2000sPopRect, Color.White);

            if (lookAfterYouTileVisible == true)
                spriteBatch.Draw(lookAfterYouTile, lookAfterYouTileRect, Color.White);

            if (lonliestTileVisible == true)
                spriteBatch.Draw(lonliestTile, lonliestTileRect, Color.White);

            if (hereWithOutYouTileVisible == true)
                spriteBatch.Draw(hereWithOutYouTile, hereWithOutYouTileRect, Color.White);



            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
