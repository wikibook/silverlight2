#pragma checksum "C:\Users\john.stockton\Desktop\Silverlight 2 In Action Source\6.9-6.12\SilverlightInAction\POX\Page.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9588C82E419F1997A7319203086465B4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace POX {
    
    
    public partial class Page : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox txLat;
        
        internal System.Windows.Controls.TextBox txLong;
        
        internal System.Windows.Controls.Button btnXML;
        
        internal System.Windows.Controls.TextBlock txCity;
        
        internal System.Windows.Controls.TextBlock txName;
        
        internal System.Windows.Controls.TextBlock txtResults;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/POX;component/Page.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txLat = ((System.Windows.Controls.TextBox)(this.FindName("txLat")));
            this.txLong = ((System.Windows.Controls.TextBox)(this.FindName("txLong")));
            this.btnXML = ((System.Windows.Controls.Button)(this.FindName("btnXML")));
            this.txCity = ((System.Windows.Controls.TextBlock)(this.FindName("txCity")));
            this.txName = ((System.Windows.Controls.TextBlock)(this.FindName("txName")));
            this.txtResults = ((System.Windows.Controls.TextBlock)(this.FindName("txtResults")));
        }
    }
}
