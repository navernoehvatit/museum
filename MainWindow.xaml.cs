using System;
using System.Windows;
using System.Windows.Controls;

namespace MuseumApp.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AuthView.xaml
    /// </summary>
    public partial class AuthView : UserControl
    {
        public AuthView()  
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            string log, pas;
            log = Core.Encrypter.GetHash(loginTb.Text); 
            pas = Core.Encrypter.GetHash(passwordTb.Password); 
            string sqltext = ($"select * from Employees where empLogin like '{log}' and empPassword like '{pas}' and currentWorker = 1");
            if (Model.DBConnection.Authorisation(sqltext)==true)
            {
                var win = Application.Current.MainWindow;
                win.Close();
            }
        }
    }
}
