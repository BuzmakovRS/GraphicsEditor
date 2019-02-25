using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphicsEditor.Models;

namespace GraphicsEditor
{
    public class Painter
    {
        Canvas drawCanvas;
        Boolean IsDrawing { get; set; }
        Stack<Shape> shapes { get; set; }
        Stack<List<Shape>> delShapes { get; set; }
        SolidColorBrush brush { get; set; }
        List<Line> tempLineList { get; set; }
        Type ShapeType { get; set; } = typeof( Polyline );

        Point   lineStartPoint;
        Point   lineEndPoint;

        PainterParams painterParams;
        dynamic   selectedItem;

        Dictionary<string, string> dictPaintModel;

        public Painter( Canvas _canvas )
        {
            drawCanvas = _canvas;
            IsDrawing = false;
            painterParams = new PainterParams()
            {
                borderColor = new SolidColorBrush( Colors.Blue ),
                fillColor = new SolidColorBrush( Colors.Red ),
                StrokeThikness = 2
            };

            shapes = new Stack<Shape>();
            delShapes = new Stack<List<Shape>>();

            String s =  typeof( Polyline ).FullName;

            dictPaintModel = new Dictionary<string, string>{
                {   typeof( Polyline ).FullName, typeof( PainterPolyline ).FullName },
                {   typeof( Rectangle ).FullName, typeof( PainterRectangle ).FullName }
            };
            //PainterPolyline = new PainterPolyline();

        }

        public void StartDrawing( Type _type, Point point )
        {
            IsDrawing = true;
            ShapeType = _type;
            if ( selectedItem == null )
            {
                selectedItem = Activator.CreateInstance( ShapeType );
                drawCanvas.Children.Add( selectedItem );
            }

            Drawing( point );
        }

        public void StopDrawing( Point point )
        {
            if ( IsDrawing )
            {
                Drawing( point, true );
            }
            selectedItem = null;
            IsDrawing = false;
        }

        public void Drawing( Point point, Boolean lastPoint = false )
        {
            if ( IsDrawing )
            {

                try
                {


                    if ( dictPaintModel.TryGetValue( ShapeType.FullName, out string painterTypeStr ) )
                    {
                        var painterType = Type.GetType( painterTypeStr );
                        IDrawingModel painterModel = (IDrawingModel)Activator.CreateInstance( painterType );
                      
                        painterModel.SetModel( selectedItem );
                        painterModel.Drawing( point, painterParams );
                    }

                }
                catch ( Exception e )
                {
                    MessageBox.Show( e.Message, "Ошибка" );
                }

                //lineEndPoint = point;
                //if ( selectedItem == null )
                //{
                //    selectedItem = Activator.CreateInstance( shapeType );


                //    drawCanvas.Children.Add( selectedItem );
                //    selectedItem.X1 = point.X;
                //    selectedItem.Y1 = point.Y;

                //}

                //selectedItem.X2 = lineEndPoint.X;
                //selectedItem.Y2 = lineEndPoint.Y;
                //selectedItem.Stroke = brush;
                //selectedItem.StrokeThickness = 2;

            }
        }

        public void Reset()
        {
            if ( shapes.Count > 0 )
            {
                Shape item = shapes.Pop();
                delShapes.Push( new List<Shape>( (IEnumerable<Shape>)item ) );
            }

        }

        public void Clear()
        {
            delShapes.Push( new List<Shape>( shapes ) );
            shapes.Clear();
            drawCanvas.Children.Clear();
        }

    }
}
