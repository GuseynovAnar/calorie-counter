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
using System.Windows.Shapes;
using Сalorie_Сounter.DataBase;

namespace Сalorie_Сounter
{
    public partial class NewItemWindow : Window
    {
        NewItemWindowViewModel _viewModel = new NewItemWindowViewModel();
        public NewItemWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dish dish = new Dish
                {
                    Category = (Category)this.Category.SelectedItem,
                    Name = this.Name.Text,
                    Calories = float.Parse(this.Calories.Text),
                    Proteins = float.Parse(this.Proteins.Text),
                    Fats = float.Parse(this.Fats.Text),
                    Carbohydrates = float.Parse(this.Carbohydrates.Text)
                };
                _viewModel.AddNewItem(dish);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Проверьте правильность введённых данных");
            }
        }
    }
}
