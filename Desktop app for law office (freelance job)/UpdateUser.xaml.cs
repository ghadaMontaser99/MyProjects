using project.models;
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
	/// Interaction logic for UpdateUser.xaml
	/// </summary>
	public partial class UpdateUser : UserControl
	{
		Users SelectedUser;
		Users CurrentUser = new Users();
		Context context = new Context();
		public UpdateUser(Users _SelectedUser,Users _CurrentUser)
		{
			
			InitializeComponent();
			CurrentUser = _CurrentUser;
			SelectedUser = _SelectedUser;
			Password.Text = _SelectedUser.Passwored.ToString();
			UserPhoneNumber.Text = _SelectedUser.PhoneNumber.ToString();
			UserName.Text = _SelectedUser.UserName.ToString();
		}

		private void UpdateBtn_Click(object sender, RoutedEventArgs e)
		{
			if(Password.Text!=null&& UserPhoneNumber.Text!=null&& UserName.Text!=null)
			{
				ShowAllUsers showAllUsers = new ShowAllUsers(CurrentUser);
			
				SelectedUser.Passwored = Password.Text;
				SelectedUser.PhoneNumber = UserPhoneNumber.Text;
				SelectedUser.UserName = UserName.Text;
				context.Update(SelectedUser);
				context.SaveChanges();
				MessageBox.Show("تم التعديل بنجاح");
				
			}
			else
			{
				MessageBox.Show("قم بأدخال جميع البيانات");
			}
		
		}
	}
}
