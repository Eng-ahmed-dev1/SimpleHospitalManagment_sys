using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Hospital_man_sys.Model;

namespace Hospital_man_sys.Views
{
    public partial class Appoin : Window
    {
        private int _currentPatientId;

        public Appoin()
        {
            InitializeComponent();
            LoadAllAppointments();
        }

        public Appoin(int patientId)
        {
            InitializeComponent();
            _currentPatientId = patientId;
            LoadAllAppointments();
        }

        private void LoadAllAppointments()
        {
            try
            {
                using var context = new HospitalDB();

                var appointments = context.Appointments
                    .Include(a => a.Patients)
                    .OrderByDescending(a => a.DateTime)
                    .ToList();

                AppointmentsGrid.ItemsSource = appointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}