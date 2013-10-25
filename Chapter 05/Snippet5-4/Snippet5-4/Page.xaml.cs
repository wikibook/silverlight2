using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Snippet5_4
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
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

        public Emoticon(string _name, string _imageUrl)
        {
            name = _name;
            icon = new BitmapImage(new Uri(_imageUrl));
        }

        public void UpdateProperty(string propertyName)                         
        {
            if (PropertyChanged != null )
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
            }
        }
    }
}
