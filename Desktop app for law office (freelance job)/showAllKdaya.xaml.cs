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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project
{
    /// <summary>
    /// Interaction logic for showAllKdaya.xaml
    /// </summary>
    public partial class showAllKdaya : UserControl
    {
		Context context=new Context();
		Users CurrentUser = new Users();
		ImagesCases Images = new ImagesCases();

		public showAllKdaya(Users _CurrentUser)
        {
            InitializeComponent();
			CurrentUser= _CurrentUser;
			myDataGrid.AutoGenerateColumns = false;
			List<Case> cases = context.Case.Where(e => e.IsDeleted == false).ToList();
			myDataGrid.ItemsSource =cases;
		}
		public showAllKdaya()
		{
			InitializeComponent();
			
			myDataGrid.AutoGenerateColumns = false;
			List<Case> cases = context.Case.Where(e => e.IsDeleted == false).ToList();
			myDataGrid.ItemsSource = cases;
		}



		private void myDataGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
		{
			Case item = (Case)myDataGrid.SelectedItem;
	
			if (item != null)
			{
				
				MainWindow window = new MainWindow(CurrentUser);
				window.Content = new ShowSelectedCaseInfo(item, CurrentUser);
				window.ShowDialog();
			}
			
		}

		

		private void Searchbtn_Click(object sender, RoutedEventArgs e)
		{
			string inputValue= SearchTextBox.Text;
			string stringInput = inputValue;
			List<Case> ResultWithCaseName= context.Case.Where(s => s.Name == inputValue && s.IsDeleted == false).ToList();
			List<Case> ResultWithClientName = context.Case.Where(s => s.ClientName == inputValue && s.IsDeleted == false).ToList();
			List<Case> ResultWithDateValue = new List<Case>();

			List<Case> ResultWithSerialNumber=new List<Case>();
			List<Case> ResultWithCaseNumber = new List<Case>();
			bool success = int.TryParse(stringInput, out int integerInput);
			if (success)
			{
				ResultWithSerialNumber = context.Case.Where(s => s.SerialNumber == integerInput&&s.IsDeleted==false).ToList();
				ResultWithCaseNumber= context.Case.Where(s => s.CaseNumber == integerInput && s.IsDeleted == false).ToList();

			}

			bool Result = DateTime.TryParse(stringInput, out DateTime date);
			if (Result)
			{
				ResultWithDateValue = context.Case.Where(s => s.DateCreated == date && s.IsDeleted == false).ToList();
			}

			if (ResultWithCaseName.Count > 0)
			{
				myDataGrid.ItemsSource = ResultWithCaseName;
			}
			else if(ResultWithSerialNumber.Count > 0)
			{
				myDataGrid.ItemsSource = ResultWithSerialNumber;
			}
			else if(ResultWithDateValue.Count>0)
			{
				myDataGrid.ItemsSource = ResultWithDateValue;
			}
			else if(ResultWithClientName.Count>0)
			{
				myDataGrid.ItemsSource= ResultWithClientName;
			}
			else if(ResultWithCaseNumber.Count>0)
			{
				myDataGrid.ItemsSource = ResultWithCaseNumber;
			}
			else
			{
				MessageBox.Show("عفوا لا يوجد بيانات لهذا البحث");
				myDataGrid.ItemsSource=null;
			}
			
		}

		private void AddCaseBtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow window = new MainWindow();
			window.Content = new AddNewKadya(CurrentUser);
			window.Show();
		}

		private void ShowAllCasesBtn_Click(object sender, RoutedEventArgs e)
		{
			List<Case> cases = context.Case.Where(e => e.IsDeleted == false).ToList();
			if(cases.Count > 0)
			{
				myDataGrid.ItemsSource = cases;

			}
			else
			{
				MessageBox.Show("عفوا لا يوجد بيانات لعرضها");
				myDataGrid.ItemsSource=null;
			}
		}

		

		private void DeleteBtn_Click(object sender, RoutedEventArgs e)
		{
			Case selectedCase=(Case) myDataGrid.SelectedItem;
			if(selectedCase != null)
			{
				selectedCase.IsDeleted = true;
				context.SaveChanges();
				List<Case> cases = context.Case.Where(e => e.IsDeleted == false).ToList();
				myDataGrid.ItemsSource = cases;
				Case_User case_User = new Case_User();
				case_User.UsersId = CurrentUser.Id;
				case_User.CaseId = selectedCase.Id;
				case_User.Action = "قام بالحذف";
				context.CaseUser.Add(case_User);
				context.SaveChanges();
			}
			else
			{
				MessageBox.Show("الرجاء اختيار القضية المراد حذفها");
			}
		
		}
	}
}
