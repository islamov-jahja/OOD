using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeomFigure.Decorator.WorkWithFigures;
using SFML.Graphics;
using SFML.System;

namespace GeomFigureTest
{
    [TestClass]
    public class CircleDecoratorTests
    {
        [TestMethod]
        public void CheckPerimeterOfCircle()
        {
            CircleShape circle = new CircleShape(50);
            circle.Position = new Vector2f(500, 100);
            ShapeDecorator circleDecorator = new CircleDecorator(circle);

            float expected = 314f;
            float actual = circleDecorator.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckAreaOfCircle()
        {
            CircleShape circle = new CircleShape(50);
            circle.Position = new Vector2f(500, 100);
            ShapeDecorator circleDecorator = new CircleDecorator(circle);

            string expected = "7850";
            string actual = "";
            actual = actual + circleDecorator.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckDescriptionOfCircle()
        {
            CircleShape circle = new CircleShape(50);
            circle.Position = new Vector2f(500, 100);
            ShapeDecorator circleDecorator = new CircleDecorator(circle);

            string expected = "CIRCLE: P=314; S=7850";
            string actual = circleDecorator.GetDescription();
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class TriangleDecoratorTests
    {
        [TestMethod]
        public void CheckPerimeterOfTriangle()
        {
            ConvexShape triangle = new ConvexShape();
            triangle.SetPointCount(3);
            triangle.SetPoint(0, new Vector2f(40, 60));
            triangle.SetPoint(1, new Vector2f(100, 100));
            triangle.SetPoint(2, new Vector2f(200, 350));

            ShapeDecorator circleDecorator = new TriangleDecorator(triangle);

            string expected = "672,5792";
            string actual = "";
            actual = actual + circleDecorator.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckAreaOfTriangle()
        {
            ConvexShape triangle = new ConvexShape();
            triangle.SetPointCount(3);
            triangle.SetPoint(0, new Vector2f(40, 60));
            triangle.SetPoint(1, new Vector2f(100, 100));
            triangle.SetPoint(2, new Vector2f(200, 350));

            ShapeDecorator circleDecorator = new TriangleDecorator(triangle);

            string expected = "5500";
            string actual = "";
            actual = actual + circleDecorator.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckDescriptionOfTriangle()
        {
            ConvexShape triangle = new ConvexShape();
            triangle.SetPointCount(3);
            triangle.SetPoint(0, new Vector2f(40, 60));
            triangle.SetPoint(1, new Vector2f(100, 100));
            triangle.SetPoint(2, new Vector2f(200, 350));

            ShapeDecorator circleDecorator = new TriangleDecorator(triangle);

            string expected = "Triangle: P=672,58; S=5500";
            string actual = circleDecorator.GetDescription();
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class RectangleDecoratorTests
    {
        [TestMethod]
        public void CheckPerimeterOfCircle()
        {
            Vector2f point1 = new Vector2f(200, 200);
            Vector2f point2 = new Vector2f(300, 300);
            RectangleShape rectangleShape = new RectangleShape();
            rectangleShape.Position = point1;
            float width = point2.X - point1.X;
            float height = point2.Y - point1.Y;
            rectangleShape.Size = new Vector2f(width, height);

            ShapeDecorator rectangleDecorator = new RectangleDecorator(rectangleShape);

            float expected = 400f;
            float actual = rectangleDecorator.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckAreaOfRectangle()
        {
            Vector2f point1 = new Vector2f(200, 200);
            Vector2f point2 = new Vector2f(300, 300);
            RectangleShape rectangleShape = new RectangleShape();
            rectangleShape.Position = point1;
            float width = point2.X - point1.X;
            float height = point2.Y - point1.Y;
            rectangleShape.Size = new Vector2f(width, height);

            ShapeDecorator rectangleDecorator = new RectangleDecorator(rectangleShape);

            string expected = "10000";
            string actual = "";
            actual = actual + rectangleDecorator.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckDescriptionOfCircle()
        {
            Vector2f point1 = new Vector2f(200, 200);
            Vector2f point2 = new Vector2f(300, 300);
            RectangleShape rectangleShape = new RectangleShape();
            rectangleShape.Position = point1;
            float width = point2.X - point1.X;
            float height = point2.Y - point1.Y;
            rectangleShape.Size = new Vector2f(width, height);

            ShapeDecorator rectangleDecorator = new RectangleDecorator(rectangleShape);

            string expected = "Rectangle: P=400; S=10000";
            string actual = rectangleDecorator.GetDescription();
            Assert.AreEqual(expected, actual);
        }
    }
}
