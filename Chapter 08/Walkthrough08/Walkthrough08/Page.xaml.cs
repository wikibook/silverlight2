using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Walkthrough08
{
	public partial class Page : UserControl
	{
        // The transformation to increase/decrease the ball by          
        private ScaleTransform scaleTransform = new ScaleTransform();

        // The transformation to rotate the ball by
        private RotateTransform rotateTransform = new RotateTransform();


		public Page()
		{
			// Required to initialize variables
			InitializeComponent();

            // Initialize the transformations
            InitializeScaleTransform();
            InitializeRotateTransform();
            InitializeTransformGroup();            
		}

        private void InitializeScaleTransform()
        {
            // Set the inital scale at nothing
            scaleTransform.ScaleX = 1.0;
            scaleTransform.ScaleY = 1.0;

            // Put the focal point at the center of the ball
            scaleTransform.CenterX = 50.0;
            scaleTransform.CenterY = 50.0;
        }

        private void InitializeRotateTransform()
        {
            rotateTransform.Angle = 0.0;
            rotateTransform.CenterX = 50.0;
            rotateTransform.CenterY = 50.0;
        }

        private void InitializeTransformGroup()
        {
            TransformGroup transformGroup = new TransformGroup();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(scaleTransform);
            myEllipse.RenderTransform = transformGroup;
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)  // A-Key (Left)            
                rotateTransform.Angle -= 3.0;
            else if (e.Key == Key.D)  // D-Key (Right)            
                rotateTransform.Angle += 3.0;
            else if (e.Key == Key.S)  // S-Key (Down)
            {
                scaleTransform.ScaleX *= .97;
                scaleTransform.ScaleY *= .97;
            }
            else if (e.Key == Key.W)  // W-Key (Up)
            {
                scaleTransform.ScaleY *= 1.03;
                scaleTransform.ScaleX *= 1.03;
            }
            else if (e.Key == Key.R)  // R-Key (Reset)
            {
                InitializeScaleTransform();
                InitializeRotateTransform();
            }
        }
	}
}