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

        public ShapeDecorator(Shape component)
        {
            this.m_component = component;
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

        public float GetDistanceBetweenPoints(Vector2f point1, Vector2f point2)
        {
            Vector2f resultPoint = point2 - point1;
            return (float)Math.Sqrt((resultPoint.X * resultPoint.X + resultPoint.Y * resultPoint.Y));
        }
    }
}
