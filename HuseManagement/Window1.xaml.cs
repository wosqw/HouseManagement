using System.Windows;
using HuseManagement.Data;

namespace HuseManagement
{
    public partial class AddEditRequestWindow : Window
    {
        private RepairRequests _request;
        private HousingManagementDB _context = HousingManagementDbContextSingleton.Instance;
        private bool _isOwnerMode = false;

        public AddEditRequestWindow(RepairRequests request = null, Owners owner = null, bool isOwner = false)
        {
            InitializeComponent();
            _request = request ?? new RepairRequests();
            if (owner != null)
            {
                _request.Owners = owner;
            }
            _isOwnerMode = isOwner;
            if (_isOwnerMode && string.IsNullOrEmpty(_request.RequestStatus))
            {
                _request.RequestStatus = "На рассмотрении";
            }
            DataContext = _request;

            if (_isOwnerMode)
            {
                StatusTextBox.IsEnabled = false;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_isOwnerMode)
            {
                _request.RequestStatus = "На рассмотрении";
            }
            
            if (_request.Owners == null)
            {
                MessageBox.Show("Владелец не выбран. Укажите владельца заявки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_request.ProblemDescription))
            {
                MessageBox.Show("Описание проблемы не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_request.RequestID == 0)
            {
                try
                {
                    _context.RepairRequests.Add(_request);
                    _context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    var msg = "Ошибка при добавлении заявки: " + ex.Message;
                    if (ex.InnerException != null)
                        msg += "\n" + ex.InnerException.Message;
                    MessageBox.Show(msg, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    var msg = "Ошибка при сохранении заявки: " + ex.Message;
                    if (ex.InnerException != null)
                        msg += "\n" + ex.InnerException.Message;
                    MessageBox.Show(msg, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
