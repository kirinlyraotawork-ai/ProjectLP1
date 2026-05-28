using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject
{
    public interface IView
    {
        /// <summary>Shows the welcome screen and returns the chosen difficulty.</summary>
        //Difficulty ShowMainMenu();

        /// <summary>Draws the current board state.</summary>
        /// <param name="board">The board to display.</param>
        void DrawBoard(Board board, int bestScore);

        /// <summary>
        /// Asks the player to pick a row and column to click.
        /// </summary>
        /// <param name="size">Grid size, used to validate input.</param>
        (int row, int col) GetPlayerMove(int size);

        /// <summary>Displays the victory screen.</summary>
        /// <param name="moves">Number of moves the player used.</param>
        //void ShowVictory(int moves);

        /// <summary>Asks the player if they want to play again.</summary>
        /// <returns>True if the player wants another game.</returns>
        bool AskToPlayAgain();

        /// <summary>Shows the rules of the game.</summary>
        void ShowRules();
/// <summary>Shows the welcome screen and returns the chosen difficulty.</summary>
/// <param name="highScores">Current high scores to display if requested.</param>
        Difficulty ShowMainMenu(Dictionary<Difficulty, int> highScores);
        //void ShowVictory(int moves, bool isNewBest);
        void ShowVictory(int moves, bool isNewBest, int bestScore);
    }
}