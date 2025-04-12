using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using VeterinarkaProject.ADOApp;

namespace VeterinarkaProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static List<Priem> priemchik { get; set; }
        public MainPage()
        {
            InitializeComponent();
            priemchik = new List<Priem>(App.Connection.Priem.Where(u => u.is_delete == false).ToList());
        }

        private void Searchik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchikLine = Searchik.Text.Trim();
            if(searchikLine == "")
            {
                ListPriem.ItemsSource = priemchik.ToList();
            }
            else
            {
                ListPriem.ItemsSource = priemchik.Where(u => u.Animal.name == searchikLine).ToList();
            }
        }

        private void btnAddPriem_Click(object sender, RoutedEventArgs e)
        {
            WindowApp.AddWindow addWindow = new WindowApp.AddWindow();
            addWindow.Show();
        }

        private void btnReduct_Click(object sender, RoutedEventArgs e)
        {
            WindowApp.ReductWindow reductWindow = new WindowApp.ReductWindow();
            reductWindow.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var priemka1 = (sender as Button).DataContext as Priem;
            if (priemka1 != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"уверены в удалении", "press f", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    priemka1.is_delete = true;
                    App.Connection.SaveChanges();
                    ListPriem.ItemsSource = new List<Priem>(App.Connection.Priem.Where(u => u.is_delete == false).ToList());
                }
            }
            else
            {
                MessageBox.Show("такого нет");
            }
        }
    }
}
