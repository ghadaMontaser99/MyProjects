using project.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project
{
    /// <summary>
    /// Interaction logic for SelectedImage.xaml
    /// </summary>
    public partial class SelectedImage : UserControl
    {
        ImagesCases ImagesCases;
        int imgaeid =0;
		Context context = new Context();      
		public SelectedImage(int imagesCases)
        {
            InitializeComponent();
			this.imgaeid = imagesCases;
			ImagesCases = context.ImagesCases.FirstOrDefault(e => e.id == imgaeid);

			byte[] byteArray = ImagesCases.CaseImage;// your byte array here
			BitmapImage newImage = new BitmapImage();
			using (MemoryStream stream = new MemoryStream(byteArray))
			{
				newImage.BeginInit();
				newImage.CacheOption = BitmapCacheOption.OnLoad;
				newImage.StreamSource = stream;
				newImage.EndInit();
			}
			ShowImage.Source = newImage;
			ShowImage.Stretch = System.Windows.Media.Stretch.Uniform;
			
		}

    }
}
