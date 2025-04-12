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
using VeterinarkaProject.ADOApp;

namespace VeterinarkaProject.WindowApp
{
    /// <summary>
    /// Логика взаимодействия для ReductWindow.xaml
    /// </summary>
    public partial class ReductWindow : Window
    {
        public ReductWindow()
        {
            InitializeComponent();
        }
        //Students _SelectedMeme { get; set; }
        //public Reduct(Students students)
        //{
        //    InitializeComponent();
        //    _SelectedMeme = students;
        //    txtFirstName.DataContext = _SelectedMeme;
        //    txtLastName.DataContext = _SelectedMeme;
        //    txtGroup.DataContext = _SelectedMeme;
        //    txtGender.DataContext = _SelectedMeme;
        //    txtSpec.DataContext = _SelectedMeme;
        //}
        //private void Returnbtn_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void AddClientbtn_Click(object sender, RoutedEventArgs e)
        //{
        //    _SelectedMeme.isDelete = 1;
        //    ClassApp.ClassEditStudent classEditStudent = new ClassApp.ClassEditStudent();
        //    classEditStudent.NewStudent(txtFirstName.Text, txtLastName.Text, Convert.ToInt32(txtGroup.Text), Convert.ToInt32(txtGender.Text), Convert.ToInt32(txtSpec.Text)/*, selCombo.Id_groups*/);
        //    App.Connection.SaveChanges();
        //    MessageBox.Show("обновлено успешно");
        //    this.Close();
        //}
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtAnimal.Text != "" && txtVrach.Text != "" && txtDate.DataContext != null && txtComment.Text != "")
            {
                Priem priem = new Priem()
                {
                    id_animal = Convert.ToInt32(txtAnimal.Text),
                    id_vrach = Convert.ToInt32(txtVrach.Text),
                    date_priem = Convert.ToDateTime(txtDate.DataContext),
                    comment = txtComment.Text,
                    is_delete = false
                };
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
