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

namespace Snippet12_8
{
    public partial class NavigationService : UserControl
    {
        private static UserControl currentPage = null;

        public NavigationService()
        {
            InitializeComponent();

            currentPage = new Page();
            LayoutRoot.Children.Add(currentPage);
        }

        public static void Navigate(UserControl newPage)
        {
            Panel root = (Panel)(currentPage.Parent);
            UIElement pageToRemove = null;

            string currentPageType = currentPage.GetType().FullName;
            foreach (UIElement child in root.Children)
            {
                string childType = child.GetType().FullName;
                if (childType == currentPageType)
                {
                    pageToRemove = child;
                    break;
                }
            }

            if (pageToRemove != null)
                root.Children.Remove(pageToRemove);

            root.Children.Add(newPage);
            currentPage = newPage;
        }
    }
}
