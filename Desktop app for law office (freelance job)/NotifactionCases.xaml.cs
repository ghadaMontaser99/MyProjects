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
	/// Interaction logic for NotifactionCases.xaml
	/// </summary>
	public partial class NotifactionCases : UserControl
	{
		Context context=new Context();
		List<CourtDates> CourtDatesList = new List<CourtDates>();
		public List<Case> cases = new List<Case>();
		Users CurrentUser = new Users();
		public NotifactionCases(Users CurrentUser)
		{
			InitializeComponent();
			this.CurrentUser = CurrentUser;
			myDataGrid.AutoGenerateColumns = false;
			CourtDatesList.Clear();
			var courtDates = context.CourtDates.Where(d => d.DateTime > DateTime.Now && d.IsDeleted == false).ToList();
			foreach (var item in courtDates)
			{
				if (item.DateTime.Hour >= DateTime.Now.Hour && item.DateTime.Hour <= DateTime.Now.Hour + 1)
				{
					Case Case = new Case();
					Case_CourtDates data = context.Case_Court_dates.Include("CourtDates").Include("Case").FirstOrDefault(e => e.IsDeleted == false&&e.Court_DatesId==item.Id);
					Case = context.Case.FirstOrDefault(e => e.Id == data.CaseID);
					cases.Add(Case);
					CourtDatesList.Add(item);
				}
			}

			myDataGrid.ItemsSource = cases;


		}

		private void myDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Case item = (Case)myDataGrid.SelectedItem;

			if (item != null)
			{
				
				MainWindow window = new MainWindow(CurrentUser);
				window.Content = new ShowSelectedCaseInfo(item, CurrentUser);
				window.Show();
			}
		}
	}
}
