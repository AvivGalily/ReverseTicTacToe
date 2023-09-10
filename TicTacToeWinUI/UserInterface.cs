using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicTacToeGameLogic;

namespace TicTacToeWinUI
{
    public class UserInterface
    {
        private readonly Game r_TicTacToeGameLogic;
        private readonly FormGame r_FormGame;

        public UserInterface()
        {
            r_FormGame = new FormGame();
            r_TicTacToeGameLogic = new Game();
        }

        public void Run()
        {
           //listenToWinUIEvents();
           listenToGameLogicEvents();
            r_FormGame.ShowDialog();
        }
        
        private void listenToGameLogicEvents()
        {
            r_TicTacToeGameLogic.GameFinished += gameFinishedListener;// TODO: Later
           // r_TicTacToeGameLogic.GameStarted += gameStartedListener;
          //  r_TicTacToeGameLogic.BoardUpdated += r_TicTacToeGameLogic_BoardUpdated;
            //r_TicTacToeGameLogic.SwitchedPlayers += r_TicTacToeGameLogic_SwitchedPlayers;
        }
        
        private void gameFinishedListener(object sender)
        {
            Game gameLogic = sender as Game;
           // r_FormGame.ContinuePlayingMessageBox(gameLogic);
        }
        /*
        private void listenToWinUIEvents()
        {
            r_FormGame.GameDetailsUpdated += r_FormGame_GameDetailsUpdated;
            r_FormGame.YesNoMessageBoxClicked += r_FormGame_YesNoMessageBoxClicked;
            r_FormGame.RecivedMovement += r_FormGame_RecivedMovment;
        }


        private void r_nglishCheckersLogic_SwitchedPlayers()
        {
            r_FormGame.SwitchPlayers();
        }
*/
        /* private void r_TicTacToeGameLogic_BoardUpdated(Board i_Board)
         {

             r_FormGame.updateBoard( i_Board);
         }
         /*
         private void gameStartedListener(Game i_Game)
         {
             r_FormGame.SetNewSession(i_Game.PlayerX.Score, i_Game.PlayerO.Score, i_Game.CurrentPlayer.Name);
         }

         private void r_FormGame_YesNoMessageBoxClicked(object sender, EventArgs e)
         {
             YesNoMessageBoxEventArgs yesNoMessageBoxEventArgs = e as YesNoMessageBoxEventArgs;

             if (yesNoMessageBoxEventArgs.IsPressedYesInMessageBox)
             {
                 r_EnglishCheckersLogic.InitializeSession();
             }
             else
             {
                 r_FormGame.Close();
             }
         }

         private void r_EnglishCheckersLogic_GameFinished(object sender)
         {
             Game gameLogic = sender as Game;

             r_FormGame.ContinuePlayingMessageBox(gameLogic);
         }

         private void r_FormGame_GameDetailsUpdated(object sender, EventArgs e)
         {
             EventGameDetailsArgs gameDetails = e as EventGameDetailsArgs;

             r_EnglishCheckersLogic.InitializeGame(gameDetails.PlayerXName, gameDetails.PlayerOName, gameDetails.BoardSize, gameDetails.PlayerOType);
         }

         private void r_FormGame_RecivedMovment(Movement i_NextMove)
         {
             bool validMove = r_EnglishCheckersLogic.MoveManager(i_NextMove);

             if (!validMove)
             {
                 MessageBox.Show("Invalid move entered, please try again", "Error");
             }
         }*/
    }
}
