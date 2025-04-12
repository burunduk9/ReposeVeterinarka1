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
using VeterinarkaProject.ADOApp;

namespace VeterinarkaProject.WindowApp
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public static List<Animal> animals { get; set; }
        public AddWindow()
        {
            InitializeComponent();
            animals = new List<Animal>(App.Connection.Animal);
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (/*comboAnimal.SelectedItem != null*/txtAnimal.Text != "" && txtVrach.Text != "" && dateDate.SelectedDate != null/*txtDate.DataContext != null*/ && txtComment.Text != "")
            {
                Priem priem = new Priem()
                {
                    //id_animal = (comboAnimal.SelectedItem as Animal).id,
                    id_animal = Convert.ToInt32(txtAnimal.Text),
                    id_vrach = Convert.ToInt32(txtVrach.Text),

                    date_priem = dateDate.SelectedDate, /*Convert.ToDateTime(txtDate.DataContext),*/
                    comment = txtComment.Text,
                    is_delete = false
                };
                App.Connection.Priem.Add(priem);
                App.Connection.SaveChanges();
                MessageBox.Show("все норм");
                this.Close();
            }
            else
            {
                MessageBox.Show("не все норм");
            }
        }
    }
}
