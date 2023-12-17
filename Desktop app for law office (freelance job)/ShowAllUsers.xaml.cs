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
using static Azure.Core.HttpHeader;

namespace project
{
    /// <summary>
    /// Interaction logic for ShowAllUsers.xaml
    /// </summary>
    public partial class ShowAllUsers : UserControl
    {
		Context context	= new Context();
		Users CurrentUser = new Users();
        public ShowAllUsers(Users _CurrentUser)
        {
            InitializeComponent();
			CurrentUser= _CurrentUser;
			myDataGrid.AutoGenerateColumns = false;
			List<Users> Users = context.Users.Where(e => e.IsDeleted == false).ToList();
			myDataGrid.ItemsSource = Users;
		}

		private void AddUser_Click(object sender, RoutedEventArgs e)
		{
			MainWindow window = new MainWindow();
			window.Content = new AccessByAdmin2();
			window.Show();
		}

		private void DeleteBtn_Click(object sender, RoutedEventArgs e)
		{
			Users selectedUser = (Users)myDataGrid.SelectedItem;
			if (selectedUser != null)
			{
				selectedUser.IsDeleted = true;
				context.SaveChanges();
				List<Users> Users = context.Users.Where(e => e.IsDeleted == false).ToList();
				myDataGrid.ItemsSource = Users;
			}
			else
			{
				MessageBox.Show("الرجاء اختيار الستخدم المراد حذفه");
			}
		}

		private void myDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Users item = (Users)myDataGrid.SelectedItem;
			if (item != null)
			{
				MessageBox.Show(item.UserName.ToString());
				MainWindow window = new MainWindow(CurrentUser);
				window.Content = new UpdateUser(item, CurrentUser); // AddNewKadya();
				window.Show();
			}
		
		}
	}
}
