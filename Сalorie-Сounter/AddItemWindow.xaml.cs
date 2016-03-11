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
using System.Windows.Shapes;
using Сalorie_Сounter.DataBase;
using Сalorie_Сounter.ViewModels;

namespace Сalorie_Сounter
{
    public partial class AddItemWindow : Window
    {
        AddItemWindowViewModel _viewModel = new AddItemWindowViewModel();
        public AddItemWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
            _viewModel.GetAllDishes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dish selectedDish = DishesData.SelectedItem as Dish;
            Button button = sender as Button;
            Grid grid = button.Parent as Grid;
            TextBox textBox = grid.Children[1] as TextBox;
            if (selectedDish != null)
            {
                try
                {
                    _viewModel.AddDishToHistory(selectedDish, float.Parse(textBox.Text));
                    MessageBox.Show(string.Format("Добавлено: {0} {1}г", selectedDish.Name, textBox.Text));
                }
                catch
                {
                    MessageBox.Show("Проверьте введённые данные");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NewItemWindow window = new NewItemWindow();
            window.Closed += Window_Closed;
            window.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _viewModel.GetAllDishes();
        }
    }
}
