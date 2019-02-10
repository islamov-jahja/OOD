using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeomFigure.Decorator.WorkWithFigures;
using System.IO;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace GeomFigure.CommandController
{
    class Controller
    {
        private List<ShapeDecorator> m_geomFigures = new List<ShapeDecorator>();
        string m_readingFilePath;
        string m_writingFilePath { get; set; }


        public Controller()
        {
        }

        public Controller(string readingFilePath, string writingFilePath)
        {
            this.m_readingFilePath = readingFilePath;
            this.m_writingFilePath = writingFilePath;
            this.m_geomFigures = InitGeomFiguresList();
        }

        public void DrawFigures(RenderWindow window)
        {
            foreach (ShapeDecorator shape in this.m_geomFigures)
            {
                shape.FillColor = Color.White;
                shape.DrawFigure(window);
            }
        }

        public void setReadingFilePath(string filePath)
        {
            this.m_readingFilePath = filePath;
            this.m_geomFigures.Clear();
            this.m_geomFigures = InitGeomFiguresList();
        }

        public void Print()
        {
            if (this.m_writingFilePath != "")
            {
                StreamWriter fileOut = new StreamWriter(this.m_writingFilePath, false);
                foreach (ShapeDecorator shape in this.m_geomFigures)
                    fileOut.WriteLine(shape.GetDescription());
                fileOut.Close();
            }
        }

        private List<ShapeDecorator> InitGeomFiguresList()
        {
            List<ShapeDecorator> listWithFigures = new List<ShapeDecorator>();
            if (File.Exists(this.m_readingFilePath))
            {
                this.AddFiguresToList(listWithFigures);
            }

            return listWithFigures;
        }

        private void AddFiguresToList(List<ShapeDecorator> listWithFigures)
        {
            StreamReader fileRead = new StreamReader(this.m_readingFilePath);
            string command;
            while ((command = fileRead.ReadLine()) != null)
            {
                if (command.Contains("TRIANGLE"))
                {
                    listWithFigures.Add(GetTrinagleFigure(command));
                }
                else if (command.Contains("RECTANGLE"))
                {
                    listWithFigures.Add(GetRectangleFigure(command));
                }
                else if (command.Contains("CIRCLE"))
                {
                    listWithFigures.Add(GetCircleFigure(command));
                }
            }
        }

        private ShapeDecorator GetCircleFigure(string command)
        {
            int startIndex = command.IndexOf("C=");
            int endIndex = command.IndexOf(";") - 2;
            string coordinates = command.Substring(startIndex + 2, (endIndex - startIndex));
            string[] array = coordinates.Split(',');
            float coord1 = (float)Convert.ToDouble(array[0]);
            float coord2 = (float)Convert.ToDouble(array[1]);
            startIndex = command.IndexOf("R=");
            coordinates = command.Substring(startIndex + 2);
            float radius = (float)Convert.ToDouble(coordinates);
            return GetCircle(new Vector2f(coord1, coord2), radius);
        }

        private ShapeDecorator GetTrinagleFigure(string command)
        {
            int startIndex = command.IndexOf("P1=");
            Vector2f point1 = GetCoodinatesFromString(startIndex, command);

            startIndex = command.IndexOf("P2=");
            Vector2f point2 = GetCoodinatesFromString(startIndex, command);

            startIndex = command.IndexOf("P3=");
            Vector2f point3 = GetCoodinatesFromString(startIndex, command);
            return GetTriangle(point1, point2, point3);
        }

        private ShapeDecorator GetRectangleFigure(string command)
        {

            int startIndex = command.IndexOf("P1=");
            Vector2f point1 = GetCoodinatesFromString(startIndex, command);

            startIndex = command.IndexOf("P2=");
            Vector2f point2 = GetCoodinatesFromString(startIndex, command);

            return GetRectangle(point1, point2);
        }

        private Vector2f GetCoodinatesFromString(int startIndex, string command)
        {
            int endIndex = command.IndexOf(";", startIndex) - 3;
            string coordinates = command.Substring(startIndex + 3, endIndex - startIndex);

            string[] array = coordinates.Split(',');
            float coord1 = (float)Convert.ToDouble(array[0]);
            float coord2 = (float)Convert.ToDouble(array[1]);
            return new Vector2f(coord1, coord2);
        }

        private ShapeDecorator GetCircle(Vector2f position, float radius)
        {
            CircleShape circleShape = new CircleShape(radius);
            circleShape.Position = position;

            return new CircleDecorator(circleShape);
        }

        private ShapeDecorator GetTriangle(Vector2f point1, Vector2f point2, Vector2f point3)
        {
            ConvexShape triangle = new ConvexShape();
            triangle.SetPointCount(3);
            triangle.SetPoint(0, point1);
            triangle.SetPoint(1, point2);
            triangle.SetPoint(2, point3);

            return new TriangleDecorator(triangle);
        }

        private ShapeDecorator GetRectangle(Vector2f point1, Vector2f point2)
        {
            RectangleShape rectangleShape = new RectangleShape();
            rectangleShape.Position = point1;
            float width = point2.X - point1.X;
            float height = point2.Y - point1.Y;
            rectangleShape.Size = new Vector2f(width, height);

            return new RectangleDecorator(rectangleShape);
        }
    }
}
