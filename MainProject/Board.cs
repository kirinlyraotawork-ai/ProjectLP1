using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject
{
    /// <summary>
    /// Represents the Blackout game board.
    /// </summary>
    public class Board
    {

        // -----private variables and properties-----

        /// <summary>2D array of cells that form the grid.</summary>
        private Cell[,] grid;
        /// <summary>Random number generator used during board initialization.</summary>
        private Random random;
        /// <summary>Number of clicks applied when setting up the board.</summary>
        private int setupClicks;

        /// <summary>Size length of the square grid.</summary>
        public int Size { get; }
        /// <summary>Total number of moves the player has made.</summary>
        public int Moves { get; private set; }
        /// <summary>Returns true when every cell is off which is the winning condition.</summary>
        public bool IsWon
        {
            get
            {
                //goes through every row
                for (int Row = 0; Row < Size; Row++)
                    //in every row, goes through every column
                    for (int Col = 0; Col < Size; Col++)
                        //if current row's current column is turned on, returns false
                        //(thus stopping the rest of the method)
                        if (grid[Row, Col].IsOn)
                        {
                            return false;
                        }
                return true;
            }
        }
        // -----methods and construct-----

        /// <summary>
        /// Creates and initialises a new board for the given difficulty.
        /// </summary>
        /// <param name="difficulty">The chosen difficulty level.</param>
        public Board(Difficulty difficulty)
        {
            //size becomes 3 (easy), 5(medium) or 8(hard) 
            //"(int)" is being used because difficulty is an enum,
            // needs to be cast into an int
            Size = (int)difficulty;
            //starts a random number for method Initialize
            random = new Random();
            //Moves start at 0,
            //increases with each move made by the player
            Moves = 0;

            // Number of setup clicks per difficulty
            setupClicks = difficulty switch
            {
                Difficulty.Easy => 5,
                Difficulty.Medium => 10,
                Difficulty.Hard => 20,
                //default case(helps prevent exceptions)
                _ => 10
            };
            //2D cell gets created with same variable,
            //since size of the grid is always 3x3 , 5x5 or 8x8
            grid = new Cell[Size, Size];
            //calls method Initialize
            Initialize();
        }

        /// <summary>
        /// Returns the on/off state of the cell at (row, col).
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <param name="col">Column index.</param>
        /// <returns>True if the cell is on.</returns>
        public bool GetCellState(int row, int col)
        {
            return grid[row, col].IsOn;
        }

        /// <summary>
        /// Applies a player click at (row, col): toggles that cell and its
        /// neighbors, then increments the move counter.
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <param name="col">Column index.</param>
        public void PlayerClick(int row, int col)
        {
            //current cell
            ToggleCell(row, col);
            //cell above
            ToggleCell(row - 1, col);
            //cell above left
            ToggleCell(row - 1, col-1);
            //cell below
            ToggleCell(row + 1, col);
            //cell below left
            ToggleCell(row + 1, col -1);
            //cell to the left
            ToggleCell(row, col - 1);
            //cell to the right
            ToggleCell(row, col + 1);
            //cell above right
            ToggleCell(row -1, col + 1);
            //cell below left
            ToggleCell(row + 1, col +1);
            
            Moves++;
        }

        /// <summary>
        /// Toggles a cell only if the coordinates are within bounds.
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <param name="col">Column index.</param>
        private void ToggleCell(int row, int col)
        {
            if (row >= 0 && row < Size && col >= 0 && col < Size)
                grid[row, col].Toggle();
        }

        /// <summary>
        /// Sets all cells to off, then applies the required number of random clicks
        /// to create a starting configuration.
        /// </summary>
        private void Initialize()
        {
            //start with all the cells turned off
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    grid[row, col] = new Cell(false);
                }
            }

            //next is to apply the random clicks to the board
            for (int i = 0; i < setupClicks; i++)
            {
                int rRow = random.Next(Size);
                int rCol = random.Next(Size);

                PlayerClick(rRow, rCol);
            }
            //PlayerClick adds to the move counter, needs to be reset
            Moves = 0;
            //if the board happens to be solved, re-do the process
            if (IsWon) Initialize();
        }
    }
}