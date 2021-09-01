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

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for CollecrctionBinding.xaml
    /// </summary>
    public partial class CollecrctionBinding : Window
    {
        public CollecrctionBinding()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ProductModel productModel = new ProductModel();
            lstItems.DataContext = productModel.GetProductModels();
        }

        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainGrid.DataContext = lstItems.SelectedItem as ProductModel;
        }
    }
}
