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

using System.IO.IsolatedStorage;
using System.Text;

namespace Snippet11_7
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            // Set the rectangle sizes accordingly
            using (IsolatedStorageFile isoFile =  IsolatedStorageFile.GetUserStoreForApplication())
            {
                // Delete the binary file if it exists
                if (isoFile.FileExists("binaryFile1"))
                    isoFile.DeleteFile("binaryFile1");

                // Create some random bytes to be written to a binary file                                
                Random random = new Random();
                int size = random.Next(Convert.ToInt32(isoFile.Quota)-1);
                string randomString = CreateRandomString(size);

                // Write the random bytes to a binary file in the isolated storage area.
                IsolatedStorageFileStream fileStream = isoFile.CreateFile("binaryFile1");
                byte[] bytes = System.Text.Encoding.Unicode.GetBytes(randomString);
                fileStream.Write(bytes, 0, randomString.Length);
                fileStream.Close();

                double usedSpace = isoFile.Quota - isoFile.AvailableFreeSpace;        
                maximumRectangle.Width = (isoFile.Quota / 10024) * 2;                 
                currentRectangle.Width = (usedSpace / 10024) * 2;                     
            }
        }

        private string CreateRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            
            char c;
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(c);
            }
            return builder.ToString();
        }
    }
}
