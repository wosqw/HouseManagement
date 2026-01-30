using System.Linq;
using System.Windows;
using HuseManagement.Data;

namespace HuseManagement
{
    public partial class LoginWindow : Window
    {
        private HousingManagementDB _context = HousingManagementDbContextSingleton.Instance;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;

            var employee = _context.Employees.FirstOrDefault(x => x.Phone == login || x.Email == login);

            int aptNumber;
            bool isNumber = int.TryParse(login, out aptNumber);
            var owner = _context.Owners.FirstOrDefault(x => (isNumber && x.ApartmentNumber == aptNumber) || x.Phone == login);

            if (employee != null)
            {
                var mainWindow = new MainWindow(employee);
                mainWindow.Show();
                Close();
            }
            else if (owner != null)
            {
                var mainWindow = new MainWindow(owner);
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
