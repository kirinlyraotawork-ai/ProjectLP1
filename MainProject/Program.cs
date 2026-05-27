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
        }
    }
}
