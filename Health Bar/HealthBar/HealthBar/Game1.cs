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

//Programmed By Ramsey Khadder, 2011

namespace HealthBar
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background;
        Rectangle backgroundRect;

        Texture2D medicineBottle;
        List<Rectangle> medicineBottleRects;

        Texture2D Goomba;
        List<Rectangle> GoombaRects;
         
        List<Vector2> GoombaPosition;

        Texture2D[] playerDirections;
        Texture2D playerSprite;
        Vector2 playerPosition;
        Rectangle playerRect;

        Texture2D[] treeType;
        Texture2D tree;
        List<Rectangle> treeRects;
        List<Vector2> treePosition;

        Texture2D healthSprite;
        Rectangle healthRect;
        SpriteFont healthFont;
        int health;
        Rectangle healthAmount;

        int movementLeft;
        int movementRight;
        int gameScene;
        
        string gameEnd = "";
        List<bool> Goombup = new List<bool>();
        int q;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Window.Title = "Mario's Super Adventure";
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("Hospital Parking Lot");
            backgroundRect = new Rectangle(0, 0, 800, 600);

            medicineBottle = Content.Load<Texture2D>("Medicine Bottle");
            medicineBottleRects = new List<Rectangle>();
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                medicineBottleRects.Add(new Rectangle(random.Next(350, 750), random.Next(0, 550), medicineBottle.Width / 4, medicineBottle.Height / 4));
            }

            Goomba = Content.Load<Texture2D>("Goomba");
            GoombaPosition = new List<Vector2>();
            GoombaRects = new List<Rectangle>();
            for (int i = 0; i < 3; i++)
            {
                GoombaRects.Add(new Rectangle(random.Next(0, 750), random.Next(0, 550), Goomba.Width / 6, Goomba.Height / 6));
                Goombup.Add(true);
                
                GoombaPosition.Add(new Vector2(GoombaRects[i].X, GoombaRects[i].Y));
            }


            playerDirections = new Texture2D[6];
            playerDirections[0] = Content.Load<Texture2D>("Up");
            playerDirections[1] = Content.Load<Texture2D>("Down");
            playerDirections[2] = Content.Load<Texture2D>("Left");
            playerDirections[3] = Content.Load<Texture2D>("Right");
            playerDirections[4] = Content.Load<Texture2D>("Right2");
            playerDirections[5] = Content.Load<Texture2D>("Left2");
            playerSprite = playerDirections[0];
            playerPosition = new Vector2(700, 300);
            playerRect = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerSprite.Width, playerSprite.Height);

            treeType = new Texture2D[4];
            treeType[0] = Content.Load<Texture2D>("Tree 1");
            treeType[1] = Content.Load<Texture2D>("Tree 2");
            treeType[2] = Content.Load<Texture2D>("Tree 3");
            treeType[3] = Content.Load<Texture2D>("Tree 4");
            treeRects = new List<Rectangle>();
            for (int t = 0; t < 5; t++)
            {
                treeRects.Add(new Rectangle(random.Next(0, 750), random.Next(0, 500), playerSprite.Width, playerSprite.Height));
            }
            //health
            health = 1;
            healthSprite = Content.Load<Texture2D>("Heart 5");
            healthRect = new Rectangle(0, 0, 215/5, 205/5);
            healthAmount = new Rectangle(0, 0, 215*2, 205*2);
            
            healthFont = Content.Load<SpriteFont>("Impact");
            //movement
            movementLeft = 0;//To determin if Mario goes into walking animation
            movementRight = 0;
            gameScene = 1;

            
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Random random = new Random();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (gameScene == 1)
            {
                #region Player Control
                if (Keyboard.GetState().IsKeyDown(Keys.Up) && playerPosition.Y > 0)
                {
                    playerPosition.Y -= 3;
                    playerSprite = playerDirections[0];
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down) &&
                    (playerPosition.Y + playerRect.Height) < 600)
                {
                    playerPosition.Y += 3;
                    playerSprite = playerDirections[1];
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left) &&
                    playerPosition.X > 0)
                {
                    playerPosition.X -= 3;

                    playerSprite = playerDirections[2];


                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right) &&
                    (playerPosition.X + playerRect.Width) < 800)
                {
                    playerPosition.X += 3;

                    playerSprite = playerDirections[3];

                }
                playerRect = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerSprite.Width, playerSprite.Height);
                #endregion

                #region medicine respawn
                for (int i = 0; i < medicineBottleRects.Count(); i++)
                    if (playerRect.Intersects(medicineBottleRects[i]))
                    {
                        health += 1;
                        healthAmount = new Rectangle(0, 0, health * 2, 205);
                        medicineBottleRects.RemoveAt(i);
                        i--;//To compensate for removing array item
                    }
                if (medicineBottleRects.Count < 1)
                {
                    medicineBottleRects.Add(new Rectangle(random.Next(350, 750), random.Next(0, 550), medicineBottle.Width / 4, medicineBottle.Height / 4));
                }
                #endregion

                #region Goomba

                /*for (q = 0; q < Goombup.Count(); q++)
                {
                    if (Goombup[q])
                    {
                        if ((GoombaPosition[q].Y + GoombaRects[q].Height) >= 0)
                        {
                            int tempY = (int)GoombaPosition[q].Y - 3;
                            
                            
                        }
                    }

                }*/
               

                for (int i = 0; i < GoombaRects.Count(); i++)
                    if (playerRect.Intersects(GoombaRects[i]))
                    {
                        health -= 1;
                        healthRect = new Rectangle(0, 0, health * 2, 205);
                        GoombaRects.RemoveAt(i);
                        i--;
                    }
                
                #endregion
            }
            if (health < 1)
                {
                    gameScene  = 0;
                }
            if (gameScene  == 0)
                {
                    gameEnd = "GAME\nOVER";

                }
            if (health > 4)
                {
                    gameScene = 2;
                }
            if (gameScene == 2)
                {
                    gameEnd = "You\nWon!!";
                }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundRect, Color.White);
            foreach (Rectangle rect in medicineBottleRects)
                spriteBatch.Draw(medicineBottle, rect, Color.White);
            foreach (Rectangle rect in GoombaRects)
                spriteBatch.Draw(Goomba, rect, Color.White);
            spriteBatch.Draw(playerSprite, playerRect, Color.White);
            spriteBatch.Draw(healthSprite, healthRect, healthAmount, Color.White);
            spriteBatch.DrawString(healthFont, "HEALTH", new Vector2(0, 30), Color.White);
            spriteBatch.DrawString(healthFont, movementLeft.ToString(), new Vector2(0, 50), Color.White);
            spriteBatch.DrawString(healthFont, movementRight.ToString(), new Vector2(0, 70), Color.White);
            //spriteBatch.DrawString(healthFont, GoombaPosition[0].Y.ToString(), new Vector2(0, 90), Color.White);
            spriteBatch.DrawString(healthFont, gameEnd, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.White, 0f, new Vector2(0,0), 5f,SpriteEffects.None, 0.05f);
            
            
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
