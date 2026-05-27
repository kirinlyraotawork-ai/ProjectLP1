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
                Difficulty difficulty = view.ShowMainMenu();
                board = new(difficulty);

                PlayGame();

                view.ShowVictory(board.Moves);
                playAgain = view.AskToPlayAgain();

            }

        }

        /// <summary>The game loop in a do while </summary>
        private void PlayGame()
        {
            do
            {
                view.DrawBoard(board);
                (int row, int col) = view.GetPlayerMove(board.Size);

                if(row == -1 && col == -1)
                {
                    Difficulty dif = view.ShowMainMenu();
                    board = new Board(dif);
                    continue;
                }
                board.PlayerClick(row, col);
            } while (!board.IsWon);
        }
    }
}