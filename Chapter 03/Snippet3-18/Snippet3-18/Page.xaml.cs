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

namespace Snippet3_18
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            HtmlPage.RegisterScriptableObject("bridge", this);
        }

        [ScriptableMember]
        public void RemoveRowAndColumn()
        {
            // Programmatically remove the first Row
            RowDefinition myRow = myGrid.RowDefinitions[0];
            myGrid.RowDefinitions.Remove(myRow);                                      

            // Programmatically remove the last Column
            int lastColumnIndex = myGrid.ColumnDefinitions.Count - 1;
            myGrid.ColumnDefinitions.RemoveAt(lastColumnIndex);                       

            HtmlWindow window = HtmlPage.Window;
            window.Alert(myGrid.ColumnDefinitions.Count.ToString());
        }
    }
}
