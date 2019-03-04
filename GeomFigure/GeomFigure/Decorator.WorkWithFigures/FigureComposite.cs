using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomFigure.Decorator.WorkWithFigures
{
    class FigureComposite:ShapeDecorator
    {
        private List<ShapeDecorator> m_geomFigures = new List<ShapeDecorator>();

        public FigureComposite()
        {
        }

        public void ToGroup()
        {
            if(m_geomFigures.Count != 0)
            {
                String identifier = Guid.NewGuid().ToString();
                for (int i = 0; i < m_geomFigures.Count; i++)
                {
                    m_geomFigures[i].GroupIdentifier.Push(identifier);
                }
            }
        }

        public void ToMoveFigures(RenderWindow win)
        {
            for (int i = 0; i < m_geomFigures.Count(); i++)
            {
                Vector2i subCoords = m_geomFigures[i].subCoords;
                Vector2f newCoords = new Vector2f();
                newCoords.X = Mouse.GetPosition(win).X - subCoords.X;
                newCoords.Y = Mouse.GetPosition(win).Y - subCoords.Y;
                m_geomFigures[i].SetCoords(newCoords);
            }
        }

        public void ToCalculateSubCoords(Vector2i mousePos)
        {
            for(int i = 0; i < m_geomFigures.Count; i++)
            {
                Vector2f coordsOfFigure = m_geomFigures[i].GetCoords();
                m_geomFigures[i].subCoords.X = mousePos.X - Convert.ToInt32(coordsOfFigure.X);
                m_geomFigures[i].subCoords.X = mousePos.Y - Convert.ToInt32(coordsOfFigure.Y);
            }
        }

        public void ToUngroup()
        {
            for (int i = 0; i < m_geomFigures.Count; i++)
            {
                if (m_geomFigures[i].GroupIdentifier.Peek() != "0")
                    m_geomFigures[i].GroupIdentifier.Pop();
            }
        }

        public void AddFigure(ShapeDecorator shape)
        {
            this.m_geomFigures.Add(shape);
        }

        public override float GetPerimeter()
        {
            float perimeter = 0;

            foreach (ShapeDecorator shape in this.m_geomFigures)
            {
                perimeter += shape.GetPerimeter();
            }

            return perimeter;
        }

        public override float GetArea()
        {
            float area = 0;

            foreach(ShapeDecorator shape in this.m_geomFigures)
            {
                area += shape.GetArea();
            }

            return area;
        }

        public void ToSelectFigures()
        {
            for(int i = 0; i < this.m_geomFigures.Count; i++)
            {
                m_geomFigures[i].SetOutlineThickness(3);
                m_geomFigures[i].SetOutLineColor(Color.Blue);
            }
        }

        public void RemoveSelectionFigures()
        {
            for (int i = 0; i < this.m_geomFigures.Count; i++)
            {
                m_geomFigures[i].SetOutlineThickness(0);
                m_geomFigures[i].SetOutLineColor(Color.White);
            }

            m_geomFigures.Clear();
        }

        public bool FigureOnComposite(ShapeDecorator shape)
        {
            for (int i = 0; i < m_geomFigures.Count; i++)
                if (m_geomFigures[i] == shape)
                    return true;

            return false;
        }
    }
}
