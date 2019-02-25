using System.Windows;
using System.Windows.Shapes;
using GraphicsEditor.Models;

namespace GraphicsEditor
{
    public interface IDrawingModel
    {
        void SetModel( dynamic model );

        void Create( Point point, PainterParams painterParams );

        void Drawing( Point point, PainterParams painterParams );

        void Move();
    }
}
