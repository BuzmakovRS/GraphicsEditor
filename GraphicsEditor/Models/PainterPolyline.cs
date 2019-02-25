using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsEditor.Models
{
    class PainterPolyline : IDrawingModel
    {
        public Polyline polyline;


        public void SetModel( dynamic model )
        {
            polyline = (Polyline)model;

        }
        public void Create( Point point, PainterParams painterParams )
        {
            throw new NotImplementedException();
        }

        public void Drawing( Point point, PainterParams painterParams )
        {
            PointCollection currPoints = polyline.Points;
            PointCollection newPointCollection = new PointCollection();
            Point firstPoint = currPoints.Count > 0 ? currPoints[0] : point;

            newPointCollection.Add( firstPoint );
            Random rand = new Random();
            for ( int i = 1; i < 3; i++ )
            {
                    newPointCollection.Add( new Point( i / 4 * ( point.X - firstPoint.X ) + firstPoint.X, i / 4 * ( point.Y - firstPoint.Y ) + firstPoint.Y + rand.Next( 0, 30 ) ) );
                //if ( i == 2 )
                //else
                //    newPointCollection.Add( new Point( i / 4 * ( point.X - firstPoint.X ) + firstPoint.X, i / 4 * ( point.Y - firstPoint.Y ) + firstPoint.Y ) );
            }
            newPointCollection.Add( point );
            polyline.Points = newPointCollection;
            polyline.Stroke = painterParams.borderColor;
            polyline.Fill = painterParams.fillColor;
            polyline.StrokeThickness = painterParams.StrokeThikness;
            polyline.FillRule = FillRule.EvenOdd;

            //Geometry geom = polyline.RenderedGeometry; 

            //StreamGeometry streamGeometry = new StreamGeometry();

            //using ( StreamGeometryContext geometryContext = streamGeometry.Open() )
            //{
            //    geometryContext.BeginFigure( new Point( 1, 50 ), true, true );
            //    PointCollection points = newPointCollection;
            //    geometryContext.PolyLineTo( points, true, true );
            //}

            //DrawingVisual visual = new DrawingVisual();

            //using ( DrawingContext context = visual.RenderOpen() )
            //{
            //    context.DrawGeometry( Brushes.Yellow, new Pen( painterParams.borderColor, polyline.StrokeThickness ), streamGeometry );
            //}


            //throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

    }
}
