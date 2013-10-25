using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Snippet5_20
{
    public class MusicalGroup
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public static List<MusicalGroup> FindAll()
        {
            List<MusicalGroup> musicalGroups = new List<MusicalGroup>();
            musicalGroups.Add(new MusicalGroup { ID = 1, Name = "Super Rad Band", Genre = "Ska" });
            musicalGroups.Add(new MusicalGroup { ID = 3, Name = "Sir Prize", Genre = "Hip Hop" });
            musicalGroups.Add(new MusicalGroup { ID = 7, Name = "Angry Flubber", Genre = "Rock" });
            musicalGroups.Add(new MusicalGroup { ID = 41, Name = "Goop", Genre = "Alternative" });
            musicalGroups.Add(new MusicalGroup { ID = 9, Name = "Fingernail", Genre = "Rock" });
            return musicalGroups;
        }
    }
}
