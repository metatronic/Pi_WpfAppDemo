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
    /// Interaction logic for EFCRUDForm.xaml
    /// </summary>
    public partial class EFCRUDForm : Window
    {
        enum ButtonState
        {
            Default,
            Add,
            Edit
        }
        ButtonState btState;
        NorthwindEntities db = null;
        ObservableCollection<Product> productCollection;
        public Product this[int i]
        {
            get => productCollection.Single(p => p.ProductID == i);
            set
            {
                Product p = productCollection.Single(pro => pro.ProductID == i);
                p = value;
            }
        }
        public EFCRUDForm()
        {
            InitializeComponent();
            db = new NorthwindEntities();
        }

        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainGrid.DataContext = lstItems.SelectedItem as Product;
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            productCollection = new ObservableCollection<Product>(db.Products.OrderByDescending(p => p.ProductID));
            lstItems.DataContext = productCollection;
            txtProductId.IsReadOnly = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            productCollection.Add(new Product());
            lstItems.SelectedIndex = productCollection.Count - 1;
            txtProductId.Text = "0";
            txtProductName.Focus();

            btnAdd.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            lstItems.IsEnabled = false;
            btState = ButtonState.Add;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Product product = lstItems.SelectedItem as Product;
            db.Products.Add(product);
            db.SaveChanges();
            MessageBox.Show("Record inserted");
            lstItems.SelectedIndex = 0;
            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            lstItems.IsEnabled = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (btState == ButtonState.Add)
            {
                Product product = lstItems.SelectedItem as Product;
                productCollection.Remove(product);
            }
            else
            {
                Product product = lstItems.SelectedItem as Product;
                product = db.Products.Where(p => p.ProductID == product.ProductID).Single();
            }
            btState = ButtonState.Default;
            lstItems.SelectedIndex = 0;
            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            lstItems.IsEnabled = true;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Product product = lstItems.SelectedItem as Product;
            db.Products.Remove(product);
            productCollection.Remove(product);
            db.SaveChanges();
        }
    }
}
