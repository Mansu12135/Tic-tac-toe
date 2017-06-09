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
        private bool onePlayer = true;
        
        private void BasicMode_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            onePlayer = true;
            NewGame();
        }
        private void NewGame()
        {
            ContainerFirstPage.Visibility = Visibility.Collapsed;
            Field = new PlayingField(this, 3, Table.ActualWidth - Table.BorderThickness.Left * 2, onePlayer);
            Field.OnGameCompleted -= Field_OnGameCompleted;
            Field.OnGameCompleted += Field_OnGameCompleted;
            Field.OnMakeGo -= Field_OnMakeGo;
            Field.OnMakeGo += Field_OnMakeGo;
            Table.Child = Field.Draw();
        }

        private void Field_OnMakeGo(bool dagger)
        {
            if (dagger)
            {
                var stroke = ((LinearGradientBrush)this.Resources["colorX1"]);
                x1.Stroke = stroke;
                x2.Stroke = stroke;
                Zero.Stroke = new SolidColorBrush(Colors.Gray);
            }
            else
            {
                var stroke = ((LinearGradientBrush)this.Resources["colorZero"]);
                x1.Stroke = new SolidColorBrush(Colors.Gray);
                x2.Stroke = new SolidColorBrush(Colors.Gray);
                Zero.Stroke = stroke;
            }
        }
        int countZ = 0;
        int countX = 0;
        private void Field_OnGameCompleted(TicTacToe winner)
        {
            Table.Child = null;
            if (winner== TicTacToe.Dagger)
            {
                countX++;
                WinBlock.Text = "Dagger win !";
            }
            else if(winner== TicTacToe.Toe)
            {
                countZ++;
                WinBlock.Text = "Toe win !";
            }
            else
            {
                countX++;
                countZ++;
                WinBlock.Text = "1-1";
            }
            CountWin.Text = countX + " : " + countZ;
            Canvas.SetZIndex(MyFadingText, 2);
            sizeStoryboard.Begin();
            sizeStoryboard.Completed += SizeStoryboard_Completed;
          //  NewGame();
        }

        private void SizeStoryboard_Completed(object sender, object e)
        {
            
            Canvas.SetZIndex(MyFadingText, 0);
            NewGame();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            colorStoryboard.Begin();
        }

        private void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            onePlayer = false;
            NewGame();
        }

        private void TextBlock_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            ContainerFirstPage.Visibility = Visibility.Visible;
            colorStoryboard.Begin();
            Field = null;
        }

        private void TextBlock_PointerPressed_2(object sender, PointerRoutedEventArgs e)
        {
            NewGame();
        }
    }
}
