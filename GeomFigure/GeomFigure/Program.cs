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
                Vector2i pos = Mouse.GetPosition(win);
                win.DispatchEvents();
                EventArgs e = new EventArgs();

                if (Mouse.IsButtonPressed(Mouse.Button.Left) && !Keyboard.IsKeyPressed(Keyboard.Key.LShift))
                {
                    Vector2i mousePos = Mouse.GetPosition(win);
                    ShapeDecorator shape = controller.IsFigure(mousePos);
                    controller.ToCalculateSubCoords(mousePos);

                    if (shape != null)
                    {
                        if (controller.FigureOnGroup(shape))
                        {
                            while(Mouse.IsButtonPressed(Mouse.Button.Left))
                            {
                                controller.ToMoveFigures(win);
                                win.Clear(Color.Black);
                                controller.DrawFigures(win);
                                win.Display();
                            }
                        }
                        else
                        {
                            controller.CleanSelection();
                            controller.SelectFigure(shape);
                        }
                    }
                    else
                        controller.CleanSelection();
                }

                if (Mouse.IsButtonPressed(Mouse.Button.Left) && Keyboard.IsKeyPressed(Keyboard.Key.LShift))
                {
                    Vector2i mousePos = Mouse.GetPosition(win);
                    ShapeDecorator shape = controller.IsFigure(mousePos);

                    if (shape != null)
                    {
                        controller.SelectFigure(shape);
                    }
                    else
                        controller.CleanSelection();
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.LControl) && Keyboard.IsKeyPressed(Keyboard.Key.G))
                {
                    controller.ToUnionToGroup();
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.LControl) && Keyboard.IsKeyPressed(Keyboard.Key.U))
                {
                    controller.ToUnGroup();
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.P))
                    Console.WriteLine(controller.GetPerimeterOfFigures());

                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    Console.WriteLine(controller.GetAreaOfFigures());

                    win.Clear(Color.Black);
                controller.DrawFigures(win);
                win.Display();
            }

        }
    }
}
