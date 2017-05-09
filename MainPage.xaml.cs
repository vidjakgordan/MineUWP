using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MineUWP
{
    public sealed partial class MainPage : Page
    {
        VM vm = new VM();

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        #region split-view handlers
        private void HandleChecked(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = true;
        }
        #endregion

        #region button&image right click handlers
        //upravljanje botunom i slikom
        private void Button_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            VM vm = (VM)this.DataContext;
            Cell c = (Cell)((Button)sender).DataContext;
            vm.DesniKlikObrada(c);
        }

        private void Image_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            VM vm = (VM)this.DataContext;
            Cell c = (Cell)((Image)sender).DataContext;
            vm.DesniKlikObrada(c);
        }
        #endregion

        private void button_CPopen_Click(object sender, RoutedEventArgs e)
        {
            if (CPicker.Visibility == Visibility.Collapsed)
                CPicker.Visibility = Visibility.Visible;
            else if (CPicker.Visibility == Visibility.Visible)
                CPicker.Visibility = Visibility.Collapsed;
        }

        private void CPicker_ColorChanged(object sender, Windows.UI.Color color)
        {
            SolidColorBrush color_new = new SolidColorBrush(color);
            color_new.Opacity = .5;

            vm.Color = color_new;
            //izmjena boja       
        }

    }
}
