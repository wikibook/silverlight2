using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Windows.Browser;

namespace Snippet3_17
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            HtmlPage.RegisterScriptableObject("bridge", this);
        }

        [ScriptableMember]
        public void AddRowAndColumn()
        {
            // Programmatically add a Row
            RowDefinition myRow = new RowDefinition();
            myGrid.RowDefinitions.Add(myRow);                                         

            // Programmatically add a Column
            ColumnDefinition myColumn = new ColumnDefinition();
            myGrid.ColumnDefinitions.Insert(0, myColumn);

            HtmlWindow window = HtmlPage.Window;
            window.Alert(myGrid.ColumnDefinitions.Count.ToString());
        }
    }
}
