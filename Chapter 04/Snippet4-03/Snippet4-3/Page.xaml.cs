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

namespace Snippet4_3
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(Page_KeyUp);
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            myTextBlock.Text = "Key (" + e.Key + ") was released.";
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.B)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Shift) == (ModifierKeys.Shift))
                    myTextBlock.Text = "You have selected SHIFT+B!";
            }
        }
    }
}
