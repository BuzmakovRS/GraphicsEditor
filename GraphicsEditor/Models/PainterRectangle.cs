using System;
using System.Windows;
using System.Windows.Shapes;

namespace GraphicsEditor.Models
{
    public class PainterRectangle //: IDrawingModel
    {
        public Rectangle rectangle;

        public void SetModel( dynamic model )
        {
            rectangle = (Rectangle)model;
        }

        public void Create( Point point, PainterParams painterParams )
        {
            throw new NotImplementedException();
        }

        public void Drawing( Point point, PainterParams painterParams )
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }


    }
}
