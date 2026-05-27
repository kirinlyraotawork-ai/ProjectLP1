using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace MainProject
{
    /// <summary>
    /// Console-based view implemented with Spectre.Console.
    /// </summary>
    public class ConsoleView : IView
    {
        // -----private variables and properties-----
        private const string CellOnColour = "springgreen3";
        private const string CellOffColour = "DarkRed";


        // -----methods-----
        public bool AskToPlayAgain()
        {
            //Confirm gives a yes or no input for the player to answer
            //with either y/n, returning a true or false respectively
            return AnsiConsole.Confirm($"Play again?");
        }
        public void DrawBoard(Board board)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"Moves: {board.Moves}\n");

            string header = "     ";
            for (int col = 0; col < board.Size; col++)
            {
                header += $"{col + 1}  ";
            }
            AnsiConsole.WriteLine(header);
            AnsiConsole.WriteLine("   " + new string('-', board.Size * 4 + 1));

            for (int row = 0; row < board.Size; row++)
            {
                string line = $"{row + 1}  │ ";
                for (int col = 0; col < board.Size; col++)
                {
                    bool cellOn = board.GetCellState(row, col);
                    string color;

                    if (cellOn)
                        color = CellOnColour;
                    else
                        color = CellOffColour;

                    line += $"[{color}]██[/] ";
                }
                AnsiConsole.MarkupLine(line);
            }
            AnsiConsole.MarkupLine("\n[grey][[bright green]] = ON   [[dark red]] = OFF  Quit by writing 'Quit'[/]");
        }

        public (int row, int col) GetPlayerMove(int size)
        {
            AnsiConsole.WriteLine($"Enter a cell to toggle (row column, e.g. 2 3):");

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null)
                {
                    //gets rid of white spaces before and after the 2 numbers
                    input = input.Trim();
                }
                else
                {
                    input = "";
                }

                if(input == "Quit")
                {
                    //use this in PlayGame() to reset the board and go back to main menu
                    return (-1, -1);
                }

                string[] parts = input.Split(' ');

                //if array has 2 values + if value 1 and value 2 are inside the boundaries
                if (parts.Length == 2
                && int.TryParse(parts[0], out int row) && row >= 1 && row <= size
                && int.TryParse(parts[1], out int col) && col >= 1 && col <= size)
                {
                    row--;
                    col--;
                    return (row, col);
                }

                //if no input or wrong input, print this
                AnsiConsole.MarkupLine($"[red]Invalid input.[/] Enter two numbers between 1 and {size}, separated by a space.");
            }
        }

        public Difficulty ShowMainMenu()
        {
            //clears the screen from previous stuff
            AnsiConsole.Clear();
            //creates the title logo
            AnsiConsole.Write(
            new FigletText("BLACKOUT")
                .Centered()
                .Color(Color.Purple4));

            // Menu choice to play or quit the program
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[blue]Main Menu[/]")
                    .AddChoices("Play", "How To Play", "Quit"));

            if (choice == "Quit")
            {
                //Leaves the program fully, returns 0 to work
                Environment.Exit(0);
            }

            if (choice == "How To Play")
            {

                ShowRules();
                //needs ShowMainMenu needs to return a Difficulty value,
                //so we just return itself again.
                return ShowMainMenu();
            }

            //if player chooses play, new screen with 3 difficulties to choose from
            var difficulty = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"\n[blue]Choose difficulty:[/]")
                    .AddChoices("Easy (3×3)", "Medium (5×5)", "Hard (8×8)"));

            //returns an enum related to the Enum class "Difficulty"
            //depending on the player's choice, chooses the difficulty
            return difficulty switch
            {
                "Easy (3×3)" => Difficulty.Easy,
                "Medium (5×5)" => Difficulty.Medium,
                //if its not easy or medium, default is hard, the _ is the default case.
                // Which in this case is only when hard is chosen
                _ => Difficulty.Hard,
            };
        }

        public void ShowVictory(int moves)
        {
            //clears the screen from previous stuff
            AnsiConsole.Clear();
            //draws the win screen, the same way as the title logo
            AnsiConsole.Write(
                new FigletText("YOU WIN!")
                    .Centered()
                    .Color(Color.Cyan2));

            //bold springgreen1 is a color for ansiconsole. 
            //"[/]" stops that color from being used on the rest of the text
            AnsiConsole.MarkupLine($"\n[bold springgreen1]Congrats![/] You solved the board in {moves}.\n");
        }
        public void ShowRules()
        {
            AnsiConsole.Clear();
            //creates a panel for the rules to be displayed
            // @"" is called verbatim text, useful for new lines without /n breaks
            var panel = new Panel(
             @"[bold underline]How to Play BLACKOUT[/]

            - The grid starts with some cells [springgreen3]ON[/].
            - Select a cell by entering its [underline]row[/] and [underline]column[/] respectively.
            - Said cell [underline]and its neighbors[/] will toggle [springgreen3]ON[/] or [DarkRed]OFF[/] depending on their current state.
            - The goal is to turn all cells [DarkRed]OFF[/].
            - Quit to the main menu at any time by writing 'Quit'
            - The fewer moves to complete the board, the better!!!"
            )
            {
                Border = BoxBorder.Rounded,
                Padding = new Padding(2, 1)
            };

            //actually draws the panel on screen
            AnsiConsole.Write(panel);
            AnsiConsole.WriteLine($"\n Press ENTER to return...");
            Console.ReadLine();

        }
    }
}