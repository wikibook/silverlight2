using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Snippet4_31
{
    public partial class Page : UserControl
    {
        private Stroke stroke = null;

        public Page()
        {
            InitializeComponent();

            myInkPresenter.MouseLeftButtonDown += new MouseButtonEventHandler(ipMouseLeftButtonDown);
            myInkPresenter.MouseMove += new MouseEventHandler(ipMouseMove);
            myInkPresenter.MouseLeftButtonUp += new MouseButtonEventHandler(ipMouseLeftButtonUp);
            myInkPresenter.MouseLeave += new MouseEventHandler(ipMouseLeave);
        }

        public void ipMouseMove(object sender, MouseEventArgs e)
        {
            if (this.stroke != null)
            {
                this.stroke.StylusPoints.Add(
                e.StylusDevice.GetStylusPoints(myInkPresenter));
            }
        }

        public void ipMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            myInkPresenter.CaptureMouse();

            this.stroke = new Stroke(e.StylusDevice.GetStylusPoints(myInkPresenter));
            this.stroke.DrawingAttributes.Color = Colors.Blue;
            this.stroke.DrawingAttributes.OutlineColor = Colors.White;
            myInkPresenter.Strokes.Add(stroke);
        }

        public void ipMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            myInkPresenter.ReleaseMouseCapture();
            this.stroke = null;
        }

        public void ipMouseLeave(object sender, MouseEventArgs e)
        {
            myInkPresenter.ReleaseMouseCapture();
            this.stroke = null;
        }
    }
}
