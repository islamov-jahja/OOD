using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using GeomFigure.Decorator.WorkWithFigures;
using GeomFigure.CommandController;

namespace GeomFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Figure editor");
            Controller controller = new Controller("input.txt", "output.txt");
            controller.Print();
            

            while (win.IsOpen)
            {
                win.DispatchEvents();
                win.Clear(Color.Black);
                controller.DrawFigures(win);
                win.Display();

            }

        }
    }
}
