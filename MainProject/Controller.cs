using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject
{
    /// <summary>
    /// Controls the flow of the game. Owns the game loop, coordinates the model
    /// and the view, and reacts to player input.
    /// </summary>
    public class Controller
    {
        // -----private variables and properties-----

        /// <summary> the game board </summary>
        private Board board;

        /// <summary> the view used for UI and Input </summary>
        private IView view;


        // -----methods and construct-----

        /// <summary> Initialises the controller with the given view. </summary>
        /// <param name="view">The IView that will be used.</param>
        public Controller(IView view)
        {
            this.view = view;
        }

        /// <summary> Shows the menu, runs the game loop </summary>
        public void Run()
        {

            bool playAgain = true;
            while (playAgain)
            {
                //get the difficulty from ShowMainMenu
                //puts said difficulty in a new board
                Difficulty difficulty = view.ShowMainMenu();
                board = new(difficulty);

                PlayGame();

                //when the player wins, leaves PlayGame and comes back here,
                //show the Victory screen using the player's moves,
                //then asks the player to play again or not
                view.ShowVictory(board.Moves);
                playAgain = view.AskToPlayAgain();

            }

        }

        /// <summary>The game loop in a do while </summary>
        private void PlayGame()
        {
            //as long as the player hasn't won the game, this do while continues
            do
            {

                view.DrawBoard(board);
                //tuple that gets the player's input
                (int row, int col) = view.GetPlayerMove(board.Size);
                //when player writes "Quit", this if restarts the main menu
                //and lets the player choose a different difficulty
                if (row == -1 && col == -1)
                {
                    Difficulty dif = view.ShowMainMenu();
                    board = new(dif);
                    continue;
                }
                //uses the tuple above to click on the board
                board.PlayerClick(row, col);
            } while (!board.IsWon);
        }
    }
}