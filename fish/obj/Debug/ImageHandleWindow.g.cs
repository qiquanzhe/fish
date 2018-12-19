﻿#pragma checksum "..\..\ImageHandleWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "110B553CC7EE8864B83B893379BE6622B0D02EC2"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using fish;


namespace fish {
    
    
    /// <summary>
    /// ImageHandleWindow
    /// </summary>
    public partial class ImageHandleWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\ImageHandleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox optionSelectView;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ImageHandleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image HandlingImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/fish;component/imagehandlewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ImageHandleWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 19 "..\..\ImageHandleWindow.xaml"
            ((fish.ImageHandleWindow)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Move_MouseMove);
            
            #line default
            #line hidden
            return;
            case 2:
            this.optionSelectView = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            
            #line 22 "..\..\ImageHandleWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.OriginalImage);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 23 "..\..\ImageHandleWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.BrightImage);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 24 "..\..\ImageHandleWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.BlueImage);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 25 "..\..\ImageHandleWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ReveseImage);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 26 "..\..\ImageHandleWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.RegionalGrayImage);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 27 "..\..\ImageHandleWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.CannyImage);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 28 "..\..\ImageHandleWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SketchImage);
            
            #line default
            #line hidden
            return;
            case 10:
            this.HandlingImage = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            
            #line 31 "..\..\ImageHandleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveImage);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 37 "..\..\ImageHandleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

