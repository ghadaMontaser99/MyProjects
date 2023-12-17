using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for allUsersUpdates.xaml
    /// </summary>
    public partial class allUsersUpdates : UserControl
    {
        Context context=new Context();
        public allUsersUpdates()
        {
            InitializeComponent();
			myDataGrid.AutoGenerateColumns = false;
			var data= context.CaseUser.Include("Users").Include("Case").Where(e=>e.IsDeleted==false).ToList();
			myDataGrid.ItemsSource= data;
		}
    }
}
