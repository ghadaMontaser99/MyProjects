using System;
using System.Collections.Generic;
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
	/// Interaction logic for AccessByAdmin2.xaml
	/// </summary>
	public partial class AccessByAdmin2 : UserControl
	{
		public AccessByAdmin2()
		{
			InitializeComponent();
		}

		private void loginBtn_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show(passwordBox1.Password.ToString());
			if(passwordBox1.Password.ToString()=="123456")
			{
				MainWindow window = new MainWindow();
				window.Content = new AddNewUser();
				window.Show();
				Window parentWindow = (Window)this.Parent;
				parentWindow.Close();
			}
			else
			{
				MessageBox.Show("الرجاء ادخال الرقم السري بشكل صحيح");
			}
		
		}
    }
}
