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
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new VM();
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
    }
}
