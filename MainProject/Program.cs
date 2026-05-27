using System;
using System.Linq;
using Spectre.Console;
using Spectre.Console.Rendering;


namespace MainProject
{
    public class Program
    {
        private static void Main(string[] args)
        {


            //    [i,j]
            string PlayerInput;

            //bool[,] grid = new bool[3, 3] { { true, true, true }, { true, true, true }, {true,true,true} };
            //Console.WriteLine(grid);
            int[,] grid = new int[3, 3] { { 00, 01, 02 }, { 10, 11, 12 }, {20, 21, 22} };
            Console.WriteLine(grid);

            PlayerInput = Console.ReadLine();
            //AQUI SAIRIAM DOIS NUMEROS
            char row = PlayerInput[0];
            char column = PlayerInput[1];

            //int[,] firstArray = new int[row,column];
            ///


            for (int i = PlayerInput[0]; i>0; i++)
            {
                
            }
            //int divide = int.Parse(PlayerInput);
            //char i = PlayerInput[0];
            if (row > 0)
            {
                ++row;
                Console.WriteLine($"{row}{column}");
                //row++;
                //Console.WriteLine($"{row}{column}");
            }
            
            if (row < 3)
            {
                Console.WriteLine($"{row}{column}");
            }
                /*row++;
                Console.WriteLine($"{row}{column}");
                row--;
            }
            if (column > 0)
            {
                column++;
                Console.WriteLine($"{row}{column}");
                //column--;
            }
            if (column < 2)
            {
                column++;
                Console.WriteLine($"{row}{column}");
                column--;
            }
            /*
            foreach( char x in PlayerInput)
            {
                string[] temporaryChange = new string["i","j"]; 
                if (i >=0 ^ i<2);
                {
                    int divide = int.Parse(PlayerInput);
                    ++divide;
                    //change to bool and then
                    //divide = !divide;
                    grid
                }

            }*/

            


            /*//Console.WriteLine("Hello LP!");
            Grid tableLevel1 = new Grid();
            tableLevel1.AddColumns(3);
            //tableLevel1.AddColumn();
            //tableLevel1.AddColumn();
            //tableLevel1.AddColumn();
            //tableLevel1.AddRow("[red]A1[/]","[red]B1[/]","[red]C1[/]");
            //tableLevel1.AddRow("[red]A2[/]","[red]B2[/]","[red]C2[/]");
            //tableLevel1.AddRow("[red]A3[/]","[red]B3[/]","[red]C3[/]");

            string[] arrayRow1 = new string[3];
            string[] arrayRow2 = new string[3];
            string[] arrayRow3 = new string[3];
            tableLevel1.AddRow(arrayRow1);
            tableLevel1.AddRow(arrayRow2);
            tableLevel1.AddRow(arrayRow3);
            //tableLevel1.Expand();
            //tableLevel1.AddEmptyRow();

            AnsiConsole.Write(tableLevel1);*/
        }
    }
}
