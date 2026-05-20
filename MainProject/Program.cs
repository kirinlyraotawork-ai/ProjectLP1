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
            //Console.WriteLine("Hello LP!");
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

            AnsiConsole.Write(tableLevel1);
        }
    }
}
