using Hospital_man_sys.Model;
using Hospital_man_sys.Views;
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

namespace Hospital_man_sys.Views
{
    public partial class AddAppointment : Window
    {
        private int _patientId;

        public AddAppointment(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
            PatientID.Text = patientId.ToString();
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!DateTime.TryParseExact(AppointmentDate.Text, "yyyy-MM-dd",
                    null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    MessageBox.Show("Please enter date in format: yyyy-MM-dd\nExample: 2025-10-15");
                    return;
                }

                if (!TimeSpan.TryParseExact(AppointmentTime.Text, "hh\\:mm",
                    null, out TimeSpan time))
                {
                    MessageBox.Show("Please enter time in format: HH:mm\nExample: 14:30");
                    return;
                }

                DateTime appointmentDateTime = date.Add(time);

                using var context = new HospitalDB();

                var newAppointment = new Appointments
                {
                    Pat_ID = _patientId,
                    DateTime = appointmentDateTime
                };

                context.Appointments.Add(newAppointment);
                context.SaveChanges();

                MessageBox.Show("Appointment added successfully!");

                Appoin appoin = new Appoin();
                appoin.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}