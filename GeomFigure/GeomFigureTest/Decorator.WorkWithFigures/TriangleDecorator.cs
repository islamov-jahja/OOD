using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace GeomFigure.Decorator.WorkWithFigures
{
    class TriangleDecorator : ShapeDecorator
    {
        float m_side1;
        float m_side2;
        float m_side3;

        public TriangleDecorator(Shape component) : base(component)
        {
            m_side1 = base.GetDistanceBetweenPoints(component.GetPoint(0), component.GetPoint(1));
            m_side2 = base.GetDistanceBetweenPoints(component.GetPoint(0), component.GetPoint(2));
            m_side3 = base.GetDistanceBetweenPoints(component.GetPoint(1), component.GetPoint(2));
        }

        public override float GetArea()
        {
            float semiPerimeter = this.GetPerimeter() / 2;
            return (float)Math.Sqrt(semiPerimeter * (semiPerimeter - this.m_side1) *
            (semiPerimeter - this.m_side2) * (semiPerimeter - this.m_side3));
        }

        public override float GetPerimeter()
        {
            return this.m_side1 + this.m_side2 + this.m_side3;
        }

        public override string GetDescription()
        {
            return "Triangle:" + base.GetDescription();
        }
    }
}
