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

using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Snippet5_15
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            List<Emoticon> emoticons = GetEmoticons();
            myDataGrid.ItemsSource = emoticons;
        }

        private List<Emoticon> GetEmoticons()
        {
            List<Emoticon> emoticons = new List<Emoticon>();
            emoticons.Add(new Emoticon("Smiley Face", "http://www.silverlightinaction.com/smiley.png", ": )"));
            emoticons.Add(new Emoticon("Straight Face", "http://www.silverlightinaction.com/straight.png", ": |"));
            emoticons.Add(new Emoticon("Angry Face", "http://www.silverlightinaction.com/angry.png", ": <"));
            emoticons.Add(new Emoticon("Sad Face", "http://www.silverlightinaction.com/frown.png", ": ("));
            emoticons.Add(new Emoticon("Sick", "http://www.silverlightinaction.com/sick.png", "> <"));
            return emoticons;
        }
    }

    public class Emoticon : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                UpdateProperty("Name");
            }
        }

        private string keys = string.Empty;
        public string Keys
        {
            get { return keys; }
            set
            {
                keys = value;
                UpdateProperty("Keys");
            }            
        }

        private BitmapImage icon = null;
        public BitmapImage Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                UpdateProperty("Icon");
            }
        }

        public Emoticon(string _name, string _imageUrl, string _keys)
        {
            name = _name;
            icon = new BitmapImage(new Uri(_imageUrl));
            keys = _keys;
        }

        public void UpdateProperty(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
