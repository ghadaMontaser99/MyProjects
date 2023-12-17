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
using System.Drawing;
using System.IO;
using Xceed.Wpf.AvalonDock.Layout;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace project
{
    /// <summary>
    /// Interaction logic for ShowSelectedCaseInfo.xaml
    /// </summary>
    public partial class ShowSelectedCaseInfo : UserControl
    {
        Case Case;
		Context context=new Context();
		Users CurrentUser=new Users();
		ImagesCases ImagesCases;
		public ObservableCollectionListSource<string> ImagesCasesSource { set; get; }=new ObservableCollectionListSource<string>() { "rrr","sss","wwww"};
		List<int> imagesID=new List<int>();
		public ShowSelectedCaseInfo()
        {
            InitializeComponent();
        }
		public ShowSelectedCaseInfo(Case selectedCase,Users _CurrentUser)
		{
			InitializeComponent();
			CurrentUser =_CurrentUser;
			Case =selectedCase;
			Case =selectedCase;
			CaseSerialNumber.Text = Case.SerialNumber.ToString();
			CaseName.Text = Case.Name.ToString();
			ClientName.Text = Case.ClientName.ToString();
			Description.Text = Case.Description.ToString();
			Notes.Text = Case.Notes.ToString();
			DateCreated.Text = Case.DateCreated.ToString();
			CaseNumber.Text=Case.CaseNumber.ToString();
			imagesID = context.ImagesCases.Where(e => e.CaseId== selectedCase.Id).Select(e=>e.id).ToList();
			CreateATextBox(imagesID.Count);
		}

		private void CreateATextBox(int num)
		{
            foreach (var item in imagesID)
            {
			
				Button btn = new Button();

				btn.Height = 80;

				btn.Width = 80;
				int index = item;
				btn.Name = "btn" + item.ToString();
				ImagesCases = context.ImagesCases.FirstOrDefault(e => e.id == item);

				byte[] byteArray = ImagesCases.CaseImage;
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
				btn.Click += new RoutedEventHandler((sender, e) => {CallMeClick(sender, e, index); });

				yyy.Children.Add(btn);
			}
            
				
			
		}


		protected void CallMeClick(object sender, RoutedEventArgs e ,int imageId)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Content = new SelectedImage(imageId);
			mainWindow.Show();
		}

		

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void UpdateBtn_Click(object sender, RoutedEventArgs e)
		{
			
			CaseName.IsReadOnly=false;
			CaseSerialNumber.IsReadOnly = false;
			CaseNumber.IsReadOnly = false;
			ClientName.IsReadOnly = false;
			Description.IsReadOnly = false;
			Notes.IsReadOnly = false;
			DateCreated.IsEnabled=true;
			SaveBtnn.Visibility = Visibility.Visible;

		}

		private void SaveBtn_Click(object sender, RoutedEventArgs e)
		{
			if (CaseName.Text!=null&& CaseSerialNumber.Text!=null&& CaseNumber.Text!=null&&
				ClientName.Text!=null&& Description.Text!=null&& Notes.Text != null
				&& DateCreated.Text != null)
			{
				Case.Name = CaseName.Text;
				Case.SerialNumber = int.Parse(CaseSerialNumber.Text);
				Case.CaseNumber = int.Parse(CaseNumber.Text);
				Case.ClientName = ClientName.Text;
				Case.Description = Description.Text;
				Case.Notes = Notes.Text;
				Case.DateCreated = DateTime.Parse(DateCreated.Text);

				context.SaveChanges();
				MessageBox.Show("تم التعديل بنجاح");
				Case_User case_User = new Case_User();
				case_User.CaseId = Case.Id;
				case_User.UsersId = CurrentUser.Id;
				case_User.Action = "قام بالتعديل";
				context.CaseUser.Add(case_User);
				context.SaveChanges();
			}
			else
			{
				MessageBox.Show("قم بأدخال جميع البيانات");
			}


		}

		private void UploadImageBtn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
