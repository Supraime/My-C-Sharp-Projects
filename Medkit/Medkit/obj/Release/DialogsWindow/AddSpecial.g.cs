#pragma checksum "..\..\..\DialogsWindow\AddSpecial.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "63A25615722DE5C1BEDF191708664DE9F6DB789EE5649C1998ED3002D9DDB86B"
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
    /// AddSpecial
    /// </summary>
    public partial class AddSpecial : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\DialogsWindow\AddSpecial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NameBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\DialogsWindow\AddSpecial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SpecNameBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\DialogsWindow\AddSpecial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label WarningMsg;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\DialogsWindow\AddSpecial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddSpec;
        
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
            System.Uri resourceLocater = new System.Uri("/Medkit;component/dialogswindow/addspecial.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DialogsWindow\AddSpecial.xaml"
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
            this.NameBox = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.SpecNameBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\DialogsWindow\AddSpecial.xaml"
            this.SpecNameBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.SpecNameBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.WarningMsg = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.AddSpec = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\DialogsWindow\AddSpecial.xaml"
            this.AddSpec.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

