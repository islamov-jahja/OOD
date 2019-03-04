using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomFigure.Decorator.WorkWithFigures
{
    abstract class ShapeDecorator : Shape
    {
        protected Shape m_component;
        protected float m_perimeter;
        protected float m_area;

        public Vector2i subCoords;
        public Stack<String> GroupIdentifier = new Stack<String>();
        public ShapeDecorator() { }

        public ShapeDecorator(Shape component)
        {
            this.m_component = component;
            GroupIdentifier.Push("0");
        }

        public void SetCoords(Vector2f coords)
        {
            m_component.Position = coords;
        }

        public Vector2f GetCoords()
        {
            return m_component.Position;
        }

        public virtual float GetPerimeter()
        {
            if (m_component != null)
            {
                this.m_perimeter = this.GetPerimeter();
            }

            return this.m_perimeter;
        }

        public virtual float GetArea()
        {
            if (m_component != null)
            {
                this.m_area = this.GetArea();
            }

            return this.m_area;
        }

        public void DrawFigure(RenderWindow window)
        {
            if (m_component != null)
                window.Draw(m_component);
        }

        public virtual string GetDescription()
        {
            return " P=" + (float)Math.Round(this.GetPerimeter(), 2) + "; S=" + (float)Math.Round(this.GetArea(), 2);
        }

        public override Vector2f GetPoint(uint index)
        {
            if (this.m_component != null)
            {
                return this.m_component.GetPoint(index);
            }
            else
            {
                return new Vector2f();
            }
        }

        public override uint GetPointCount()
        {
            if (this.m_component != null)
            {
                return this.m_component.GetPointCount();
            }
            else
            {
                return 0;
            }
        }

        protected float GetDistanceBetweenPoints(Vector2f point1, Vector2f point2)
        {
            Vector2f resultPoint = point2 - point1;
            return (float)Math.Sqrt((resultPoint.X * resultPoint.X + resultPoint.Y * resultPoint.Y));
        }

        public void SetFillColor(Color color)
        {
            m_component.FillColor = color;
        }

        public void SetOutLineColor(Color color)
        {
            m_component.OutlineColor = color;
        }

        public void SetOutlineThickness(float thickness)
        {
            m_component.OutlineThickness = thickness;
        }

        public bool MouseOnFigure(Vector2i coord)
        {
            return m_component.GetGlobalBounds().Contains(coord.X, coord.Y);
        }
    }
}
