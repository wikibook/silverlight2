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

using System.Windows.Media.Imaging;

namespace Snippet12_2
{
    public partial class LockableTextBox : UserControl
    {
        public LockableTextBox()
        {
            InitializeComponent();
        }

        private void myImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsLocked = !this.IsLocked;
        }

        public void UpdateUI()
        {
            if (IsLocked == true)
            {
                myImage.Source = new BitmapImage(new Uri("http://www.silverlightinaction.com/locked.png", UriKind.Absolute));
            }
            else
            {
                myImage.Source = new BitmapImage(new Uri("http://www.silverlightinaction.com/unlocked.png", UriKind.Absolute));
            }
            myTextBox.IsReadOnly = IsLocked;
        }

        public bool IsLocked
        {
            get { return (bool)(GetValue(IsLockedProperty)); }
            set { SetValue(IsLockedProperty, value); }
        }

        public static readonly DependencyProperty IsLockedProperty =
            DependencyProperty.Register(
            "IsLocked",
            typeof(bool),
            typeof(LockableTextBox),
            new PropertyMetadata(new PropertyChangedCallback(OnIsLockedChanged))
        );

        private static void OnIsLockedChanged(DependencyObject o,
            DependencyPropertyChangedEventArgs e)
        {
            LockableTextBox textBox = (LockableTextBox)(o);
            textBox.UpdateUI();
        }
    }
}
