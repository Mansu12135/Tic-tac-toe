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
        public PlayingField(MainPage page,int size, double width)
        {
            Page = page;
            Size = size;
            Width = width;
            Engine =
                new GameEngine(new GameSettings
                {
                    EnemyIsComputer = true,
                    EnemySide = TicTacToe.Toe,
                    PlayingFieldMode = PlayingFieldMode.Basic
                });
            Engine.OnGameCompleted += Engine_OnGameCompleted;
            Engine.OnMatrixChanged += Engine_OnMatrixChanged;
        }

        private void Engine_OnMatrixChanged(int cell, TicTacToe side)
        {
            //computer made move
        }

        private void Engine_OnGameCompleted(string winnerName, TicTacToe winnerSide)
        {
            //game complete
        }

        public StackPanel Draw()
        {
            var sideSize = Width / Size;
            var verticalPanel = new StackPanel();
            verticalPanel.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
            verticalPanel.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;

            for (int i = 0; i < Size; i++)
            {
                var horizPanel = new StackPanel();
                horizPanel.Orientation = Orientation.Horizontal;
                horizPanel.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                horizPanel.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;
                // horizPanel.PointerEntered += HorizPanel_PointerEntered;
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
                        else if(j == Size - 1)
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
                    else if (i== Size - 1)
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

                    //  bord.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                    //   bord.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;
                    //   bord.BorderThickness = new Windows.UI.Xaml.Thickness(1);
                    //  bord.BorderBrush = new SolidColorBrush(Colors.Aqua);
                    var bord = new Border() { CornerRadius = bordResource.CornerRadius, BorderBrush = bordResource.BorderBrush, BorderThickness = bordResource.BorderThickness };
                    bord.Height = sideSize;
                    bord.Width = sideSize;
                    bord.Name = "bord" + i + "-" + j;
                    var canv = new Canvas
                    {
                        HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch,
                        VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch
                    };
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
        private void SetShadow(Vector3 offset, Canvas c, double size)
        {
            var hostVisual = ElementCompositionPreview.GetElementVisual(c);
           var  compositor = hostVisual.Compositor;

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
        public bool Tic = true;
        private void Canv_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var canv = sender as Canvas;
            if (canv == null) return;
            if (canv.Tag == null) return;
            if (canv.Children.Count == 1) return;
            var split = canv.Tag.ToString().Split('-');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            //var bord = new Border();
            //bord.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
            //bord.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
            //bord.BorderThickness = new Windows.UI.Xaml.Thickness(4);
            //bord.BorderBrush = new SolidColorBrush(Colors.Black);
          
            if (Tic)
            {
                SetX(canv);
                //bord.Height = 20;
                //bord.Width = 80;
                //bord.Background = new SolidColorBrush(Colors.Black);
                Engine.MakeMove(i * 3 + j, TicTacToe.Dagger);
            }
            else
            {
                SetZero(canv);
                //bord.Height = 80;
                //bord.Width = 80;
                //bord.CornerRadius = new Windows.UI.Xaml.CornerRadius(40);
                Engine.MakeMove(i * 3 + j, TicTacToe.Dagger);
            }
            //canv.Children.Add(bord);
            //Canvas.SetLeft(bord, 40);
            //Canvas.SetTop(bord,  40);
            Tic = !Tic;
        }

        private void SetZero(Canvas canvas)
        {
            var path1 = new Windows.UI.Xaml.Shapes.Path();
            //path1.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 255));
            var stroke = ((LinearGradientBrush)Page.Resources["colorZero"]);
            path1.Stroke = stroke;
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
            pathSegment1.Point1 = new Point(30, -2);
            pathSegment1.Point2 = new Point(30, 25);
            pathSegment1.Point3 = new Point(10, 30);
            pathSegmentCollection1.Add(pathSegment1);

            var pathSegment2 = new BezierSegment();
            pathSegment2.Point1 = new Point(-20, 5);
            pathSegment2.Point2 = new Point(-35, -20);
            pathSegment2.Point3 = new Point(-13, -29);
            pathSegmentCollection1.Add(pathSegment2);
            pathFigure1.Segments = pathSegmentCollection1;

            geometryGroup1.Children.Add(pathGeometry1);
            path1.Data = geometryGroup1;
            path1.StrokeStartLineCap = PenLineCap.Round;
            path1.StrokeEndLineCap = PenLineCap.Round;
            canvas.Children.Add(path1);
            Canvas.SetLeft(path1, 20);
            Canvas.SetTop(path1, 40);
        }


        private void SetX(Canvas canvas)
        {
            var path1 = new Windows.UI.Xaml.Shapes.Path();
            //path1.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 255));
            var stroke = ((LinearGradientBrush)Page.Resources["colorZero"]);
            path1.Stroke = stroke;
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
            pathSegment1.Point1 = new Point(30, -2);
            pathSegment1.Point2 = new Point(30, 25);
            pathSegment1.Point3 = new Point(10, 30);
            pathSegmentCollection1.Add(pathSegment1);

            //var pathSegment2 = new BezierSegment();
            //pathSegment2.Point1 = new Point(-20, 5);
            //pathSegment2.Point2 = new Point(-35, -20);
            //pathSegment2.Point3 = new Point(-13, -29);
            //pathSegmentCollection1.Add(pathSegment2);
            pathFigure1.Segments = pathSegmentCollection1;

            geometryGroup1.Children.Add(pathGeometry1);
            path1.Data = geometryGroup1;
            path1.StrokeStartLineCap = PenLineCap.Round;
            path1.StrokeEndLineCap = PenLineCap.Round;
            canvas.Children.Add(path1);
            Canvas.SetLeft(path1, 20);
            Canvas.SetTop(path1, 40);
        }
    }
}
