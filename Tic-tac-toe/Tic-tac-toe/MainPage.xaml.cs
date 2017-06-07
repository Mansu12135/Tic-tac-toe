using System;
using System.Collections.Generic;

using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ApplicationLayer;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Tic_tac_toe
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private PlayingField Field;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

           // Table.Child = null;
              Field = new PlayingField(this,3, Table.ActualWidth);
              Table.Child = Field.Draw();


            // Visual hostVisual = ElementCompositionPreview.GetElementVisual(c6);
            // Compositor compositor = hostVisual.Compositor;

            // //// Create a drop shadow
            // var dropShadow = compositor.CreateDropShadow();
            // dropShadow.Color = Colors.DarkSlateGray;
            // dropShadow.Opacity = 0.7f;
            // dropShadow.BlurRadius = 15;
            // dropShadow.Offset = new Vector3(-6);
            // //// Associate the shape of the shadow with the shape of the target element
            //// dropShadow.Mask = b2.GetAlphaMask();

            // //// Create a Visual to hold the shadow
            // var shadowVisual = compositor.CreateSpriteVisual();
            // shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255,0,104,99));
            // shadowVisual.Shadow = dropShadow;
            // shadowVisual.Size = new Vector2((float)c6.ActualWidth, (float)c6.ActualHeight);
            // //// Add the shadow as a child of the host in the visual tree
            // ElementCompositionPreview.SetElementChildVisual(c6, shadowVisual);

            //// Make sure size of shadow host and shadow visual always stay in sync
            // var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
            //bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);

            // shadowVisual.StartAnimation("Size", bindSizeAnimation);
            //var hostVisual = ElementCompositionPreview.GetElementVisual(c4);
            //var root = hostVisual.Compositor.CreateContainerVisual();
            //ElementCompositionPreview.SetElementChildVisual(c4, root);
            //var _compositor = root.Compositor;
            //SpriteVisual tick;
          
            //    tick = _compositor.CreateSpriteVisual();
            //    tick.Size = new Vector2((float)c4.ActualWidth, 5f);
            //tick.Brush = _compositor.CreateColorBrush(Colors.DarkGray);
            //    tick.Offset = new Vector3(6, -6, 0);
            //   // tick.CenterPoint = new Vector3(2.0f, 100.0f, 0);
            //    root.Children.InsertAtTop(tick);
            //var  hostVisual = ElementCompositionPreview.GetElementVisual(c4);
            //compositor = hostVisual.Compositor;

            ////// Create a drop shadow
            //dropShadow = compositor.CreateDropShadow();
            //dropShadow.Color = Colors.DarkSlateGray;
            //dropShadow.Opacity = 0.7f;
            //dropShadow.BlurRadius = 15;
            //dropShadow.Offset = new Vector3(6,-6,0);
            ////// Associate the shape of the shadow with the shape of the target element
            //// dropShadow.Mask = b2.GetAlphaMask();

            ////// Create a Visual to hold the shadow
            //shadowVisual = compositor.CreateSpriteVisual();
            //shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
            //shadowVisual.Shadow = dropShadow;
            //shadowVisual.Size = new Vector2((float)c4.ActualWidth, (float)c4.ActualHeight);
            ////// Add the shadow as a child of the host in the visual tree
            //ElementCompositionPreview.SetElementChildVisual(c4, shadowVisual);

            //hostVisual = ElementCompositionPreview.GetElementVisual(c5);
            //compositor = hostVisual.Compositor;

            ////// Create a drop shadow
            //dropShadow = compositor.CreateDropShadow();
            //dropShadow.Color = Colors.DarkSlateGray;
            //dropShadow.Opacity = 0.7f;
            //dropShadow.BlurRadius = 15;
            //dropShadow.Offset = new Vector3(0, -6, 0);
            ////// Associate the shape of the shadow with the shape of the target element
            //// dropShadow.Mask = b2.GetAlphaMask();

            ////// Create a Visual to hold the shadow
            //shadowVisual = compositor.CreateSpriteVisual();
            //shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
            //shadowVisual.Shadow = dropShadow;
            //shadowVisual.Size = new Vector2((float)c5.ActualWidth, (float)c5.ActualHeight);
            ////// Add the shadow as a child of the host in the visual tree
            //ElementCompositionPreview.SetElementChildVisual(c5, shadowVisual);



            //hostVisual = ElementCompositionPreview.GetElementVisual(c7);
            //compositor = hostVisual.Compositor;

            ////// Create a drop shadow
            //dropShadow = compositor.CreateDropShadow();
            //dropShadow.Color = Colors.DarkSlateGray;
            //dropShadow.Opacity = 0.7f;
            //dropShadow.BlurRadius = 15;
            //dropShadow.Offset = new Vector3(6, 0, 0);
            ////// Associate the shape of the shadow with the shape of the target element
            //// dropShadow.Mask = b2.GetAlphaMask();

            ////// Create a Visual to hold the shadow
            //shadowVisual = compositor.CreateSpriteVisual();
            //shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
            //shadowVisual.Shadow = dropShadow;
            //shadowVisual.Size = new Vector2((float)c7.ActualWidth, (float)c7.ActualHeight);
            ////// Add the shadow as a child of the host in the visual tree
            //ElementCompositionPreview.SetElementChildVisual(c7, shadowVisual);



            //hostVisual = ElementCompositionPreview.GetElementVisual(c9);
            //compositor = hostVisual.Compositor;

            ////// Create a drop shadow
            //dropShadow = compositor.CreateDropShadow();
            //dropShadow.Color = Colors.DarkSlateGray;
            //dropShadow.Opacity = 0.7f;
            //dropShadow.BlurRadius = 15;
            //dropShadow.Offset = new Vector3(-6, 0, 0);
            ////// Associate the shape of the shadow with the shape of the target element
            //// dropShadow.Mask = b2.GetAlphaMask();

            ////// Create a Visual to hold the shadow
            //shadowVisual = compositor.CreateSpriteVisual();
            //shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
            //shadowVisual.Shadow = dropShadow;
            //shadowVisual.Size = new Vector2((float)c9.ActualWidth, (float)c9.ActualHeight);
            ////// Add the shadow as a child of the host in the visual tree
            //ElementCompositionPreview.SetElementChildVisual(c9, shadowVisual);

            //hostVisual = ElementCompositionPreview.GetElementVisual(c8);
            //compositor = hostVisual.Compositor;

            ////// Create a drop shadow
            //dropShadow = compositor.CreateDropShadow();
            //dropShadow.Color = Colors.DarkSlateGray;
            //dropShadow.Opacity = 0.7f;
            //dropShadow.BlurRadius = 15;
            //dropShadow.Offset = new Vector3(0, 0, 0);
            ////// Associate the shape of the shadow with the shape of the target element
            //// dropShadow.Mask = b2.GetAlphaMask();

            ////// Create a Visual to hold the shadow
            //shadowVisual = compositor.CreateSpriteVisual();
            //shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
            //shadowVisual.Shadow = dropShadow;
            //shadowVisual.Size = new Vector2((float)c8.ActualWidth, (float)c8.ActualHeight);
            ////// Add the shadow as a child of the host in the visual tree
            //ElementCompositionPreview.SetElementChildVisual(c8, shadowVisual);




            //hostVisual = ElementCompositionPreview.GetElementVisual(c1);
            //compositor = hostVisual.Compositor;

            ////// Create a drop shadow
            //dropShadow = compositor.CreateDropShadow();
            //dropShadow.Color = Colors.DarkSlateGray;
            //dropShadow.Opacity = 0.7f;
            //dropShadow.BlurRadius = 15;
            //dropShadow.Offset = new Vector3(6, 6, 0);
            ////// Associate the shape of the shadow with the shape of the target element
            //// dropShadow.Mask = b2.GetAlphaMask();

            ////// Create a Visual to hold the shadow
            //shadowVisual = compositor.CreateSpriteVisual();
            //shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
            //shadowVisual.Shadow = dropShadow;
            //shadowVisual.Size = new Vector2((float)c1.ActualWidth, (float)c1.ActualHeight);
            ////// Add the shadow as a child of the host in the visual tree
            //ElementCompositionPreview.SetElementChildVisual(c1, shadowVisual);




            //hostVisual = ElementCompositionPreview.GetElementVisual(c3);
            //compositor = hostVisual.Compositor;

            ////// Create a drop shadow
            //dropShadow = compositor.CreateDropShadow();
            //dropShadow.Color = Colors.DarkSlateGray;
            //dropShadow.Opacity = 0.7f;
            //dropShadow.BlurRadius = 15;
            //dropShadow.Offset = new Vector3(-6, 6, 0);
            ////// Associate the shape of the shadow with the shape of the target element
            //// dropShadow.Mask = b2.GetAlphaMask();

            ////// Create a Visual to hold the shadow
            //shadowVisual = compositor.CreateSpriteVisual();
            //shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
            //shadowVisual.Shadow = dropShadow;
            //shadowVisual.Size = new Vector2((float)c3.ActualWidth, (float)c3.ActualHeight);
            ////// Add the shadow as a child of the host in the visual tree
            //ElementCompositionPreview.SetElementChildVisual(c3, shadowVisual);



            //hostVisual = ElementCompositionPreview.GetElementVisual(c2);
            //compositor = hostVisual.Compositor;

            ////// Create a drop shadow
            //dropShadow = compositor.CreateDropShadow();
            //dropShadow.Color = Colors.DarkSlateGray;
            //dropShadow.Opacity = 0.7f;
            //dropShadow.BlurRadius = 15;
            //dropShadow.Offset = new Vector3(0, 6, 0);
            ////// Associate the shape of the shadow with the shape of the target element
            //// dropShadow.Mask = b2.GetAlphaMask();

            ////// Create a Visual to hold the shadow
            //shadowVisual = compositor.CreateSpriteVisual();

            //shadowVisual.Brush = compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
            //shadowVisual.Shadow = dropShadow;
            //shadowVisual.Size = new Vector2((float)c2.ActualWidth, (float)c2.ActualHeight);
            ////// Add the shadow as a child of the host in the visual tree
            //ElementCompositionPreview.SetElementChildVisual(c2, shadowVisual);
        }

        //private void c4_PointerPressed(object sender, PointerRoutedEventArgs e)
        //{
        //    var canv = sender as Canvas;
        //    if (canv == null) return;
        //  //  if (canv.Tag == null) return;
        //    // if (canv.Children.Count == 1) return;
        //    // var split = canv.Tag.ToString().Split('-');
        //    //  int i = Convert.ToInt32(split[0]);
        //    //  int j = Convert.ToInt32(split[1]);
          
        //    var bord = new Border();
        //    bord.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
        //    bord.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
        //    bord.BorderThickness = new Windows.UI.Xaml.Thickness(4);
        //    bord.BorderBrush = new SolidColorBrush(Colors.Black);
        //        bord.Height = 20;
        //        bord.Width = 80;
        //        bord.Background = new SolidColorBrush(Colors.Black);


        //    //  var cont = ElementCompositionPreview.GetElementChildVisual(canv) as ContainerVisual;
        //    //  // cont.Composito
        //    //  var shadowVisual = cont.Compositor.CreateSpriteVisual();

        //    //  //shadowVisual.Brush = cont.Compositor.CreateColorBrush(Color.FromArgb(255, 0, 104, 99));
        //    // var path = ((Path)this.Resources["pathZero"]);
        //    //var   dropShadow = cont.Compositor.CreateDropShadow();
        //    //  dropShadow.Color = Colors.Red;
        //    //  dropShadow.Opacity = 0.7f;
        //    //  dropShadow.BlurRadius = 15;
        //    //  dropShadow.Offset = new Vector3(0, 0, 0);
        //    //  //// Associate the shape of the shadow with the shape of the target element
        //    //   dropShadow.Mask = path.GetAlphaMask();
        //    //  shadowVisual.Shadow = dropShadow;
        //    //  shadowVisual.Size = new Vector2((float)c4.ActualWidth, (float)c4.ActualHeight);
        //    //  cont.Children.InsertAtTop(shadowVisual);
        //    // BezierSegment curve = new BezierSegment();

        //    // Set up the Path to insert the segments
        //    //PathGeometry path = new PathGeometry();

        //    //PathFigure pathFigure = new PathFigure();
        //    //pathFigure.StartPoint = new Point(11, 11);
        //    //pathFigure.IsClosed = true;
        //    //path.Figures.Add(pathFigure);

        //    //pathFigure.Segments.Add(curve);
        //    var path1 = new Windows.UI.Xaml.Shapes.Path();
        //    //path1.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 255));
        //    var stroke = ((LinearGradientBrush)this.Resources["colorZero"]);
        //    path1.Stroke = stroke;
        //    path1.StrokeThickness = 9;
        //    var geometryGroup1 = new GeometryGroup();
          

        //    var pathGeometry1 = new PathGeometry();
        //    var pathFigureCollection1 = new PathFigureCollection();
        //    var pathFigure1 = new PathFigure();
        //    pathFigure1.IsClosed = true;
        //    pathFigure1.StartPoint = new Windows.Foundation.Point(20, 8);
        //    pathFigureCollection1.Add(pathFigure1);
        //    pathGeometry1.Figures = pathFigureCollection1;

        //    var pathSegmentCollection1 = new PathSegmentCollection();
        //    var pathSegment1 = new BezierSegment();
        //    pathSegment1.Point1 = new Point(30, -2);
        //    pathSegment1.Point2 = new Point(30, 25);
        //    pathSegment1.Point3 = new Point(10, 30);
        //    pathSegmentCollection1.Add(pathSegment1);

        //    var pathSegment2 = new BezierSegment();
        //    pathSegment2.Point1 = new Point(-20, 5);
        //    pathSegment2.Point2 = new Point(-35, -20);
        //    pathSegment2.Point3 = new Point(-13, -29);
        //    pathSegmentCollection1.Add(pathSegment2);
        //    pathFigure1.Segments = pathSegmentCollection1;

        //    geometryGroup1.Children.Add(pathGeometry1);
        //    path1.Data = geometryGroup1;
        //    path1.StrokeStartLineCap = PenLineCap.Round;
        //    path1.StrokeEndLineCap = PenLineCap.Round;
        //    c4.Children.Add(path1);

        //   // c4.Children.Add(p); //
        //   // path.Name = "ddw";
        //   //  c4.Children.Add(path);

        //    // c4.Children.Add(new Path() {Data = path.Data, Name = "c444", Stroke = path.Stroke, RenderTransformOrigin = path.RenderTransformOrigin, StrokeThickness = path.StrokeThickness, StrokeEndLineCap = path.StrokeEndLineCap, StrokeStartLineCap = path.StrokeStartLineCap });
        //    Canvas.SetLeft(path1, 20);
        //    Canvas.SetTop(path1, 40);
        //    // Canvas.SetZIndex(bord, 2);
        //    //Tic = !Tic;
        //}


    }
}
