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

namespace Snippet5_25
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            // Retrieve two disparate data sets            
            List<MusicalGroup> groups = MusicalGroup.FindAll();
            XElement albumsXML = XElement.Load("Albums.xml");

            // Get all of the albums for a specific genre
            string genre = "Rock";
            var rockAlbums =
              from rockGroup in groups
              join album in albumsXML.Elements() on
                new { GroupID = rockGroup.ID } equals
                new
                {
                    GroupID =
                        Convert.ToInt32(album.Attribute("ArtistID").Value)
                }
              where
                rockGroup.Genre == genre
              orderby
                rockGroup.Name,
                Convert.ToDateTime(album.Element("ReleaseDate").Value)
              select new Result
              {
                  Artist = rockGroup.Name,
                  Album = album.Element("Name").Value,
                  ReleaseDate = Convert.ToDateTime(album.Element("ReleaseDate").Value)
              };

            myDataGrid.ItemsSource = rockAlbums;
        }
    }

    public class Result
    {
        public string Artist { get; set; }
        public string Album { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
