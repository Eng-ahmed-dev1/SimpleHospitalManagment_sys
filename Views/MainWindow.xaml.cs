using Hospital_man_sys.Model;
using Hospital_man_sys.Views;
using System.Linq;
using System.Windows;

namespace Hospital_man_sys
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new HospitalDB();

                if (!int.TryParse(ID.Text, out int id))
                {
                    MessageBox.Show("Enter the id as a number please");
                    return;
                }

                string name = (Name.Text).Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter a valid name.");
                    return;
                }

                string cond = (Condition.Text).Trim();
                if (string.IsNullOrWhiteSpace(cond))
                {
                    MessageBox.Show("Please enter a valid condition.");
                    return;
                }

                var existPatient = context.Patients.FirstOrDefault(x => x.ID == id);
                if (existPatient == null)
                {
                    var Npat = new Patients(id, name, cond);
                    context.Patients.Add(Npat);
                    context.SaveChanges();

                    MessageBox.Show("Patient added successfully!");

                    // فتح نافذة إضافة الموعد
                    AddAppointment appointmentWindow = new AddAppointment(id);
                    appointmentWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This patient ID already exists");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}