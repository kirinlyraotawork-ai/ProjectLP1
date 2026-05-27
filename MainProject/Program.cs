using System;
using System.Linq;
using Spectre.Console;
using Spectre.Console.Rendering;


namespace MainProject
{
    public class Program
    {

        private static void Main()
        {
            IView view = new ConsoleView();
            Controller con = new(view);

            con.Run();

        }
    }
}
