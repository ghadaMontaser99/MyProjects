using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using project.models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System;
using System.Drawing;
using System.Windows.Media;
using System.Drawing;
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
using static System.Net.Mime.MediaTypeNames;

namespace project
{
    /// <summary>
    /// Interaction logic for AddNewKadya.xaml
    /// </summary>
    public partial class AddNewKadya : UserControl
    {
		Context context=new Context();
		Users CurrentUser = new Users();
		
		// Create a list of image file paths
		List<ImagesCases> image = new List<ImagesCases>();
		
		public AddNewKadya(Users _CurrentUser)
        {
            InitializeComponent();
			CurrentUser= _CurrentUser;

		}
	

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"; // Optional file extensions
			if (fileDialog.ShowDialog() == true)
			{

				ImagesCases imagesCases = new ImagesCases();
				SelectedImageName.Text = fileDialog.FileName;
				imagesCases.name = fileDialog.FileName;

				BitmapImage originalImage = new BitmapImage(new Uri(imagesCases.name));

				// Convert the image to a byte array
				byte[] byteArray;
				using (MemoryStream stream = new MemoryStream())
				{
					JpegBitmapEncoder encoder = new JpegBitmapEncoder();
					encoder.Frames.Add(BitmapFrame.Create(originalImage));
					encoder.Save(stream);
					byteArray = stream.ToArray();
					imagesCases.CaseImage = byteArray;
				}
				image.Add(new ImagesCases { name= imagesCases.name,CaseImage= imagesCases.CaseImage });

			}
			CreateATextBox(image.Count);

		}
		

		
		private void downloadBtn_Click(object sender, RoutedEventArgs e)
		{

		}

	

		private void OkBtn_Click_1(object sender, RoutedEventArgs e)
		{
			//if(CaseName.Text!=null&& CaseSerialNumber.Text!=null&& CaseNumber.Text!=null&&
			//	ClientName.Text!=null&& Description.Text!=null&& Notes.Text != null
			//	&& DateCreated.ToString()!=null)
			try
			{
				Case NewCase = new Case();
				NewCase.Name = CaseName.Text;
				NewCase.SerialNumber = int.Parse(CaseSerialNumber.Text);
				NewCase.CaseNumber = int.Parse(CaseNumber.Text);
				NewCase.ClientName = ClientName.Text;
				NewCase.Description = Description.Text;
				NewCase.Notes = Notes.Text;
				NewCase.DateCreated = DateTime.Parse(DateCreated.ToString());
				context.Case.Add(NewCase);
				NewCase.ImagesCasesList = null;
				context.SaveChanges();
				foreach(var item in image)
				{
					item.CaseId = NewCase.Id;
				}
				NewCase.ImagesCasesList = image;
				//context.ImagesCases.Add(imagesCases);
				context.SaveChanges();
				MessageBox.Show("تم الحفظ بنجاح");
				Clear();
				Case_User case_User = new Case_User();
				case_User.CaseId = NewCase.Id;
				case_User.UsersId = CurrentUser.Id;
				case_User.Action = "قام بالاضافة";
				context.CaseUser.Add(case_User);
				context.SaveChanges();
			}
			
			catch(Exception ex) 
			{
				MessageBox.Show("قم بأدخال جميع البيانات");
			}
			

		}




		private void CreateATextBox(int num)
		{
			int c = 0;
			yyy.Children.Clear();
			foreach (var item in image)
			{
				Button btn = new Button();
				btn.Height = 80;

				btn.Width = 80;
				string index = item.name;
				btn.Name = "btn" + c;
				byte[] byteArray = item.CaseImage;
				BitmapImage newImage = new BitmapImage();
				using (MemoryStream stream = new MemoryStream(byteArray))
				{
					newImage.BeginInit();
					newImage.CacheOption = BitmapCacheOption.OnLoad;
					newImage.StreamSource = stream;
					newImage.EndInit();
				}
				btn.Background = new ImageBrush(newImage);
				btn.Foreground = new SolidColorBrush(Colors.Black);

				yyy.Children.Add(btn);
				c++;
			}



		}


		protected void CallMeClick(object sender, RoutedEventArgs e, int imageId)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Content = new SelectedImage(imageId);
			mainWindow.Show();
		}

		private void Clear()
		{
			CaseName.Text=string.Empty;
			CaseSerialNumber.Text=string.Empty;
			CaseNumber.Text=string.Empty;
			ClientName.Text=string.Empty;
			Description.Text=string.Empty;
			DateCreated.SelectedDate = DateTime.Now;
			Notes.Text=string.Empty;
			SelectedImageName.Text=string.Empty;
			yyy.Children.Clear();
		}

		
	
	}
}
