﻿#pragma checksum "..\..\GameOver.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6983C5D06D2682176B9CE98AA7607A9AE90E64D7830F61ED9D464A4BBEC41209"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Tetris {
    
    
    /// <summary>
    /// GameOver
    /// </summary>
    public partial class GameOver : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\GameOver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blockTaskai;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\GameOver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMenu;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\GameOver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIssaugoti;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\GameOver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIsNaujo;
        
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
            System.Uri resourceLocater = new System.Uri("/Tetris;component/gameover.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GameOver.xaml"
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
            
            #line 4 "..\..\GameOver.xaml"
            ((Tetris.GameOver)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded_1);
            
            #line default
            #line hidden
            
            #line 4 "..\..\GameOver.xaml"
            ((Tetris.GameOver)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.blockTaskai = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btnMenu = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\GameOver.xaml"
            this.btnMenu.Click += new System.Windows.RoutedEventHandler(this.btnMenu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnIssaugoti = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\GameOver.xaml"
            this.btnIssaugoti.Click += new System.Windows.RoutedEventHandler(this.btnIssaugoti_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnIsNaujo = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\GameOver.xaml"
            this.btnIsNaujo.Click += new System.Windows.RoutedEventHandler(this.btnIsNaujo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

