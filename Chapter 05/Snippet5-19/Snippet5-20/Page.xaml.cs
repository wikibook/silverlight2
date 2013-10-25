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

namespace Snippet5_20
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            // Retrieve all of the musical artists from the data source
            List<MusicalGroup> musicalGroups = MusicalGroup.FindAll();

            // Retrieve all rock groups
            List<MusicalGroup> rockGroups = new List<MusicalGroup>();
            foreach (MusicalGroup musicalGroup in musicalGroups)
            {
                if (musicalGroup.Genre == "Rock")
                {
                    rockGroups.Add(musicalGroup);
                }
            }

            // Sort the results by name via a bubble sort
            MusicalGroup rockGroup = null;
            for (int i = rockGroups.Count - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    string name1 = rockGroups[j - 1].Name;
                    string name2 = rockGroups[j].Name;
                    if (name1.CompareTo(name2) > 0)
                    {
                        rockGroup = rockGroups[j - 1];
                        rockGroups[j - 1] = rockGroups[j];
                        rockGroups[j] = rockGroup;
                    }
                }
            }

            foreach (MusicalGroup rg in rockGroups)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = rg.Name;
                myListBox.Items.Add(item);
            }
        }
    }
}
