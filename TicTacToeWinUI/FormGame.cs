using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeGameLogic;
using TicTacToeWinUI.Properties;
using Microsoft.VisualBasic.ApplicationServices;


namespace TicTacToeWinUI
{
    public partial class FormGame : Form
    {
        private const int k_PictureBoxSize = 50;
        private const int k_Padding = 2;
        private const int k_WidthExtention = 20;
        private const int k_HeightExtention = 100;
        private const int k_HeightMargin = 60;
        private const int k_WidthMargin = 5;
        private const int k_SleepAfterMovement = 120;
        private FormSettings m_FormGameSettings;
        private PictureBox[,] m_PictureBoxBoard;
        private EventGameDetailsArguments m_EventGameDetailsArguments;
        private Board m_Board;
        private Game m_Game;
        private bool m_IsUserTurn = true;
        private bool m_IsClickProcessing = false;

        public FormGame()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            m_FormGameSettings = new FormSettings();
            m_FormGameSettings.ShowDialog();


            if (m_FormGameSettings.DialogResult == DialogResult.OK)
            {

                initFormBoardGame();
                initGameDetails();
            }
        }
       

        private void initGameDetails()
        {
            m_EventGameDetailsArguments = new EventGameDetailsArguments(
            m_FormGameSettings.Player1Name,
            m_FormGameSettings.Player2Name,
            m_FormGameSettings.BoardCols * m_FormGameSettings.BoardRows,
            m_FormGameSettings.Player2Type);
           
            labelPlayer1.Text = m_FormGameSettings.Player1Name;
            labelPlayer2.Text = m_FormGameSettings.Player2Name;

        }

        private void initFormBoardGame()
        {
            m_Game = new Game();
            m_PictureBoxBoard = new PictureBox[m_FormGameSettings.BoardRows, m_FormGameSettings.BoardCols];
            int formWidth = (2 * k_WidthMargin) + (k_PictureBoxSize * m_FormGameSettings.BoardCols) + k_WidthExtention;
            int formHeight = (2 * k_HeightMargin) + (k_PictureBoxSize * m_FormGameSettings.BoardRows) + k_HeightExtention;
            m_Board = new Board(m_FormGameSettings.BoardRows);

            this.ClientSize = new Size(formWidth, formHeight);

            for (int i = 0; i < m_FormGameSettings.BoardRows; i++)
            {
                for (int j = 0; j < m_FormGameSettings.BoardCols; j++)
                {
                    m_PictureBoxBoard[i, j] = new PictureBox();
                    initPictureBox(m_PictureBoxBoard[i, j], i, j);
                    Controls.Add(m_PictureBoxBoard[i, j]);
                    m_PictureBoxBoard[i, j].Click += pictureBox_ClickHndler;
                }
            }


        }
        //pictureBox_Click(m_PictureBoxBoard[i, j], EventArgs.Empty);
        private void pictureBox_ClickHndler(object sender, EventArgs e)
        {
            if (!m_IsUserTurn || m_IsClickProcessing)
                return;
            m_IsClickProcessing = true;
            int o_BestRow;
            int o_Bestcol;
            PictureBox pictureBoxClicked = sender as PictureBox;
            if (pictureBoxClicked != null)
            {
                bool isUserClickValid = pictureBox_Click(sender, e);
                if (isUserClickValid)
                {
                    m_IsUserTurn = false;
                    DisablePictureBoxes();
                    if (m_FormGameSettings.Player2Type == ePlayerType.ComputerHard)
                    {
                        m_Game.FindBestCell(m_Board.m_GameMatrix, m_Board.GetMatsize(), eCell.P2, out o_BestRow, out o_Bestcol);
                        pictureBox_Click(m_PictureBoxBoard[o_BestRow, o_Bestcol], EventArgs.Empty);
                    }
                    else if (m_FormGameSettings.Player2Type == ePlayerType.Computer)
                    {
                        int randRow = 0;
                        int randCol = 0;
                        m_Game.FindRandCell(m_Board.m_GameMatrix, m_Board.GetMatsize(), eCell.P2, ref randRow, ref randCol);
                        pictureBox_Click(m_PictureBoxBoard[randRow, randCol], EventArgs.Empty);
                    }
                    EnablePictureBoxes();
                    m_IsUserTurn = true;
                }
            }
            m_IsClickProcessing = false;
        }
        private void DisablePictureBoxes()
        {
            foreach (PictureBox pictureBox in m_PictureBoxBoard)
            {
                pictureBox.Enabled = false;
            }
        }

        private void EnablePictureBoxes()
        {
            foreach (PictureBox pictureBox in m_PictureBoxBoard)
            {
                pictureBox.Enabled = true;
            }
        }
        private void PlaySound(string soundName)
        {
            string soundFilePath = Path.Combine(UIResources.ResourcesFolderPath, soundName);

            if (File.Exists(soundFilePath))
            {
                using (SoundPlayer player = new SoundPlayer(soundFilePath))
                {
                    // Decrease the volume
                   

                    // Play the sound
                    player.Play();
                }
            }
            else
            {
                // Handle the case where the sound file is not found
                MessageBox.Show("Sound file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool pictureBox_Click(object sender, EventArgs e)
        {
            bool isClickValid;
            PlaySound(UIResources.ButtonClickSound);


            PictureBox picturBoxClicked = sender as PictureBox;
            bool enablePictureBox = false;
            string cellImage = string.Empty;
            eCell cellType = eCell.Empty;

            if (picturBoxClicked != null && picturBoxClicked.Image == null)
            {

                if (m_EventGameDetailsArguments.CurrentIndexPlayer == 0)
                {
                    cellType = eCell.P1;
                    m_EventGameDetailsArguments.CurrentIndexPlayer++;
                    
                }
                else
                {
                    cellType = eCell.P2;
                    
                    m_EventGameDetailsArguments.CurrentIndexPlayer--;
                    
                }
                int clickedRow = -1;
                int clickedCol = -1;
                int numRows = (int)Math.Sqrt(m_PictureBoxBoard.Length);
                int numCols = numRows;
                for (int row = 0; row < numRows; row++)
                {
                    for (int col = 0; col < numCols; col++)
                    {
                        if (m_PictureBoxBoard[row, col] == picturBoxClicked)
                        {
                            clickedRow = row;
                            clickedCol = col;
                            break;
                        }
                    }
                    if (clickedRow != -1) // Break outer loop if the picture box is found
                        break;
                }
                updatePictureBox(picturBoxClicked, cellType, m_Board, clickedRow, clickedCol);
                isClickValid = true;

            }
            else
            {
                isClickValid = false;
            }
            return isClickValid;

        }
        
        public void updatePictureBox(PictureBox i_PictureBox, eCell i_CellType, Board i_board, int clickedRow, int clickedCol)
        {
            
            string pictureBoxSignPath = i_CellType == eCell.P1 ? UIResources.XSign : UIResources.OSign;
            string fullFilePath = Path.Combine(UIResources.ResourcesFolderPath, pictureBoxSignPath);
            i_PictureBox.Image = Image.FromFile(fullFilePath);
            i_PictureBox.Name = Enum.GetName(typeof(eCell), i_CellType);
            //i_PictureBox.Enabled = i_Enable;
            i_board.SetCell(clickedRow, clickedCol, i_CellType);
            if (m_Game.CheckIfPlayerWin(clickedRow, clickedCol, i_CellType, i_board))
            {
                string winnerMessage;
                if (i_CellType == eCell.P1)
                {
                    if (m_FormGameSettings.Player2Type == ePlayerType.Computer || m_FormGameSettings.Player2Type == ePlayerType.ComputerHard)
                    {
                        PlaySound(UIResources.LoseSound);
                    }
                    else
                    {
                        PlaySound(UIResources.WinSound);
                    }
                    labelScorePlayer2.Text = (int.Parse(labelScorePlayer2.Text) + 1).ToString();
                    winnerMessage = "Player 2 wins!";
                    
                }
                else
                {
                    PlaySound(UIResources.WinSound);
                    labelScorePlayer1.Text = (int.Parse(labelScorePlayer1.Text) + 1).ToString();
                    winnerMessage = "Player 1 wins!";

                }
                MessageBox.Show(winnerMessage, "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnotherGame();

            }
           else if (m_Game.CheckTie(i_board))
            {
                PlaySound(UIResources.TieSound);
                string winnerMessage = "it's a Tie!";
                MessageBox.Show(winnerMessage, "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelScorePlayer1.Text = (int.Parse(labelScorePlayer1.Text) + 1).ToString();
                labelScorePlayer2.Text = (int.Parse(labelScorePlayer2.Text) + 1).ToString();
                AnotherGame();
            }
            


        }

        private void AnotherGame()
        {
            m_EventGameDetailsArguments.CurrentIndexPlayer = 1;
            DialogResult userChoice = new DialogResult();
            userChoice= MessageBox.Show(" do you want another game?", "Game over!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (userChoice == DialogResult.Yes)
            {
               

                ClearPictureBoxes();
                m_Board.InitGameMatrix();
            }
            else
            {
                MessageBox.Show("Goodbye!", "Exiting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void ClearPictureBoxes()
        {
            for (int row = 0; row < m_FormGameSettings.BoardRows; row++)
            {
                for (int col = 0; col < m_FormGameSettings.BoardCols; col++)
                {
                    m_PictureBoxBoard[row, col].Image = null;
                }
            }
        }

       /* public void ContinuePlayingMessageBox(Game i_GameLogic)
        {
            DialogResult userChoice = new DialogResult();
            StringBuilder message = new StringBuilder();
            //YesNoMessageBoxEventArgs yesNoMessageBoxEventArgs = null;
            bool wantToPlayAnotherSession = false;
            /*
            if (i_GameLogic.FinishReason == Game.eSessionFinishType.Draw)
            {
                message.Append("Tie!");
            }
            else if (i_GameLogic.FinishReason == Game.eSessionFinishType.Won)
            {
                message.Append(string.Format("{0} Won!", i_GameLogic.PreviousPlayer.Name));
            }*/
       /*
            message.Append(Environment.NewLine);
            message.Append("Another Round?");
            userChoice = MessageBox.Show(message.ToString(), "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            wantToPlayAnotherSession = userChoice == DialogResult.Yes;
            //yesNoMessageBoxEventArgs = new YesNoMessageBoxEventArgs(wantToPlayAnotherSession);
           // OnYesNoMessageBoxClicked(yesNoMessageBoxEventArgs);
        }*/

        private void initPictureBox(PictureBox i_PictureBox, int i_Rows, int i_Cols)
        {
            i_PictureBox.Size = new Size(k_PictureBoxSize, k_PictureBoxSize);
            i_PictureBox.Padding = new Padding(k_Padding, k_Padding, k_Padding, k_Padding);
            i_PictureBox.Location = new Point(k_WidthMargin + (k_PictureBoxSize * i_Cols), k_HeightMargin + (k_PictureBoxSize * i_Rows));
            i_PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            i_PictureBox.BorderStyle = BorderStyle.Fixed3D;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
