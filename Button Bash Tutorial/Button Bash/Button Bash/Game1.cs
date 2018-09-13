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

namespace Button_Bash
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // Game World

        // game timer
        int timer = 600;
        Vector2 timerPos = new Vector2(280, 15);

        //Random Function
        Random rnd = new Random();

        // Display font
        SpriteFont font;
        //Array List
        int[] buttonCount= new int[16];
        int[] totalScores = new int[4];

        
        // Gamepad 1
        GamePadState pad1;
        GamePadState oldpad1;
        /*int acount1;
        int bcount1;
        int xcount1;
        int ycount1;
        int totalScore1;*/

        Vector2 apos1 = new Vector2(150, 150);
        Vector2 bpos1 = new Vector2(200, 100);
        Vector2 xpos1 = new Vector2(100, 100);
        Vector2 ypos1 = new Vector2(150, 50);
        Vector2 tSpos1 = new Vector2(140, 15);

        // Gamepad 2
        GamePadState pad2;
        GamePadState oldpad2;
        /*int acount2;
        int bcount2;
        int xcount2;
        int ycount2;
        int totalScore2;*/

        Vector2 apos2 = new Vector2(650, 150);
        Vector2 bpos2 = new Vector2(700, 100);
        Vector2 xpos2 = new Vector2(600, 100);
        Vector2 ypos2 = new Vector2(650, 50);
        Vector2 tSpos2 = new Vector2(640, 15);

        // Gamepad 3
        GamePadState pad3;
        GamePadState oldpad3;
        /*int acount3;
        int bcount3;
        int xcount3;
        int ycount3;
        int totalScore3;*/

        Vector2 apos3 = new Vector2(150, 350);
        Vector2 bpos3 = new Vector2(200, 300);
        Vector2 xpos3 = new Vector2(100, 300);
        Vector2 ypos3 = new Vector2(150, 250);
        Vector2 tSpos3 = new Vector2(140, 215);

        // Gamepad 4
        GamePadState pad4;
        GamePadState oldpad4;
        /*int acount4;
        int bcount4;
        int xcount4;
        int ycount4;
        int totalScore4;*/

        
        Vector2 apos4 = new Vector2(650, 350);
        Vector2 bpos4 = new Vector2(700, 300);
        Vector2 xpos4 = new Vector2(600, 300);
        Vector2 ypos4 = new Vector2(650, 250);
        Vector2 tSpos4 = new Vector2(640, 215);

       //Song code
        Song[] startSong = new Song[5];
        
        Song runningInThe90s;
        Song spiderMan2PizzaDelivery;
        Song miiMusic;
        Song nyanCat;
        Song macintoshPlus;

        bool songPlaying;
        int obj;
        bool gameActive;

        //Color Changer
        
        
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

            //Grabs the song from content
            runningInThe90s = Content.Load<Song>("Running in the 90s");
            spiderMan2PizzaDelivery = Content.Load<Song>("Spider Man 2 Pizza Del");
            miiMusic = Content.Load<Song>("Mii Theme Song");
            nyanCat = Content.Load<Song>("Nyan Cat");
            macintoshPlus = Content.Load<Song>("Macintosh Plus");

            //Assigns song to array
            startSong[0] = runningInThe90s;
            startSong[1] = spiderMan2PizzaDelivery;
            startSong[2] = miiMusic;
            startSong[3] = nyanCat;
            startSong[4] = macintoshPlus;

            gameActive = true;
            
            font = Content.Load<SpriteFont>("SpriteFont1");
            
            
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //Gets state of controllers
            pad1 = GamePad.GetState(PlayerIndex.One);
            pad2 = GamePad.GetState(PlayerIndex.Two);
            pad3 = GamePad.GetState(PlayerIndex.Three);
            pad4 = GamePad.GetState(PlayerIndex.Four);

            if (!songPlaying)
            {
                obj = rnd.Next(startSong.Length);
                MediaPlayer.Play(startSong[obj]);
                songPlaying = true;
            }

            if (timer > 0) // 10 second game
            {
                
                timer--;
            }
            if (!gameActive)
            {
                if (oldpad1.Buttons.Start == ButtonState.Released &&
                    pad1.Buttons.Start == ButtonState.Pressed)
                {
                    #region Old Code
                    /*
                    acount1 = 0;
                    bcount1 = 0;
                    xcount1 = 0;
                    ycount1 = 0;

                    acount2 = 0;
                    bcount2 = 0;
                    xcount2 = 0;
                    ycount2 = 0;

                    acount3 = 0;
                    bcount3 = 0;
                    xcount3 = 0;
                    ycount3 = 0;

                    acount4 = 0;
                    bcount4 = 0;
                    xcount4 = 0;
                    ycount4 = 0;
                    */
                    #endregion

                    buttonCount = Array.ConvertAll(buttonCount, x => x * 0);
                    timer = 600;
                    songPlaying = false;
                    gameActive = true;

                }
            }
            if (gameActive == true)
            {
                if (pad1.IsConnected)
                {



                    if (oldpad1.Buttons.A == ButtonState.Released &&
                         pad1.Buttons.A == ButtonState.Pressed)
                    {
                        //acount1++;
                        buttonCount[0]++;
                    }

                    if (oldpad1.Buttons.B == ButtonState.Released &&
                         pad1.Buttons.B == ButtonState.Pressed)
                    {
                        //bcount1++;
                        buttonCount[1]++;
                    }

                    if (oldpad1.Buttons.X == ButtonState.Released &&
                         pad1.Buttons.X == ButtonState.Pressed)
                    {
                        //xcount1++;
                        buttonCount[2]++;
                    }

                    if (oldpad1.Buttons.Y == ButtonState.Released &&
                         pad1.Buttons.Y == ButtonState.Pressed)
                    {
                        //ycount1++;
                        buttonCount[3]++;
                    }




                    oldpad1 = pad1;

                    totalScores[0] = buttonCount[0] + buttonCount[1] + buttonCount[2] + buttonCount[3];
                }


                if (pad2.IsConnected)
                {

                    if (oldpad2.Buttons.A == ButtonState.Released &&
                         pad2.Buttons.A == ButtonState.Pressed)
                    {
                        //acount2++;
                        buttonCount[4]++;
                    }

                    if (oldpad2.Buttons.B == ButtonState.Released &&
                         pad2.Buttons.B == ButtonState.Pressed)
                    {
                        //bcount2++;
                        buttonCount[5]++;
                    }

                    if (oldpad2.Buttons.X == ButtonState.Released &&
                         pad2.Buttons.X == ButtonState.Pressed)
                    {
                        //xcount2++;
                        buttonCount[6]++;
                    }

                    if (oldpad2.Buttons.Y == ButtonState.Released &&
                         pad2.Buttons.Y == ButtonState.Pressed)
                    {
                        //ycount2++;
                        buttonCount[7]++;
                    }

                    oldpad2 = pad2;
                    totalScores[1] = buttonCount[4] + buttonCount[5] + buttonCount[6] + buttonCount[7];
                }


                if (pad3.IsConnected)
                {

                    if (oldpad3.Buttons.A == ButtonState.Released &&
                         pad3.Buttons.A == ButtonState.Pressed)
                    {
                        //acount3++;
                        buttonCount[8]++;
                    }

                    if (oldpad3.Buttons.B == ButtonState.Released &&
                         pad3.Buttons.B == ButtonState.Pressed)
                    {
                        //bcount3++;
                        buttonCount[9]++;
                    }

                    if (oldpad3.Buttons.X == ButtonState.Released &&
                         pad3.Buttons.X == ButtonState.Pressed)
                    {
                        //xcount3++;
                        buttonCount[10]++;
                    }

                    if (oldpad3.Buttons.Y == ButtonState.Released &&
                         pad3.Buttons.Y == ButtonState.Pressed)
                    {
                        //ycount3++;
                        buttonCount[11]++;
                    }

                    oldpad3 = pad3;

                    totalScores[2] = buttonCount[8] + buttonCount[9] + buttonCount[10] + buttonCount[11];
                }


                if (pad4.IsConnected)
                {

                    if (oldpad4.Buttons.A == ButtonState.Released &&
                         pad4.Buttons.A == ButtonState.Pressed)
                    {
                        //acount4++;
                        buttonCount[12]++;
                    }

                    if (oldpad4.Buttons.B == ButtonState.Released &&
                         pad4.Buttons.B == ButtonState.Pressed)
                    {
                        //bcount4++;
                        buttonCount[13]++;
                    }

                    if (oldpad4.Buttons.X == ButtonState.Released &&
                         pad4.Buttons.X == ButtonState.Pressed)
                    {
                        //xcount4++;
                        buttonCount[14]++;
                    }

                    if (oldpad4.Buttons.Y == ButtonState.Released &&
                         pad4.Buttons.Y == ButtonState.Pressed)
                    {
                        //ycount4++;
                        buttonCount[15]++;
                    }

                    oldpad4 = pad4;
                    totalScores[3] = buttonCount[12] + buttonCount[13] + buttonCount[14] + buttonCount[15];
                }
            }

            
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
            if(gameActive)
                spriteBatch.DrawString(font, "Time Left: " +(timer / 60).ToString("0"), timerPos, Color.White);
            if(!gameActive)
                spriteBatch.DrawString(font, "Times up!", timerPos, Color.White);
            if (pad1.IsConnected)
            {
                spriteBatch.DrawString(font, buttonCount[0].ToString(), apos1, Color.Green);
                spriteBatch.DrawString(font, buttonCount[1].ToString(), bpos1, Color.Red);
                spriteBatch.DrawString(font, buttonCount[2].ToString(), xpos1, Color.Blue);
                spriteBatch.DrawString(font, buttonCount[3].ToString(), ypos1, Color.Yellow);
                if (timer == 0)
                {
                    spriteBatch.DrawString(font, totalScores[0].ToString(), tSpos1, Color.LightGray);
                    MediaPlayer.Pause();
                    songPlaying = false;
                    gameActive = false;
                }
            }

            if (pad2.IsConnected)
            {
                spriteBatch.DrawString(font, buttonCount[4].ToString(), apos2, Color.Green);
                spriteBatch.DrawString(font, buttonCount[5].ToString(), bpos2, Color.Red);
                spriteBatch.DrawString(font, buttonCount[6].ToString(), xpos2, Color.Blue);
                spriteBatch.DrawString(font, buttonCount[7].ToString(), ypos2, Color.Yellow);
                if (timer == 600)
                    spriteBatch.DrawString(font, totalScores[1].ToString(), tSpos2, Color.LightGray);
            }

            if (pad3.IsConnected)
            {
                spriteBatch.DrawString(font, buttonCount[8].ToString(), apos3, Color.Green);
                spriteBatch.DrawString(font, buttonCount[9].ToString(), bpos3, Color.Red);
                spriteBatch.DrawString(font, buttonCount[10].ToString(), xpos3, Color.Blue);
                spriteBatch.DrawString(font, buttonCount[11].ToString(), ypos3, Color.Yellow);
                if (timer == 600)
                    spriteBatch.DrawString(font, totalScores[2].ToString(), tSpos3, Color.LightGray);
            }

            if (pad4.IsConnected)
            {
                spriteBatch.DrawString(font, buttonCount[12].ToString(), apos4, Color.Green);
                spriteBatch.DrawString(font, buttonCount[13].ToString(), bpos4, Color.Red);
                spriteBatch.DrawString(font, buttonCount[14].ToString(), xpos4, Color.Blue);
                spriteBatch.DrawString(font, buttonCount[15].ToString(), ypos4, Color.Yellow);
                if (timer == 600)
                    spriteBatch.DrawString(font, totalScores[3].ToString(), tSpos4, Color.LightGray);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
