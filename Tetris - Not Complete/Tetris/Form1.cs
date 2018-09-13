using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Tetris
{
    public partial class Form1 : Form
    {
        //User Control
        
        //Blocks
        List<Button> playBlocks = new List<Button>();
        Button[] bottomBlocks = new Button[7];
        int bottomBlockInt=54;
        Point boardLocation, newBoardLocation;
        //Scoring
        int score;
        //Block Falling
        bool isBlockFalling;
        int blockFallingPos = 3, blockFallingPosNew, blockFallingPosOld;
        //Debug
        bool debugMode = true;
        public Form1()
        {
            InitializeComponent();
            LoadGame();
        }

        void LoadGame()
        {
            gamePnl.Visible = true;
            boardLocation = new Point(0, 60);
            newBoardLocation = boardLocation;
            
            for(int i = 0; i < 61; i++)
            {
                playBlocks.Add(new Button());
                playBlocks[i].Name = "PlayBlock" + i;
                if (debugMode == true)
                    playBlocks[i].Text = i.ToString();
                if(newBoardLocation.X > 400)
                {
                    newBoardLocation.X = boardLocation.X;
                    newBoardLocation.Y += 45;
                }
                
                playBlocks[i].Location = newBoardLocation;
                newBoardLocation.X += 45;
                playBlocks[i].Size = new Size(40, 40);
                playBlocks[i].BackColor = Color.Green;
                playBlocks[i].Enabled = false;
                gamePnl.Controls.Add(playBlocks[i]);
                isBlockFalling = false;
                gameTime.Start();
                userControl.Start();
            }
            #region BottomBlocks
            for(int i = 0; i < bottomBlocks.Count(); i++)
            {
                bottomBlocks[i] = playBlocks[bottomBlockInt];
                bottomBlockInt++;
            }
            
            #endregion


        }

        

        void BlockFall()
        {
            if (isBlockFalling == false)
            {
                blockFallingPosNew = blockFallingPos;
                playBlocks[blockFallingPosNew].BackColor = Color.Purple;
                blockFallingPosOld = blockFallingPosNew;
                isBlockFalling = true;
            }
            else
            {
                
                blockFallingPosNew += 9;
                if(blockFallingPosNew > 61)
                {
                    isBlockFalling = false;
                    blockFallingPosNew = blockFallingPosOld;
                }
                /*if(blockFallingPosNew!=blockFallingPosOld)
                {
                    playBlocks[blockFallingPosOld].BackColor = Color.Green;
                }*/
                //playBlocks[blockFallingPosNew].BackColor = Color.Purple;
                blockFallingPosOld = blockFallingPosNew;
            }
        }

        void SpaceChecker()
        {
            for(int i = 0; i < playBlocks.Count(); i++)
            {
                if(blockFallingPosNew!=i)
                {
                    playBlocks[i].BackColor = Color.Green;
                }
                else
                {
                    playBlocks[i].BackColor = Color.Purple;
                }
            }
        }

        void BlockLeftRight()
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (blockFallingPosNew != 0)
                    blockFallingPosNew--;

            }
            if (Control.ModifierKeys == Keys.Alt)
            {
                if (blockFallingPosNew != 6)
                    blockFallingPosNew++;

            }
            //blockFallingPosOld = blockFallingPosNew;
        }

        private void userControl_Tick(object sender, EventArgs e)
        {
            BlockLeftRight();
            
        }

        private void gameTime_Tick(object sender, EventArgs e)
        {
            BlockFall();
            SpaceChecker();
        }


        
    }
}
