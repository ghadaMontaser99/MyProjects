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
    /// Interaction logic for AccessByAdminn.xaml
    /// </summary>
    public partial class AccessByAdminn : UserControl
    {
		Users CurrentUser=new Users();

		public AccessByAdminn(Users _CurrentUser)
        {
            InitializeComponent();
			CurrentUser = _CurrentUser;


		}

		private void loginBtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow window = new MainWindow();
			window.Content = new AddNewKadya(CurrentUser);
			window.Show();
			Window parentWindow = (Window)this.Parent;
			parentWindow.Close();
		
		}
	}
}
