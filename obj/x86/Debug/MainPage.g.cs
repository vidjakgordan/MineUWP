﻿#pragma checksum "C:\Users\Gordan\documents\visual studio 2015\Projects\MineUWP\MineUWP\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8370DF839718D50FCA40D0DBEBFA484D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MineUWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.MainBack = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.splitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3:
                {
                    this.ControlsPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4:
                {
                    this.button_CPopen = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 44 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.button_CPopen).Click += this.button_CPopen_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.CPicker = (global::Coding4Fun.Toolkit.Controls.ColorPicker)(target);
                    #line 45 "..\..\..\MainPage.xaml"
                    ((global::Coding4Fun.Toolkit.Controls.ColorPicker)this.CPicker).ColorChanged += this.CPicker_ColorChanged;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 60 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element6).RightTapped += this.Button_RightTapped;
                    #line default
                }
                break;
            case 7:
                {
                    global::Windows.UI.Xaml.Controls.Image element7 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 63 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element7).RightTapped += this.Image_RightTapped;
                    #line default
                }
                break;
            case 8:
                {
                    this.HambButton = (global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target);
                    #line 15 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.HambButton).Checked += this.HandleChecked;
                    #line 16 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.HambButton).Unchecked += this.HandleUnchecked;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

