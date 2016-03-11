using Calorie_Counter.ViewModels;
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
using Сalorie_Сounter.DataBase;

namespace Сalorie_Сounter
{
    public partial class MainWindow : Window
    {
        MainWindowViewModel _viewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow window = new AddItemWindow();
            window.Closed += Window_Closed;
            window.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _viewModel.GetDailyInfo((DateTime)datePicker.SelectedDate);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.GetDailyInfo((DateTime)datePicker.SelectedDate);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EatingHistoryItem item = dataGrid.SelectedItem as EatingHistoryItem;
            if (item != null)
                _viewModel.DeleteItem(item);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
