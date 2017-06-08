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
            Table.Child = Field.Draw();
        }
        private void Field_OnGameCompleted()
        {
           NewGame();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            colorStoryboard.Begin();
            colorStoryboard.Completed += ColorStoryboard_Completed;

        }

        private void ColorStoryboard_Completed(object sender, object e)
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
            Field = null;
        }

        private void TextBlock_PointerPressed_2(object sender, PointerRoutedEventArgs e)
        {
            NewGame();
        }
    }
}
