using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Painter painter;

        public MainWindow()
        {
            InitializeComponent();
            painter = new Painter( drawCanvas );
            drawCanvas.PreviewMouseLeftButtonDown += ( s, e ) =>
            {
               painter.StartDrawing( typeof( Polyline ), e.GetPosition( drawCanvas ) );
            };

            drawCanvas.PreviewMouseLeftButtonUp += ( s, e ) =>
            {
                painter.StopDrawing( e.GetPosition( drawCanvas ) );
            };

            drawCanvas.MouseMove += ( s, e ) =>
            {
                painter.Drawing( e.GetPosition( drawCanvas ) );
            };
        }

        Boolean             isDrawing   = false;
        Stack<List<Shape>>  delShapes   = new Stack<List<Shape>>();
        SolidColorBrush     brush       = new SolidColorBrush(Colors.Blue);
        List<Line>          tempLineList = new List<Line>();
        Point               lineStartPoint;
        Point               lineEndPoint;

        //private void DrawCanvas_MouseLeftButtonDown( object sender, MouseEventArgs e )
        //{
        //    isDrawing = true;
        //    lineStartPoint = e.GetPosition( drawCanvas );
        //    //painter.StartDrawing( typeof( Line ), e.GetPosition( drawCanvas ) );
        //}

        //private void DrawCanvas_MouseLeftButtonUp( object sender, MouseEventArgs e )
        //{
        //    //isDrawing = false;

        //    //painter.StopDrawing( e.GetPosition( drawCanvas ) );


        //    //if ( isDrawing )
        //    //{
        //    //    Point lineEnd = e.GetPosition( drawCanvas );
        //    //    Line l = new Line();
        //    //    l.X1 = lineStartPoint.X;
        //    //    l.Y1 = lineStartPoint.Y;
        //    //    l.X2 = lineEnd.X;
        //    //    l.Y2 = lineEnd.Y;
        //    //    l.Stroke = brush;
        //    //    l.StrokeThickness = 2;
        //    //    tempLineList.ForEach(
        //    //        i => drawCanvas.Children.Remove( i ) );
        //    //    tempLineList.Clear();
        //    //    drawCanvas.Children.Add( l );
        //    //    lineStartPoint = lineEnd;
        //    //}


        //}

        //private void DrawCanvas_MouseMove( object sender, MouseEventArgs e )
        //{
        //    //painter.Drawing( e.GetPosition( drawCanvas ) );

        //    //if ( isDrawing )
        //    //{
        //    //    Point lineEnd = e.GetPosition( drawCanvas );
        //    //    Line l = new Line();
        //    //    l.X1 = lineStartPoint.X;
        //    //    l.Y1 = lineStartPoint.Y;
        //    //    l.X2 = lineEnd.X;
        //    //    l.Y2 = lineEnd.Y;
        //    //    l.Stroke = brush;
        //    //    l.StrokeThickness = 2;
        //    //    tempLineList.ForEach(
        //    //       i => drawCanvas.Children.Remove( i ) );
        //    //    tempLineList.Add( l );
        //    //    drawCanvas.Children.Add( l );
        //    //    //lineStartPoint = lineEnd;
        //    //}
        //}

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // drawCanvas.Children.Clear();
            painter.Clear();
        }

    }
}
