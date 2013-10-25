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

using System.Xml;

namespace Snippet5_23
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            // Load all of the Albums from a data source
            XmlReader reader = XmlReader.Create("Albums.xml");
            string artistID = "7";

            // Retrieve all of the albums by the artist
            List<Album> albumsByArtist = new List<Album>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Album")
                    {
                        if (reader.GetAttribute("ArtistID") == artistID)
                        {
                            Album album = new Album();
                            album.ArtistID = Convert.ToInt32(artistID);

                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    string elementName = reader.Name;
                                    if (elementName == "Name")
                                        album.Name = reader.ReadElementContentAsString();
                                    else if (elementName == "ReleaseDate")
                                    {
                                        string releaseDate =
                                          reader.ReadElementContentAsString();
                                        album.ReleaseDate =
                                          Convert.ToDateTime(releaseDate);
                                    }
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    if (reader.Name == "Album")
                                    {
                                        albumsByArtist.Add(album);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (Album album in albumsByArtist)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = album.Name;
                myListBox.Items.Add(item);
            }
        }
    }
}
