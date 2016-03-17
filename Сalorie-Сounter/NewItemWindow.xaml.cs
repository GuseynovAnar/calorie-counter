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
                    Category = (Category)this.comboBox.SelectedItem,
                    Name = this.textBoxName.Text,
                    Calories = float.Parse(this.textBoxCalories.Text),
                    Proteins = float.Parse(this.textBoxProteins.Text),
                    Fats = float.Parse(this.textBoxFats.Text),
                    Carbohydrates = float.Parse(this.textBoxCarbohydrates.Text)
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
