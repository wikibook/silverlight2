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

using System.Reflection;

namespace Snippet11_26
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            RequestContent();
        }

        private void RequestContent()
        {
            Uri address = new Uri("http://www.silverlightinaction.com/MyClassLibrary.dll");       

            WebClient webClient = new WebClient();
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
            webClient.OpenReadAsync(address);                                       
        }

        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            AssemblyPart assemblyPart = new AssemblyPart();                        
            Assembly assembly = assemblyPart.Load(e.Result);                       

            object myClass = assembly.CreateInstance("MyClassLibrary.MyClass");    
            object result = myClass.GetType().InvokeMember("GetCurrentTime", BindingFlags.InvokeMethod, null, myClass, null);   
            myTextBlock.Text = Convert.ToString(result);                           
        }
    }
}
