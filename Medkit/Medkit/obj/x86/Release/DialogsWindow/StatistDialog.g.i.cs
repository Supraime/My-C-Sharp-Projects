﻿#pragma checksum "..\..\..\..\DialogsWindow\StatistDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3A7BB15C15BA92735A4DFEE8E2FA64412DB3FE390566B29E33134258CCC1C80A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Medkit.DialogsWindow;
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


namespace Medkit.DialogsWindow {
    
    
    /// <summary>
    /// StatistDialog
    /// </summary>
    public partial class StatistDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NameDialog;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Day;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateDay;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StatusBox;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label RegPriem;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BadPriem;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CancelPriem;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Sum;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Sale;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Vsum;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AcceptButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Medkit;component/dialogswindow/statistdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
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
            
            #line 13 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
            ((Medkit.DialogsWindow.StatistDialog)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameDialog = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            
            #line 35 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 47 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 55 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Day = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.DateDay = ((System.Windows.Controls.DatePicker)(target));
            
            #line 82 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
            this.DateDay.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DateDay_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StatusBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 90 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
            this.StatusBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StatusBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RegPriem = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.BadPriem = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.CancelPriem = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.Sum = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.Sale = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.Vsum = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.AcceptButton = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\..\..\DialogsWindow\StatistDialog.xaml"
            this.AcceptButton.Click += new System.Windows.RoutedEventHandler(this.AcceptButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
