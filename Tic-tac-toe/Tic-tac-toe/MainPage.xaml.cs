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
           // Field = new PlayingField(this, 3, Table.ActualWidth - Table.BorderThickness.Left * 2);
          //  Table.Child = Field.Draw();
        }

        private void BasicMode_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ContainerFirstPage.Visibility = Visibility.Collapsed;
            //Table.Visibility = Visibility.Visible;
            //Table.HorizontalAlignment = HorizontalAlignment.Stretch;
            //Table.VerticalAlignment = VerticalAlignment.Stretch;
            Field = new PlayingField(this, 3, Table.ActualWidth - Table.BorderThickness.Left * 2);
            Table.Child = Field.Draw();
        }
    }
}
