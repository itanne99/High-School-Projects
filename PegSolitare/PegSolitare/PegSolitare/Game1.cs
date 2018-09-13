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


namespace PegSolitare
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //Pre-Made Content
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Board Layout
        Texture2D boardPicture;
        Rectangle boardSize;
        Vector2[] boardLocation = new Vector2[49];
        Rectangle[] boardMarkers = new Rectangle[49];
        bool newBoard, moveValid;
        int boardValueDropped, delPeg, boardValuePicked, delBoardVal;
        Vector2 offBoard = new Vector2(1000, 1000);
        //Peg Layout
        Texture2D pegMarker;
        Rectangle[] pegOutline = new Rectangle[49];
        Vector2[] pegLocation = new Vector2[49];
        int pegValue, pegDelValue, situation, pegDelSitu, delpegVal;
        bool[] isPegPickedUp = new bool[49];
        bool[] isPegInLocation = new bool[49];
        
        //Controls
        Point cursor;
        MouseState mouse, oldMouse;
        KeyboardState keyboard, oldKeyboard;
        
        //Score
        int score = 32;

        //Fonts
        SpriteFont text, debugText;
        Texture2D title;
        Rectangle titleOutline;
        String pegState, debugStatement;

        //Quit Button
        Rectangle quitButtonRect;
        Texture2D quitButton, quitButtonMouseOver;

        //Reset Button
        Rectangle resetButtonRect;
        Texture2D resetButton, resetButtonMouseOver;

        //You Win Logo
        Rectangle youWinRect;
        Texture2D youWinTexture;

        //You Lose Logo
        Rectangle youLoseRect;
        Texture2D youLoseTexture;

        //Scene Manager
        int Scene;
        bool DebugMode;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Window.Title = "Peg Solitare";
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            boardPicture = Content.Load<Texture2D>("pegsolitaireoutline");
            boardSize = new Rectangle(200,100, 400, 400);
            pegMarker = Content.Load<Texture2D>("peg");
            title = Content.Load<Texture2D>("psTitle");
            debugText = Content.Load<SpriteFont>("DebugText");
            titleOutline = new Rectangle(150, 0, 500, 100);
            text = Content.Load<SpriteFont>("Font1");
            quitButton = Content.Load<Texture2D>("QuitButton");
            quitButtonMouseOver = Content.Load<Texture2D>("QuitButtonMouseOver");
            quitButtonRect = new Rectangle(706, 570, 94, 30);
            resetButton = Content.Load<Texture2D>("ResetButton");
            resetButtonMouseOver = Content.Load<Texture2D>("ResetButtonIsMouseOver");
            resetButtonRect = new Rectangle(610, 570, 94, 30);
            youWinRect = new Rectangle(125, 100, 546, 117);
            youWinTexture = Content.Load<Texture2D>("You Win!");
            youLoseRect = new Rectangle(100, 100, 383, 80);
            youLoseTexture = Content.Load<Texture2D>("You Lose!");
            newBoard = true;
            #region board Locations
            //distance between boxes is 57 pixels X
            boardLocation[0] = new Vector2(211, 112.5f); //outside board
            boardLocation[1] = new Vector2(268, 112.5f); //outside board
            boardLocation[2] = new Vector2(325, 112.5f);
            boardLocation[3] = new Vector2(382, 112.5f);
            boardLocation[4] = new Vector2(439, 112.5f);
            boardLocation[5] = new Vector2(496, 112.5f); //outside board
            boardLocation[6] = new Vector2(553, 112.5f); //outside board
            boardLocation[7] = new Vector2(211, 169.5f); //outside board
            boardLocation[8] = new Vector2(268, 169.5f); //outside board
            boardLocation[9] = new Vector2(325, 169.5f);
            boardLocation[10] = new Vector2(382, 169.5f);
            boardLocation[11] = new Vector2(439, 169.5f);
            boardLocation[12] = new Vector2(496, 169.5f); //outside board
            boardLocation[13] = new Vector2(553, 169.5f); //outside board
            boardLocation[14] = new Vector2(211, 226.5f);
            boardLocation[15] = new Vector2(268, 226.5f);
            boardLocation[16] = new Vector2(325, 226.5f);
            boardLocation[17] = new Vector2(382, 226.5f);
            boardLocation[18] = new Vector2(439, 226.5f);
            boardLocation[19] = new Vector2(496, 226.5f);
            boardLocation[20] = new Vector2(553, 226.5f);
            boardLocation[21] = new Vector2(211, 283.5f);
            boardLocation[22] = new Vector2(268, 283.5f);
            boardLocation[23] = new Vector2(325, 283.5f);
            boardLocation[24] = new Vector2(382, 283.5f);
            boardLocation[25] = new Vector2(439, 283.5f);
            boardLocation[26] = new Vector2(496, 283.5f);
            boardLocation[27] = new Vector2(553, 283.5f);
            boardLocation[28] = new Vector2(211, 340.5f);
            boardLocation[29] = new Vector2(268, 340.5f);
            boardLocation[30] = new Vector2(325, 340.5f);
            boardLocation[31] = new Vector2(382, 340.5f);
            boardLocation[32] = new Vector2(439, 340.5f);
            boardLocation[33] = new Vector2(496, 340.5f);
            boardLocation[34] = new Vector2(553, 340.5f);
            boardLocation[35] = new Vector2(211, 397.5f); //outside board
            boardLocation[36] = new Vector2(268, 397.5f); //outside board
            boardLocation[37] = new Vector2(325, 397.5f);
            boardLocation[38] = new Vector2(382, 397.5f);
            boardLocation[39] = new Vector2(439, 397.5f);
            boardLocation[40] = new Vector2(496, 397.5f); //outside board
            boardLocation[41] = new Vector2(553, 397.5f); //outside board
            boardLocation[42] = new Vector2(211, 454.5f); //outside board
            boardLocation[43] = new Vector2(268, 454.5f); //outside board
            boardLocation[44] = new Vector2(325, 454.5f);
            boardLocation[45] = new Vector2(382, 454.5f);
            boardLocation[46] = new Vector2(439, 454.5f);
            boardLocation[47] = new Vector2(496, 454.5f); //outside board
            boardLocation[48] = new Vector2(553, 454.5f); //outside board

            for (int i = 0; i < boardLocation.Length; i++)
            {
                boardMarkers[i] = new Rectangle((int)boardLocation[i].X, (int)boardLocation[i].Y, 35, 35);
            }
            #endregion
            resetPegBoard();
            
            pegState = " ";
            debugStatement = " ";
            Scene = 0;
            DebugMode = false;
        }

        private void resetPegBoard()
        {
            
            
            for (int i = 0; i < boardLocation.Length; i++)
            {
                
                pegLocation[i] = boardLocation[i];
                isPegInLocation[i] = true;
                pegOutline[i] = new Rectangle((int)pegLocation[i].X, (int)pegLocation[i].Y, 34, 34);
                
                //if (i >= 0 || i <= 2 || i >= 5 || i <= 7 || i >= 11 || i <= 14 || i = 36 || i = 37 || i ==41 || i == 42)
                if ((i >= 0 && i <= 1) || (i >= 5 && i <= 8) || (i >= 12 && i <= 13) || i == 35 || i == 36 || i == 40 || i == 41 || i == 47 || i == 48 || i == 42 || i == 43)
                {
                    pegOutline[i] = new Rectangle((int)offBoard.X, (int)offBoard.Y, 34, 34);
                    isPegInLocation[i] = true;
                }
               
                if(i==24)
                {
                    pegOutline[i] = new Rectangle((int)offBoard.X, (int)offBoard.Y, 35, 35);
                    isPegInLocation[i] = true;
            }
                
            }
           
            pegState = "Board Reset!!";
            score = 32;
        }

        

        protected override void UnloadContent()
        {
           
        }

        
        void CheckBoolArrays()
        {
            for (int i = 0; i < isPegPickedUp.Count(); i++)
            {
                if (isPegPickedUp[i] == true)
                {
                    pegValue = i;
                    
                }
            }
            
        }

        void CheckBoardLocation()
        {
                delPeg = boardValuePicked - boardValueDropped;
                //Checks if there is a peg in the current boardLocation
                if (isPegInLocation[boardValueDropped] == true )
                {
   
                    situation = 1;
                }

                //Checks if the mouse is in the boarder marker
                else if (boardMarkers[boardValueDropped].Contains(cursor) && isPegInLocation[boardValueDropped] == false)
                {
                    if (delPeg == 2 || delPeg == -2 || delPeg == 14 || delPeg == -14)
                    {
                        situation = 2;
                    }
                    else
                        situation = 4;
                }
                //If peg does not meet any conditon above it will return peg to last location
                else
                {
                    situation = 3;
                }

                switch (situation)
            {
                case 1:
                    {
                        pegOutline[pegValue] = new Rectangle((int)pegLocation[pegValue].X, (int)pegLocation[pegValue].Y, 34, 34);
                        debugStatement = "Peg in this location. Situtuation: " + situation;
                        pegState = "Peg Returned to last location";
                        break;
                    }
                case 2:
                    {
                        
                        pegLocation[pegValue] = boardLocation[boardValueDropped];
                        pegOutline[pegValue] = new Rectangle((int)pegLocation[pegValue].X, (int)pegLocation[pegValue].Y, 34, 34);
                        debugStatement = "Placed in BoardMarker " + boardValueDropped + "Situtuation: " + situation;
                        pegState = "Peg Placed in " + boardValueDropped;
                        isPegInLocation[boardValueDropped] = true;
                        MovementCheck();
                        score--;
                        break;
                    }
                case 3:
                    {
                        debugStatement = "Returned to BoardMarker " + pegValue + "Situtuation: " + situation;
                        pegOutline[pegValue] = new Rectangle((int)pegLocation[pegValue].X, (int)pegLocation[pegValue].Y, 34, 34);
                        pegState = "Peg Returned to last location";
                        
                        break;
                    }
                case 4:
                    {
                        debugStatement = "Not valid move " + pegValue + "Situtuation: " + situation;
                        pegOutline[pegValue] = new Rectangle((int)pegLocation[pegValue].X, (int)pegLocation[pegValue].Y, 34, 34);
                        pegState = "Peg Returned to last location";
                        break;
                    }
            }


            
        }
        void CheckPegPlacement()
        {
            for (int i = 0; i < pegOutline.Length; i++)
            {
                for (int j = 0; j < pegOutline.Length; j++)
                {
                    if (boardMarkers[i].Contains(pegOutline[j]))
                    {
                        isPegInLocation[i] = true;
                        break;
                    }
                    else
                    {
                        isPegInLocation[i] = false;
                    }
                }
                if ((i >= 0 && i <= 1)||(i >= 5 && i <= 8)||(i >= 12 && i <= 13) || i == 35 || i == 36 || i == 40 || i == 41 || i == 47 || i == 48 || i == 42 || i == 43 )
                {
                    
                    isPegInLocation[i] = true;
                }
                
            }

        }
        void MovementCheck()
        {
            
             //8, 12 ,14 are vertical movement values
            if (delPeg == -2) //right to left
            {
                delBoardVal = boardValueDropped - 1;
            }
            if (delPeg == 2) //left to right
            {   
                delBoardVal = boardValueDropped + 1;
            }
            
            if (delPeg == 14) //7
            {   
                delBoardVal = boardValueDropped + 7;
            }
            if (delPeg == -14)
            {   
                delBoardVal = boardValueDropped - 7;
            }
            for (int i = 0; i < pegOutline.Length; i++)
            {
                if (boardMarkers[delBoardVal].Intersects(pegOutline[i]))
                {
                    delpegVal = i;
                    moveValid = true;
                    break;
                }
                else if (!boardMarkers[delBoardVal].Intersects(pegOutline[i]))
                {
                    moveValid = false;
                   
                }
                
                
            }
            if (moveValid)
            {

                pegOutline[delpegVal] = new Rectangle((int)offBoard.X, (int)offBoard.Y, 35, 35);
                isPegInLocation[delBoardVal] = false;
            }
            else if (!moveValid)
            {
                pegOutline[pegValue] = new Rectangle((int)pegLocation[boardValuePicked].X, (int)pegLocation[boardValuePicked].Y, 34, 34);
                debugStatement = "Peg in this location. Situtuation: " + situation;
                pegState = "Peg Returned to last location";
                situation = 1;
            }

            
            
           
        }
        protected override void Update(GameTime gameTime)
        {
            
            mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();
            cursor = new Point(mouse.X, mouse.Y);
            #region Debug Menu
            if (DebugMode)
            {
                if (keyboard.IsKeyDown(Keys.F1) && oldKeyboard.IsKeyUp(Keys.F1))
                {
                    Scene = 0;
                }
                if (keyboard.IsKeyDown(Keys.F2) && oldKeyboard.IsKeyUp(Keys.F2))
                {
                    resetPegBoard();
                    Scene = 1;
                }
                if (keyboard.IsKeyDown(Keys.F3) && oldKeyboard.IsKeyUp(Keys.F3))
                {
                    Scene = 2;
                    score = 1;
                }
                if (keyboard.IsKeyDown(Keys.F4) && oldKeyboard.IsKeyUp(Keys.F4))
                    Scene = 3;
            }
            #endregion
            #region Main Menu
            if (Scene == 0)
            {
                if (keyboard.IsKeyDown(Keys.D1) && oldKeyboard.IsKeyUp(Keys.D1))
                {
                    Scene = 1;
                    resetPegBoard();
                }
                if (DebugMode == true)
                {
                    if (keyboard.IsKeyDown(Keys.F) && oldKeyboard.IsKeyUp(Keys.F))
                    {
                        DebugMode = false;
                    }
                }
                if (DebugMode == false)
                {
                    if (keyboard.IsKeyDown(Keys.O) && oldKeyboard.IsKeyUp(Keys.O))
                    {
                        DebugMode = true;
                    }
                }
                if (keyboard.IsKeyDown(Keys.D3) && oldKeyboard.IsKeyUp(Keys.D3))
                    this.Exit();
                
            }
            #endregion
            #region Main Game

            if (Scene == 1)
            {
                /*if (keyboard.IsKeyDown(Keys.F9) && oldKeyboard.IsKeyUp(Keys.F9))
                {
                    resetPegBoard();
                    pegState = "Board Reset";
                }*/
                if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
                {
                    //situation = 0;
                    for (int i = 0; i < pegOutline.Count(); i++)
                    {
                        if (pegOutline[i].Contains(cursor))
                        {
                            isPegPickedUp[i] = true;
                            
                            IsMouseVisible = false;
                            CheckBoolArrays();
                            pegState = "Peg " + pegValue + " Picked Up";
                            isPegInLocation[i] = false;
                        }
                        if (boardMarkers[i].Contains(cursor))
                        {
                            boardValuePicked = i;
                        }
                        CheckPegPlacement();
                        delPeg = 0;
                        
                    }
                    
                }
                #region Peg Placer
                if (isPegPickedUp[pegValue] == true)
                {
                    pegOutline[pegValue].X = cursor.X ;
                    pegOutline[pegValue].Y = cursor.Y;
                    if (mouse.RightButton == ButtonState.Pressed)
                    {
                        for (int i = 0; i < boardLocation.Length; i++)
                        {
                            if (boardMarkers[i].Contains(cursor))
                            {
                                boardValueDropped = i;
                                break;
                            }
                        }
                        CheckBoolArrays();
                        CheckPegPlacement();
                        IsMouseVisible = true;
                        isPegPickedUp[pegValue] = false;
                        CheckBoardLocation();
                    }

                }
            }
            #endregion

            if (quitButtonRect.Contains(cursor))
            {
                if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
                    this.Exit();
            }
            if (resetButtonRect.Contains(cursor))
            {
                if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
                {
                    resetPegBoard();
                    Scene = 1;
                }
                
            }
            if (score <= 1)
            {
                Scene = 2;
            }
            #endregion
            
            oldKeyboard = keyboard;
            oldMouse = mouse;
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (Scene == 0 || Scene == 1)
            {
                spriteBatch.Draw(title, titleOutline, Color.White);
            }
            #region Main Menu
            if (Scene == 0)
            {
                spriteBatch.DrawString(text, "[1] START GAME", new Vector2(260, 150), Color.White);
                if (DebugMode == true)
                {
                    spriteBatch.DrawString(text, "[F]", new Vector2(260, 200), Color.Red);
                    spriteBatch.DrawString(text, "ON", new Vector2(600, 200), Color.Green);
                }
                if (DebugMode == false)
                {
                    spriteBatch.DrawString(text, "[O]", new Vector2(260, 200), Color.Green);
                    spriteBatch.DrawString(text, "OFF", new Vector2(600, 200), Color.Red);
                }

                spriteBatch.DrawString(text, "DEBUG MODE", new Vector2(315, 200), Color.White);
                spriteBatch.DrawString(text, "[3] QUIT", new Vector2(260, 250), Color.White);
            }
            #endregion
            #region Main Game
            if (Scene == 1)
            {
                spriteBatch.Draw(boardPicture, boardSize, Color.White);

                for (int i = 0; i < pegLocation.Count(); i++)
                {
                    spriteBatch.Draw(pegMarker, pegOutline[i], Color.White);
                }



                spriteBatch.DrawString(text, pegState, new Vector2(275, 525), Color.Violet);
                spriteBatch.Draw(quitButton, quitButtonRect, Color.White);
                if (quitButtonRect.Contains(cursor))
                {
                    spriteBatch.Draw(quitButtonMouseOver, quitButtonRect, Color.Red);
                }
                spriteBatch.Draw(resetButton, resetButtonRect, Color.White);
                if (resetButtonRect.Contains(cursor))
                {
                    spriteBatch.Draw(resetButtonMouseOver, resetButtonRect, Color.White);
                }
                spriteBatch.DrawString(debugText, "Score: " + score, new Vector2(0, 500), Color.White);
                if (DebugMode == true)
                {
                    spriteBatch.DrawString(debugText, "Mouse Pos: " + mouse.X.ToString() + " " + mouse.Y.ToString(), new Vector2(0, 560), Color.White);
                    spriteBatch.DrawString(debugText, "Peg " + pegValue + " Pos: " + pegLocation[pegValue].X.ToString() + " " + pegLocation[pegValue].Y.ToString(), new Vector2(0, 540), Color.White);
                    spriteBatch.DrawString(debugText, debugStatement, new Vector2(0, 520), Color.White);

                    spriteBatch.DrawString(debugText, "Is Peg there : " + boardValuePicked + " " + isPegInLocation[pegValue] + " " + pegValue, new Vector2(0, 480), Color.White);
                    spriteBatch.DrawString(debugText, "Board Picked Value: " + boardValuePicked, new Vector2(0, 460), Color.White);
                    spriteBatch.DrawString(debugText, "Board Value: " + boardValueDropped, new Vector2(0, 440), Color.White);
                    spriteBatch.DrawString(debugText, "delPeg: " + delPeg, new Vector2(0, 420), Color.White);
                    spriteBatch.DrawString(debugText, "Situation: " + situation, new Vector2(0, 400), Color.White);
                    spriteBatch.DrawString(debugText, "Peg Deleted: " + delpegVal, new Vector2(0, 380), Color.White);

                }
            }
            #endregion
            #region Win Screen
            if (Scene == 2)
            {
                spriteBatch.Draw(youWinTexture, youWinRect, Color.White);
                spriteBatch.Draw(quitButton, quitButtonRect, Color.White);
                if (quitButtonRect.Contains(cursor))
                {
                    spriteBatch.Draw(quitButtonMouseOver, quitButtonRect, Color.Red);
                }
                spriteBatch.Draw(resetButton, resetButtonRect, Color.White);
                if (resetButtonRect.Contains(cursor))
                {
                    spriteBatch.Draw(resetButtonMouseOver, resetButtonRect, Color.White);
                }
            }

            #endregion
            spriteBatch.End();
            base.Draw(gameTime);
        }

        #region Comments
        /*
         * Peg Solitare Porject
         * Ido, Nicky, Simone
        2/28/18
        Group - We added the board outline, 
         * We have the marbles (but are not in the game yet).
         * We set up variables and decided on the movement systme
        3/1/18
        Group - We added Vector values to all the pegs
         * We made for loops that will draw the pegs and set their locations
        Ido - Worked on after school
         * Added the rest of the Pegs
         * Nicky made a title which I added to the game
         * I will add a main menu screen to the game
        3/5/18
        Group - Set up mouse
         * Getting position
         * Attempted to be able to change location of pegs
        3/6/18
        Group - Set up movement of pegs
         * Pegs can be lifted and moved around
         * Worked on a restart of peg locations
        3/7/18
        Ido - Worked on Prog during Snow Day
         * Made board reset work
         * Added text to show that the peg was dropped and picked up
         * Was able to make the Pegs be dropped where there is no peg
         * if peg is dropped where ther is a peg it will return to its orignal location
         * if peg is dropped off board same result will happen
         * Added a Quit Button to the Game. User must Left Click to Exit
         * Next is to make the game check if it is legal for the peg to be placed where it is.
        3/8/18
        Group - we made it so the pegs can be placed and returned to their last location of the statement is not true
         * We need to work on how to make pegs disapper
        3/15/18
        Group
         * fixed wrong peg disapearing, still have the problem with only one peg disapearing
         * found distances for moving vertically
         * made a list of accepted movements, they are the values used to delete pegs.
        3/19/18
         * set up deleting pegs on vertical movement
         * set up check for legal moves
         * having issue with multiple pegs being able to be in one location.
         * having issue with pegs not deleting when jumped over. (usually in row 4, but sometimes it's other rows as well)
         * having issue with pegs not being able to do legal moves.
         * having issue with the wrong peg being deleted when moving to certain locations on the board.
        3/20/18
         * Theory: the peg with a certain number is being deleted instead of the peg inside of the board marker with that number.
        3/23/18
        Nicky
         * updated board locations so that it is an array of 49, only 2 checks are needed for deleting
         * set up valid movement checking
         * still having issue with 2 pegs in 1 space
        3/28/18
        Ido
         * Yesterday we finished the game. 
         * Pegs move to where they are suppose to.
         * Pegs no longer over lap
         * If the score gets down to one then the player will win
         */
        
        
        #endregion
    }
}
