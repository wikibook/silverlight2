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

namespace Snippet5_21
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            // Retrieve all of the musical groups from the data source
            List<MusicalGroup> musicalGroups = MusicalGroup.FindAll();

            // Retrieve all of the rock groups
            var rockGroups = from musicalGroup in musicalGroups
                             where musicalGroup.Genre == "Rock"
                             orderby musicalGroup.Name
                             select musicalGroup;

            foreach (MusicalGroup rockGroup in rockGroups)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = rockGroup.Name;
                myListBox.Items.Add(item);
            }
        }
    }
}
