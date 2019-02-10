using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace GeomFigure.Decorator.WorkWithFigures
{
    class RectangleDecorator : ShapeDecorator
    {
        private float m_height;
        private float m_width;

        public RectangleDecorator(RectangleShape component) : base(component)
        {
            this.m_width = component.Size.X;
            this.m_height = component.Size.Y;    
        }

        public override float GetArea()
        {
            return (this.m_width * this.m_height);
        }

        public override string GetDescription()
        {
            return "Rectangle:" + base.GetDescription();
        }

        public override float GetPerimeter()
        {
            return (this.m_width * 2 + this.m_height * 2);
        }
    }
}
