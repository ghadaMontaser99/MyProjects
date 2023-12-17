
using AdonisUI.Controls;
using Microsoft.Extensions.DependencyInjection;
using project.models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Users CurrentUser =new Users();
		List<CourtDates> CourtDatesList = new List<CourtDates>();

		Context context = new Context();
		public string countter { set; get; }
		public string borderVisibilty { set; get; } = "Hidden";

		public delegate void UpdateTextDelegate(string text);
		public delegate void UpdateBorderDelegate(Visibility visibility);
		
		public MainWindow()
		{
			InitializeComponent();
		}
	
		
		public MainWindow(Users _CurrentUser)
		{
			//TextBlock nnn = this.FindName("Counter") as TextBlock;
			//Border border = this.FindName("NotificationBorder") as Border;

			NotifactionCases ee = new NotifactionCases(CurrentUser);
		//	c= ee.cases.Count;
			InitializeComponent();
			CurrentUser = _CurrentUser;
			UserNameHeader.Text = CurrentUser.UserName;
			Task.Run(async () => {
				int loopCounter = 0;
				while(true)
				{
				CourtDatesList.Clear();
			
				var courtDates = context.CourtDates.Where(d => d.DateTime > DateTime.Now && d.IsDeleted == false).ToList();
				foreach (var item in courtDates)
				{
					if (item.DateTime.Hour >= DateTime.Now.Hour && item.DateTime.Hour <= DateTime.Now.Hour + 1)
					{
						CourtDatesList.Add(item);
					}				
				}
				if (CourtDatesList.Count>0)
				{
						loopCounter++;
						UpdateBorder(Visibility.Visible);
						UpdateText(CourtDatesList.Count.ToString());
						if( loopCounter==10)
						{
							//System.Windows.MessageBox.Show("لديك عدد " + CourtDatesList.Count + " معاد قضية");
							//loopCounter = 0;
						}
				}
				else
				{
						UpdateBorder(Visibility.Hidden);
						UpdateText(CourtDatesList.Count.ToString());
				}
					Thread.Sleep(1000);
				}
			});


		}

		private void UpdateText(string text)
		{
			if (Counter.Dispatcher.CheckAccess())
			{
				Counter.Text = text;
			}
			else
			{
				UpdateTextDelegate updateTextDelegate = new UpdateTextDelegate(UpdateText);
				Counter.Dispatcher.Invoke(updateTextDelegate, text);
			}
		}
		private void UpdateBorder(Visibility visibility)
		{
			if (NotificationBorder.Dispatcher.CheckAccess())
			{
				NotificationBorder.Visibility = visibility;	
			}
			else
			{
				UpdateBorderDelegate updateBorderDelegate = new UpdateBorderDelegate(UpdateBorder);
				NotificationBorder.Dispatcher.Invoke(updateBorderDelegate, visibility);
			}
		}
		private void ReportBtn_Click(object sender, RoutedEventArgs e)
		{
			Elkadaya.Content = new showAllKdaya(CurrentUser);
		}

		private void ReportBtssn_Click(object sender, RoutedEventArgs e)
		{
			Elkadaya.Content = new allUsersUpdates();
		}

	

		private void AllUsersBtn_Click(object sender, RoutedEventArgs e)
		{
			Elkadaya.Content = new ShowAllUsers(CurrentUser);
		}

		private void logOutBtn_Click(object sender, RoutedEventArgs e)
		{
			LoginForm log = new LoginForm();
			log.Show();
			this.Close();
			
        }

		private void CreateAppointments_Click(object sender, RoutedEventArgs e)
		{
			Elkadaya.Content = new CreateAppointments(CurrentUser);
		}

		private void NotificationBttn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow window = new MainWindow();
			NotifactionCases notifactionCases = new NotifactionCases(CurrentUser);

			window.Content = notifactionCases;
			window.Show();
			
		}
	}
}
