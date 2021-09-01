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
    /// Interaction logic for ObservableCollectionDemo.xaml
    /// </summary>
    public partial class ObservableCollectionDemo : Window
    {
        ObservableCollection<Person> personList;
        public ObservableCollectionDemo()
        {
            InitializeComponent();
            personList = new ObservableCollection<Person>()
            {
                new Person(){ FirstName="Pran", LastName="Saha", City="Mumbai"},
                new Person(){ FirstName="Pratik", LastName="Saha", City="Mumbai"}
            };
            lstNames.DataContext = personList;
            lblCount.Content = personList.Count;
        }

        private void btnAddPErson_Click(object sender, RoutedEventArgs e)
        {
            personList.Add(new Person() { FirstName = txtFName.Text, LastName = txtLName.Text, City = txtCity.Text });
            txtFName.Text = "";
            txtLName.Text = "";
            txtCity.Text = "";

            lblCount.Content = personList.Count;
        }

        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
            
        }
    }
}
