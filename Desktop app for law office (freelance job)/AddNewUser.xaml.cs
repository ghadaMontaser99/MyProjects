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
    /// Interaction logic for AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : UserControl
    {
        Context context=new Context();
        public AddNewUser()
        {
            InitializeComponent();
        }

		private void AddUser_Click(object sender, RoutedEventArgs e)
		{
            if(UserName.Text!=null&& UserPhoneNumber.Text!=null&& Password.Text!=null)
            {
				Users NewUser = new Users();
				NewUser.UserName = UserName.Text;
				NewUser.PhoneNumber = UserPhoneNumber.Text;
				NewUser.Passwored = Password.Text;
				context.Users.Add(NewUser);
				context.SaveChanges();
                MessageBox.Show("تم الاضافة بنجاح");
			}
            else
            {
				MessageBox.Show("قم بأدخال جميع البيانات");
			}
            


		}
    }
}
