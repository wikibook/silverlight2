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

namespace Snippet5_18
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            // Define an array of musical band names
            string[] musicalGroups = { 
                "Super Rad Band", "Sir Prize", 
                "Angry Flubber", "Goop", "Fingernail"};

            // Retrieve all groups that start with "S"
            var filtered = from g in musicalGroups
                           where g[0] == 'S'
                           orderby g ascending
                           select g;

            // List the band names
            foreach (string musicalGroup in filtered)
            {
                ListBoxItem myListBoxItem = new ListBoxItem();
                myListBoxItem.Content = musicalGroup;
                myListBox.Items.Add(myListBoxItem);
            }
        }
    }
}
