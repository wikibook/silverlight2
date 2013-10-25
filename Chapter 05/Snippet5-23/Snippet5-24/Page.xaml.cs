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

using System.Xml.Linq;

namespace Snippet5_24
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            // Load all of the orders from a data source
            XElement element = XElement.Load("Albums.xml");
            string artistID = "7";

            // Retrieve all of the albums by the artist
            var albums =
              from album in element.Descendants("Album")
              where (string)album.Attribute("ArtistID") == artistID
              orderby (DateTime)(album.Element("ReleaseDate")) ascending
              select new Album
              {
                  ArtistID =
                    Convert.ToInt32(album.Attribute("ArtistID").Value),
                  Name = album.Element("Name").Value,
                  ReleaseDate =
                    Convert.ToDateTime(album.Element("ReleaseDate").Value),
              };

            foreach (Album album in albums)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = album.Name;
                myListBox.Items.Add(item);
            }
        }
    }
}
