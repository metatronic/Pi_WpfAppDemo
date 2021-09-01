using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for NetStockForm.xaml
    /// </summary>
    public partial class NetStockForm : Window
    {
        NorthwindEntities db = null;
        public NetStockForm()
        {
            InitializeComponent();
            db = new NorthwindEntities();
            MainGrid.DataContext = db.Products.ToList();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
