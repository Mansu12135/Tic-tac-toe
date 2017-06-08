using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
using Windows.UI.Xaml.Hosting;
using System.Numerics;
using ApplicationLayer;

namespace Tic_tac_toe
{
    internal class PlayingField
    {
        private int Size;
        private MainPage Page;
        private double Width;
        private GameEngine Engine;
        bool withComp = false;
        public PlayingField(MainPage page, int size, double width, bool withComp)
        {
            Page = page;
            withComp = withComp;
            Size = size;
            Width = width;
            Engine =
                new GameEngine(new GameSettings
                {
                    EnemyIsComputer = withComp,
                    EnemySide = TicTacToe.Dagger,
                    PlayingFieldMode = PlayingFieldMode.Basic
                });
            Engine.OnGameCompleted += Engine_OnGameCompleted;
            Engine.OnMatrixChanged += Engine_OnMatrixChanged;
           
        }

        private void Engine_OnMatrixChanged(int cell, TicTacToe side)
        {
            Dagger = false;
            foreach (var canv in canvases)
            {
                var split = canv.Tag.ToString().Split('-');
                int i = Convert.ToInt32(split[0]);
                int j = Convert.ToInt32(split[1]);
                if(i * 3 + j == cell)
                {
                    SetX(canv);
                    break;
                }
            }
            //Engine.MakeMove(cell, side);
            //computer made move
        }

        private void Engine_OnGameCompleted(string winnerName, TicTacToe winnerSide)
        {
            //game complete
        }
        List<Canvas> canvases = new List<Canvas>();
        public StackPanel Draw()
        {
            var sideSize = Width / Size;
            var verticalPanel = new StackPanel();
            verticalPanel.Loaded += VerticalPanel_Loaded;
            verticalPanel.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
            verticalPanel.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;
            for (int i = 0; i < Size; i++)
            {
                var horizPanel = new StackPanel();
                horizPanel.Orientation = Orientation.Horizontal;
                horizPanel.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                horizPanel.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;
                for (int j = 0; j < Size; j++)
                {
                    Border bordResource;
                    Vector3 offset;
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            offset = new Vector3(6, 6, 0);
                            bordResource = ((Border)Page.Resources["BorderTopLeft"]);
                        }
                        else if (j == Size - 1)
                        {
                            offset = new Vector3(-6, 6, 0);
                            bordResource = ((Border)Page.Resources["BorderTopRight"]);

                        }
                        else
                        {
                            offset = new Vector3(0, 6, 0);
                            bordResource = ((Border)Page.Resources["BorderTop"]);
                        }
                    }
                    else if (i == Size - 1)
                    {
                        if (j == 0)
                        {
                            offset = new Vector3(6, -6, 0);
                            bordResource = ((Border)Page.Resources["BorderBottomLeft"]);
                        }
                        else if (j == Size - 1)
                        {
                            offset = new Vector3(0, 6, 0);
                            bordResource = ((Border)Page.Resources["BorderBottomRight"]);

                        }
                        else
                        {
                            offset = new Vector3(-6, -6, 0);
                            bordResource = ((Border)Page.Resources["BorderBottomCenter"]);
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            offset = new Vector3(6, 0, 0);
                            bordResource = ((Border)Page.Resources["BorderLeft"]);
                        }
                        else if (j == Size - 1)
                        {
                            offset = new Vector3(-6, 0, 0);
                            bordResource = ((Border)Page.Resources["BorderRight"]);

                        }
                        else
                        {
                            offset = new Vector3(0, 0, 0);
                            bordResource = ((Border)Page.Resources["BorderCenter"]);
                        }
                    }
                    var bord = new Border() { CornerRadius = bordResource.CornerRadius, BorderBrush = bordResource.BorderBrush, BorderThickness = bordResource.BorderThickness };
                    bord.Height = sideSize;
                    bord.Width = sideSize;
                    bord.Name = "bord" + i + "-" + j;
                    var canv = new Canvas
                    {
                        HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch,
                        VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch
                    };
                    canvases.Add(canv);
                    canv.PointerPressed += Canv_PointerPressed;
                    canv.Tag = i.ToString() + "-" + j.ToString();
                    canv.Margin = new Windows.UI.Xaml.Thickness(6);
                    canv.Background = new SolidColorBrush(Colors.Transparent);
                    bord.Child = canv;
                    horizPanel.Children.Add(bord);
                    // SetShadow(offset, canv, sideSize-12);
                }
                verticalPanel.Children.Add(horizPanel);
            }
            return verticalPanel;
        }

        private void VerticalPanel_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Engine.MakeMove(Int32.MinValue, TicTacToe.Toe);
        }

        private void SetShadow(Vector3 offset, Canvas c, double size)
        {
            var hostVisual = ElementCompositionPreview.GetElementVisual(c);
            var compositor = hostVisual.Compositor;

            //// Create a drop shadow
            var dropShadow = compositor.CreateDropShadow();
            dropShadow.Color = Colors.DarkSlateGray;
            dropShadow.Opacity = 0.7f;
            dropShadow.BlurRadius = 15;
            dropShadow.Offset = offset;
            //// Associate the shape of the shadow with the shape of the target element
            // dropShadow.Mask = b2.GetAlphaMask();

            //// Create a Visual to hold the shadow
            var shadowVisual = compositor.CreateSpriteVisual();
            shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
            shadowVisual.Shadow = dropShadow;
            shadowVisual.Size = new Vector2((float)size, 5);
            //// Add the shadow as a child of the host in the visual tree
            ElementCompositionPreview.SetElementChildVisual(c, shadowVisual);
        }
        public bool Dagger = false;
        string point;
        private void Canv_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var canv = sender as Canvas;
            if (canv == null) return;
            if (canv.Tag == null) return;
            if (canv.Children.Count == 1)
            {
                canv.Children.Clear();
            }
           
            var pp = e.GetCurrentPoint(canv);
            point += "'" + pp.Position.X + "-" + pp.Position.Y + "' ";
            var split = canv.Tag.ToString().Split('-');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            if (Dagger)
            {
                if (!withComp)
                {
                    Dagger = !Dagger;
                    SetX(canv);
                    Engine.MakeMove(i * 3 + j, TicTacToe.Dagger);
                }
            }
            else
            {
                Dagger = !Dagger;
                SetZero(canv);
                Engine.MakeMove(i * 3 + j, TicTacToe.Toe);
            }
            
        }

        private void SetZero(Canvas canvas)
        {
            var path1 = new Windows.UI.Xaml.Shapes.Path();
            var stroke = ((LinearGradientBrush)Page.Resources["colorZero"]);
            path1.Stroke = stroke;
            path1.StrokeStartLineCap = PenLineCap.Round;
            path1.StrokeEndLineCap = PenLineCap.Round;
            path1.StrokeThickness = 9;
            var geometryGroup1 = new GeometryGroup();
            var pathGeometry1 = new PathGeometry();
            var pathFigureCollection1 = new PathFigureCollection();
            var pathFigure1 = new PathFigure();
            pathFigure1.IsClosed = true;
            pathFigure1.StartPoint = new Windows.Foundation.Point(20, 8);
            pathFigureCollection1.Add(pathFigure1);
            pathGeometry1.Figures = pathFigureCollection1;

            var pathSegmentCollection1 = new PathSegmentCollection();
            var pathSegment1 = new BezierSegment();
            pathSegment1.Point1 = new Point(28, 8);
            pathSegment1.Point2 = new Point(38.98, 11.99);
            pathSegment1.Point3 = new Point(40.97, 23.97);
            pathSegmentCollection1.Add(pathSegment1);

            var pathSegment2 = new BezierSegment();
            pathSegment2.Point1 = new Point(39.96, 31.98);
            pathSegment2.Point2 = new Point(29.98, 38.98);
            pathSegment2.Point3 = new Point(18.98, 36.99);
            pathSegmentCollection1.Add(pathSegment2);

            var pathSegment3 = new BezierSegment();
            pathSegment3.Point1 = new Point(11.99, 35.98);
            pathSegment3.Point2 = new Point(5.98, 29.99);
            pathSegment3.Point3 = new Point(5.98, 20.98);
            pathSegmentCollection1.Add(pathSegment3);

            var pathSegment4 = new BezierSegment();
            pathSegment4.Point1 = new Point(7.97, 14.97);
            pathSegment4.Point2 = new Point(11.97, 8.97);
            pathSegment4.Point3 = new Point(19.98, 8);
            pathSegmentCollection1.Add(pathSegment4);
            pathFigure1.Segments = pathSegmentCollection1;

            geometryGroup1.Children.Add(pathGeometry1);
            path1.Data = geometryGroup1;

            canvas.Children.Add(path1);
            Canvas.SetLeft(path1, 20);
            Canvas.SetTop(path1, 20);
        }


        private void SetX(Canvas canvas)
        {
            var path1 = new Windows.UI.Xaml.Shapes.Path();
            var stroke = ((LinearGradientBrush)Page.Resources["colorX1"]);
            path1.Stroke = stroke;
            path1.StrokeStartLineCap = PenLineCap.Round;
            path1.StrokeEndLineCap = PenLineCap.Round;
            path1.StrokeThickness = 9;
            var geometryGroup1 = new GeometryGroup();
            var pathGeometry1 = new PathGeometry();
            var pathFigureCollection1 = new PathFigureCollection();
            var pathFigure1 = new PathFigure();
            pathFigure1.StartPoint = new Windows.Foundation.Point(8.99, 6.98);
            pathFigureCollection1.Add(pathFigure1);
            pathGeometry1.Figures = pathFigureCollection1;

            var pathSegmentCollection1 = new PathSegmentCollection();
            var pathSegment1 = new BezierSegment();
            pathSegment1.Point1 = new Point(19.99, 15.97);
            pathSegment1.Point2 = new Point(30.99, 27.99);
            pathSegment1.Point3 = new Point(38.96, 46.96);
            pathSegmentCollection1.Add(pathSegment1);
            pathFigure1.Segments = pathSegmentCollection1;
            geometryGroup1.Children.Add(pathGeometry1);

            var pathGeometry2 = new PathGeometry();
            var pathFigureCollection2 = new PathFigureCollection();
            var pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Windows.Foundation.Point(39.99, 3.99);
            pathFigureCollection2.Add(pathFigure2);
            pathGeometry2.Figures = pathFigureCollection2;

            var pathSegmentCollection2 = new PathSegmentCollection();
            var pathSegment2 = new BezierSegment();
            pathSegment2.Point1 = new Point(31.97, 19.98);
            pathSegment2.Point2 = new Point(22.98, 31.96);
            pathSegment2.Point3 = new Point(8.99, 40.99);
            pathSegmentCollection2.Add(pathSegment2);
            pathFigure2.Segments = pathSegmentCollection2;
            geometryGroup1.Children.Add(pathGeometry2);
            path1.Data = geometryGroup1;
            canvas.Children.Add(path1);
            Canvas.SetLeft(path1, 20);
            Canvas.SetTop(path1, 20);
        }
    }
}
