﻿using System;
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

namespace VeterinarkaProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            var vrach = App.Connection.Vrach.Where(u => u.login == txtLog.Text && u.password == txtPas.Password).FirstOrDefault();
            if(txtLog.Text != "" && txtPas.Password != null)
            {
                if(vrach != null)
                {
                    MessageBox.Show("все норм");
                    NavigationService.Navigate(new PageApp.MainPage());
                }
                else
                {
                    MessageBox.Show("все не норм");
                }
            }
            else
            {
                MessageBox.Show("не все заполнено");
            }
        }
    }
}
