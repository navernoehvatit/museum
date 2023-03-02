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

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string login, password;
            login = Core.Encrypter.GetHash(loginTb.Text);
            password = Core.Encrypter.GetHash(passwordTb.Password);
            string sqlQuery = ($"select * from Employees where empLogin like '{login}' and empPassword like '{password}' and currentWorker = 1");
            if (Model.DBConnection.Authorisation(sqlQuery) == true) //проверка введенных данных
            {
                var mainWindow = Application.Current.MainWindow;
                mainWindow.Close(); //закрытие окна
            }
        }
    }
}
