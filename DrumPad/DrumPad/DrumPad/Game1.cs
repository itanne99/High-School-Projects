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

namespace DrumPad
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SoundEffect cymbolTing;
        SoundEffect kick;
        SoundEffect snare;
        SoundEffect top;
        SoundEffect music;
        SoundEffectInstance musicInstance;
        float rythm;
        bool metronome = false;

        Song tune;

        GamePadState pad1, oldpad1;
        KeyboardState keyboard, oldkeyboard;
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

            cymbolTing = Content.Load<SoundEffect>("cymbolTing");
            kick = Content.Load<SoundEffect>("kick");
            snare = Content.Load<SoundEffect>("snare");
            top = Content.Load<SoundEffect>("top");
            tune = Content.Load<Song>("song");
            metronome = false;
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
            keyboard = Keyboard.GetState();
            pad1 = GamePad.GetState(PlayerIndex.One);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed||keyboard.IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            #region Controller
            float volume1 = pad1.Triggers.Right;
            float pitch1 = pad1.ThumbSticks.Left.Y;
            float pan1 = pad1.ThumbSticks.Right.X;

            if (oldpad1.Buttons.A == ButtonState.Released &&
                pad1.Buttons.A == ButtonState.Pressed)
            {
                snare.Play();
            }
            if (oldpad1.Buttons.B == ButtonState.Released &&
                pad1.Buttons.B == ButtonState.Pressed)
            {
                kick.Play();
            }
            if (oldpad1.Buttons.X == ButtonState.Released &&
                pad1.Buttons.X == ButtonState.Pressed)
            {
                cymbolTing.Play();
            }
            if (oldpad1.Buttons.Y == ButtonState.Released &&
                pad1.Buttons.Y == ButtonState.Pressed)
            {
                top.Play();
            }

            if (oldpad1.Buttons.LeftShoulder == ButtonState.Released &&
                pad1.Buttons.LeftShoulder == ButtonState.Pressed)
            {
                if (MediaPlayer.State == MediaState.Paused)
                {
                    MediaPlayer.Resume();
                }
                else
                {
                    MediaPlayer.Play(tune);
                }

            }

            if (oldpad1.Buttons.RightShoulder == ButtonState.Released &&
                pad1.Buttons.RightShoulder == ButtonState.Pressed)
            {
                if(MediaPlayer.State == MediaState.Playing)
                {
                    MediaPlayer.Pause();
                }
            }
            oldpad1 = pad1;
            #endregion

            #region Keyboard
            /**float volume2 = keyboard.IsKeyDown(Keys.VolumeUp);
            float pitch2 = pad1.ThumbSticks.Left.Y;
            float pan2 = pad1.ThumbSticks.Right.X;**/
            

            if (oldkeyboard.IsKeyUp(Keys.S) && keyboard.IsKeyDown(Keys.S))
            {
                snare.Play();
            }
            if (oldkeyboard.IsKeyUp(Keys.K) && keyboard.IsKeyDown(Keys.K))
            {
                kick.Play();
            }
            if (oldkeyboard.IsKeyUp(Keys.C) && keyboard.IsKeyDown(Keys.C))
            {
                cymbolTing.Play();
            }
            if (oldkeyboard.IsKeyUp(Keys.T) && keyboard.IsKeyDown(Keys.T))
            {
                top.Play();
            }
            if (oldkeyboard.IsKeyUp(Keys.O)&& keyboard.IsKeyDown(Keys.O))
            {
                if (MediaPlayer.State == MediaState.Paused)
                {
                    MediaPlayer.Resume();
                }
                else
                {
                    MediaPlayer.Play(tune);
                }

            }

            if (oldkeyboard.IsKeyUp(Keys.P) && keyboard.IsKeyDown(Keys.P))
            {
                if(MediaPlayer.State == MediaState.Playing)
                {
                    MediaPlayer.Pause();
                }
            }
            if (rythm == 1)
            {
                kick.Play();
            }
            if (rythm == 2)
            {
                snare.Play();
            }
            if (rythm == 3)
            {
                top.Play();
            }
            if (rythm == 4)
            {
                cymbolTing.Play();
            }
            
            
            oldkeyboard = keyboard;
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

            base.Draw(gameTime);
        }
    }
}
